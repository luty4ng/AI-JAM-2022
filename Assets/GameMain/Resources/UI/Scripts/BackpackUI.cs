using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

public class BackpackUI : UIGroup
{
    public override void Show(UnityAction callback = null)
    {
        // 淡入打开面板
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


    public void OnQuitBtnClick()
    {
        UICenter.current.CloseUI<BackpackUI>("BackpackUI");

    }
}
