using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;
using GameKit.DataStructure;
using GameKit;
using UnityEngine.Events;
using Assets.GameMain.DialogSystem.Scripts.UI;
using System;



//这里是处理对话界面的逻辑
[DisallowMultipleComponent]
[AddComponentMenu("GameKit/Dialog System")]
public class DialogSystem : MonoSingletonBase<DialogSystem>
{

    // [SerializeField]
    // public static int Dialog_SceneID = 0;
    // public  int Dialog_SceneID_cansee= Dialog_SceneID;

    public static bool IsActive = true;
    //对象池
    public CharacterPool characterPool;
    //
    private DialogTree dialogTree;
    //对话框ui界面
    private UI_DialogSystem uI_DialogSystem;

    private TextAnimatorPlayer textAnimatorPlayer;
    private Character currentCharacter;
    private Dialog m_CachedDialogNodeEntity = null;
    private List<RuntimeAnimatorController> charaAnimators = new List<RuntimeAnimatorController>();
    private bool isOptionShowing = false;
    private bool isInSelection = false;
    //对话是否正在陆续显示中
    private bool isTextShowing = false;
    //对话是否已经结束了
    public bool isDialogEnd = false;



    private void Start()
    {
        //在ui注册表中获取对话框的ui面板
        uI_DialogSystem = UIManager.instance.GetUI<UI_DialogSystem>("UI_DialogSystem");

        textAnimatorPlayer = uI_DialogSystem.textAnimatorPlayer;
    }

    //根据对话资源开始对话
    public void StartDialog(string title, string dialogText)
    {
        Debug.Log($"Start Dialog");

        isDialogEnd = false;
        isTextShowing = false;
        //创建对话树
        dialogTree = DialogManager.instance.CreateTree(title, dialogText);
        //重设对话树节点
        dialogTree.Reset();
        //显示对话框ui
        uI_DialogSystem.Show();
        //执行对话
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

    //对话进行角色改变
    private void UpdateUI(Node<Dialog> node)
    {

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

    //打印文本节点
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

    //开始
    private void ExcuteTextDisplay(Node<Dialog> nextNode)
    {

        if (nextNode == null)
        {
            ReachTheEndOfConversation();
            return;
        }

        m_CachedDialogNodeEntity = nextNode.nodeEntity;
        isDialogEnd = false;

        //
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
                PhaseNode(nextNode, PhaseAwakenAndImmersive);
                PhaseNode(nextNode, PhaseSceneTo);
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

        //每次执行更新人物画面
        if (uI_DialogSystem.uI_SpeakerPicLeft.overrideSprite != currentCharacter.characterPic)
        {
            uI_DialogSystem.uI_SpeakerPicLeft.overrideSprite = currentCharacter.characterPic;
        }
    }

    private void PhaseSceneTo()
    {
        if (m_CachedDialogNodeEntity == null)
            return;
        EventManager.instance.EventTrigger<int>(EventSettings.SCENE_TO, m_CachedDialogNodeEntity.SceneToIndicator);
        
    }


    private void PhaseAwakenAndImmersive()
    {
        if (m_CachedDialogNodeEntity == null)
            return;
        EventManager.instance.EventTrigger<int>(EventSettings.AWAKEN_CHANGE, m_CachedDialogNodeEntity.AwakenIndicator);
        EventManager.instance.EventTrigger<int>(EventSettings.IMMERSIVE_CHANGE, m_CachedDialogNodeEntity.ImmersiveIndicator);
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
        isDialogEnd = true;
        m_CachedDialogNodeEntity = null;

        //进入下一场景
        SceneController.current_SceneID++;
        if (SceneController.current_SceneID < 4)
        {
            GoToNextScene("SceneID_ " + SceneController.current_SceneID);
        }
        else
        {
            GoToNextScene("SceneID_ 0");
        }
    }

    public void GoToNextScene(string name)
    {
        Scheduler.current.SwitchSceneByDefault(name, () =>
        {
            Debug.Log(string.Format("场景{0}切换完毕", name));
        });
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
