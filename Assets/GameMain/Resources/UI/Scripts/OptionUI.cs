using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameKit;
using System.Collections.Generic;
using DG.Tweening;
using Febucci.UI;
using UnityEngine.Events;
using System;

public class OptionUI : UIGroup
{
    public Button quitBtn;
    public Toggle bgmTog;


    protected override void OnStart()
    {
        quitBtn.onClick.AddListener(OnQuitBtnClick);
        bgmTog.onValueChanged.AddListener(OnBgmTogChange);
        
    }

    private void OnBgmTogChange(bool arg0)
    {
        if(arg0 == false)
        {
            MusicController.current.BGMstop();
        }
        else
        {
            MusicController.current.BGMstart();
        }
    }

    private void OnQuitBtnClick()
    {
        UICenter.current.CloseUI<OptionUI>("OptionUI");
        
    }

    public override void Show(UnityAction callback = null)
    {
        
        panelCanvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {
            panelCanvasGroup.gameObject.SetActive(true);
        });
    }

    public override void Hide(UnityAction callback = null)
    {
        panelCanvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            panelCanvasGroup.gameObject.SetActive(false);
        });
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
