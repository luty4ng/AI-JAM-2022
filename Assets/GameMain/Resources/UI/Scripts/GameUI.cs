using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameUI : UIGroup
{
    public Button HomeBtn;
    public Button OptionBtn;
    public Button ArchiveBtn;
    public Button BackpackBtn;

    

    //限定值
    public int limitValue = 50;
    public Slider m_immerseValue;
    public Slider m_soberValue;


    protected override void OnStart()
    {
        HomeBtn.onClick.AddListener(OnHomeBtnClick);
        OptionBtn.onClick.AddListener(OnOptionBtnClick);
        BackpackBtn.onClick.AddListener(OnBackpackBtnClick);
        ArchiveBtn.onClick.AddListener(OnArchiveBtnClick);

        EventManager.instance.AddEventListener<int>(EventSettings.AWAKEN_CHANGE, SoberAdd);
        EventManager.instance.AddEventListener<int>(EventSettings.IMMERSIVE_CHANGE, ImmerseAdd);
    }

    public void ImmerseAdd(int addNum)
    {
        
        addNum *= 10;
        m_immerseValue.DOValue(m_immerseValue.value+addNum, 1f);

        //到达限定值以后直接跳转
        if (m_immerseValue.value > limitValue&&SceneController.current_SceneID!=5)
        {
            SceneController.current.GoToSceneByID(5);
            ProcessController.current.currentProcess = ProcessController.Process.isEnd;
            DialogController.current.GoImmerse();
            UIController.current.OpenOrCloseGameUI();
        }
    }
    public void SoberAdd(int addNum)
    {
        addNum *= 10;
        m_soberValue.DOValue(m_soberValue.value + addNum, 1f);
        if (m_soberValue.value > limitValue && SceneController.current_SceneID != 6)
        {
            SceneController.current.GoToSceneByID(6);
            ProcessController.current.currentProcess = ProcessController.Process.isEnd;
            DialogController.current.GoAwake();
            UIController.current.OpenOrCloseGameUI();

        }
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

    private void OnHomeBtnClick()
    {
        //场景控制器 的当前场景id转换到主菜单
        SceneController.current.BackToMenu();
    }

    private void OnArchiveBtnClick()
    {
        UIController.current.OnArchiveBtnClick();
    }

    private void OnBackpackBtnClick()
    {
        UIController.current.OnBackpackBtnClick();
    }

    private void OnOptionBtnClick()
    {
        UIController.current.OnOptionBtnClick();
    }

    public void Test()
    {
        Debug.Log(111);
    }
}
