using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameKit;
using System.Collections.Generic;
using Febucci.UI;
using UnityEngine.Events;

namespace Assets.GameMain.DialogSystem.Scripts.UI
{
    //这里是处理对话界面的显示
    public class UI_DialogSystem : UIGroup
    {
        //说话者的名字
        public TextMeshProUGUI speakerName;
        //文本内容
        public TextMeshProUGUI contents;
        //文本动画播放器
        public TextAnimatorPlayer textAnimatorPlayer;
        //选项面板
        public UI_DialogResponse uI_DialogResponse;

        //对话者的图像
        public Image uI_SpeakerPicLeft;
        public Image uI_SpeakerPicRight;

        //对话背景
        public Image ui_backGround;
        

        public GameObject indicator;
        private Animator animator;

        protected override void OnStart()

        {
            base.OnStart();
            // panelCanvasGroup.alpha = 0;
            // this.gameObject.SetActive(false);
            animator = GetComponent<Animator>();
 
               
            
        }

        public void UpdateOptions(List<Option> options)
        {
            uI_DialogResponse.UpdateOptions(options);
        }

        public void ShowResponse(UnityAction callback = null)
        {
            uI_DialogResponse.Show(callback);
        }

        public void HideResponse(UnityAction callback = null)
        {
            uI_DialogResponse.Hide(callback);
        }

        public void ShowSpeaker(UnityAction callback = null)
        {
            uI_SpeakerPicLeft.gameObject.SetActive(true);
            uI_SpeakerPicRight.gameObject.SetActive(true);
        }
        public void ShowSpeakerLeft(UnityAction callback = null)
        {
            uI_SpeakerPicLeft.gameObject.SetActive(true);
        }
        public void ShowSpeakerRight(UnityAction callback = null)
        {
            uI_SpeakerPicRight.gameObject.SetActive(true);
        }
        //获得选项
        public int GetSelection()
        {
            return uI_DialogResponse.CurIndex;
        }

        public override void Hide(UnityAction callback = null)
        {
            // panelCanvasGroup.alpha = 0;
            // this.gameObject.SetActive(false);
            animator.SetTrigger("FadeOut");
        }

        public override void Show(UnityAction callback = null)
        {
            // panelCanvasGroup.alpha = 1;
            // this.gameObject.SetActive(true);
            animator.SetTrigger("FadeIn");
        }
    }
}