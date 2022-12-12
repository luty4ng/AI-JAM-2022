using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameKit;
using System.Collections.Generic;
using Febucci.UI;
using UnityEngine.Events;

namespace Assets.GameMain.DialogSystem.Scripts.UI
{
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
        public UI_CharacterPic uI_CharacterPic;
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