using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

public class MenuUI : UIGroup
{
    public Button startBtn;
    public Button continueBtn;
    public Button optionBtn;
    public Button quitBtn;
    


    protected override void Start()
    {
        base.Start();
        startBtn.onClick.AddListener(OnStartBtnClick);
        continueBtn.onClick.AddListener(OnContinueBtnClick);
        optionBtn.onClick.AddListener(OnOptionBtnClick);
        quitBtn.onClick.AddListener(OnQuitBtnClick);

        if (true)
        {
            continueBtn.gameObject.SetActive(false);
        }

    }

    public override void Show(UnityAction callback = null)
    {
        // 淡入打开面板
        panelCanvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public override void Hide(UnityAction callback = null)
    {
        panelCanvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }
    private void OnStartBtnClick()
    {
        SceneController.current_SceneID++;
        ProcessController.current.currentProcess = ProcessController.Process.isGaming;
        SceneController.current.GoToSceneByID(1);
        UICenter.current.CloseUI<MenuUI>("MenuUI");
    }

    private void OnContinueBtnClick()
    {
        SceneController.current.GoToSceneByID(1);
    }
    private void OnOptionBtnClick()
    {

        UIController.current.OnOptionBtnClick();
    }


    private void OnQuitBtnClick()
    {
        Application.Quit();
    }
}
