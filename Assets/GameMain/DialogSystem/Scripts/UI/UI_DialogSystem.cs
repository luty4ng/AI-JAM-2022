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
        //˵���ߵ�����
        public TextMeshProUGUI speakerName;
        //�ı�����
        public TextMeshProUGUI contents;
        //�ı�����������
        public TextAnimatorPlayer textAnimatorPlayer;
        //ѡ�����
        public UI_DialogResponse uI_DialogResponse;
        //�Ի��ߵ�ͼ��
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

        //���ѡ��
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