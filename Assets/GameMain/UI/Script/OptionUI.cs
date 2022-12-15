using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameKit;
using System.Collections.Generic;
using Febucci.UI;
using UnityEngine.Events;

public class OptionUI : UIGroup
{
    public Button quitBtn;

    protected override void OnStart()
    {
        quitBtn.onClick.AddListener(OnQuitBtnClick);

        
    }

    private void OnQuitBtnClick()
    {
        this.gameObject.SetActive(false);
        
    }

    public override void Show(UnityAction callback = null)
    {
        // panelCanvasGroup.alpha = 1;
        this.gameObject.SetActive(true);
        //animator.SetTrigger("FadeIn");
    }

    public override void Hide(UnityAction callback = null)
    {
        // panelCanvasGroup.alpha = 1;
        this.gameObject.SetActive(false);
        //animator.SetTrigger("FadeIn");
    }

    protected override void Awake()
    {
        base.Awake();
    }


    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
