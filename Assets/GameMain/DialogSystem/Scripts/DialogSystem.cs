using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;
using GameKit.DataStructure;
using GameKit;
using UnityEngine.Events;
using Assets.GameMain.DialogSystem.Scripts.UI;

[DisallowMultipleComponent]
[AddComponentMenu("GameKit/Dialog System")]
public class DialogSystem : MonoSingletonBase<DialogSystem>
{
    public static bool IsActive = true;
    //对象池
    public CharacterPool characterPool;
    //
    private DialogTree dialogTree;
    private UI_DialogSystem uI_DialogSystem;
    private TextAnimatorPlayer textAnimatorPlayer;
    private Character currentCharacter;
    private List<RuntimeAnimatorController> charaAnimators = new List<RuntimeAnimatorController>();
    private bool isOptionShowing = false;
    private bool isInSelection = false;
    //对话是否正在陆续显示中
    private bool isTextShowing = false;


    private void Start()
    {
        //在ui注册表中获取对话框的ui面板
        uI_DialogSystem = UIManager.instance.GetUI<UI_DialogSystem>("UI_DialogSystem");
        //
        textAnimatorPlayer = uI_DialogSystem.textAnimatorPlayer;
    }
    
    public void StartDialog(string title, string dialogText)
    {
        Debug.Log($"Start Dialog");
        isTextShowing = false;
        dialogTree = DialogManager.instance.CreateTree(title, dialogText);
        dialogTree.Reset();
        //显示对话框ui
        uI_DialogSystem.Show();
        //执行第一句对话
        ExcuteTextDisplay();
    }

    private void Update()
    {
        if (IsActive == false || dialogTree == null)
            return;

        //这是选项已显示完全 且进入选择的情况
        if (!isOptionShowing && isInSelection)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int choiceIndex = uI_DialogSystem.GetSelection();
                //选择状态取消
                isInSelection = false;
                //下一句对话根据选项改变
                Node<Dialog> nextNode = GetNextNode(choiceIndex);
                ExcuteTextDisplay();
                //隐藏选项
                uI_DialogSystem.HideResponse(() =>
                {
                    uI_DialogSystem.uI_DialogResponse.IsActive = false;
                    uI_DialogSystem.uI_DialogResponse.gameObject.SetActive(false);
                });
                return;
            }
        }

        //这是正常情况
        if (!isInSelection)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //若文字不是在打印中 则执行下一句对话
                if (isTextShowing == false)
                {
                    ExcuteTextDisplay();
                }//否则加速对话
                else
                    InterruptTextDisplay();
            }
        }

        //若没有文字显示 则隐藏
        uI_DialogSystem.indicator.SetActive(!isTextShowing);
    }

    //进入选择模式
    private void UpdateChoiceUI()
    {
        List<Option> options = dialogTree.GetOptions();
        if (options != null)
        {
            // Debug.Log($"Update Choice UI");
            uI_DialogSystem.UpdateOptions(options);
            uI_DialogSystem.uI_DialogResponse.IsActive = true;
            uI_DialogSystem.uI_DialogResponse.gameObject.SetActive(true);
            isOptionShowing = true;
            isInSelection = true;
            uI_DialogSystem.ShowResponse(() =>
            {
                isOptionShowing = false;
            });

        }
    }

    private void UpdateUI(Node<Dialog> node)
    {
        // Debug.Log($"Update Character UI");
        if (node == null || node.nodeEntity.speaker == "Default")
            return;

        if (node.nodeEntity.speaker == ">>")
            uI_DialogSystem.speakerName.text = "";
        else if (node.nodeEntity.speaker == "??")
            uI_DialogSystem.speakerName.text = "未知";
        else
            uI_DialogSystem.speakerName.text = node.nodeEntity.speaker;
        uI_DialogSystem.contents.text = node.nodeEntity.contents;


        if (node.nodeEntity.speaker != ">>")
        {
            Character character = characterPool.FindCharacter(node.nodeEntity.speaker.Correction());
            if (currentCharacter != character)
            {
                currentCharacter = character;
            }
            RuntimeAnimatorController charaAnimator = FindAnimator(character.idName);
        }
    }

    private void PhaseNode(Node<Dialog> dialogNode, UnityAction onTextShowed = null)
    {
        UpdateUI(dialogNode);
        textAnimatorPlayer.onTypewriterStart.AddListener(() =>
        {
            isTextShowing = true;
        });
        textAnimatorPlayer.onTextShowed.AddListener(() =>
        {
            isTextShowing = false;
        });

        if (onTextShowed != null)
            textAnimatorPlayer.onTextShowed.AddListener(onTextShowed);

        textAnimatorPlayer.StartShowingText();
    }

    private Node<Dialog> GetNextNode(int index = 0)
    {
        if (dialogTree.currentNode.IsLeaf || index < 0 || index >= dialogTree.currentNode.Sons.Count)
            return null;
        dialogTree.currentNode = dialogTree.currentNode.Sons[index];
        return dialogTree.currentNode as Node<Dialog>;
    }
    private void ExcuteTextDisplay(Node<Dialog> nextNode)
    {
        if (nextNode == null)
        {
            ReachTheEndOfConversation();
            return;
        }

        if (nextNode.nodeEntity.IsFunctional)
        {
            if (nextNode.nodeEntity.IsCompleter)
            {
                for (int j = 0; j < nextNode.nodeEntity.completeConditons.Count; j++)
                {
                    dialogTree.LocalConditions[nextNode.nodeEntity.completeConditons[j]] = true;
                }
            }

            if (nextNode.nodeEntity.IsDivider)
            {
                bool isComplete = true;
                for (int j = 0; j < nextNode.nodeEntity.dividerConditions.Count; j++)
                {
                    if (!dialogTree.LocalConditions[nextNode.nodeEntity.dividerConditions[j]])
                    {
                        isComplete = false;
                        break;
                    }
                }

                if (isComplete)
                {
                    PhaseNode(GetNextNode(0));
                }
                else
                {
                    PhaseNode(GetNextNode(1));
                }
            }
        }
        else
        {
            if (nextNode.IsBranch)
            {
                PhaseNode(nextNode, UpdateChoiceUI);
            }
            else
            {
                PhaseNode(nextNode);
            }
        }
    }
    /// <summary>
    /// 执行对话
    /// </summary>
    /// <param name="index"></param>
    private void ExcuteTextDisplay(int index = 0)
    {
        Node<Dialog> nextNode = GetNextNode(index);
        ExcuteTextDisplay(nextNode);
    }


    /// <summary>
    /// 加速对话
    /// </summary>
    private void InterruptTextDisplay()
    {
        textAnimatorPlayer.SkipTypewriter();
        isTextShowing = false;
    }

    private void ReachTheEndOfConversation()
    {
        Debug.Log("Reach The End Of Conversation.");
        dialogTree.Clear();
        dialogTree = null;
        uI_DialogSystem.Hide();
    }

    private RuntimeAnimatorController FindAnimator(string name)
    {
        for (int i = 0; i < charaAnimators.Count; i++)
        {
            if (charaAnimators[i].name == "AC_" + name)
            {
                return charaAnimators[i];
            }
        }
        return null;
    }
}
