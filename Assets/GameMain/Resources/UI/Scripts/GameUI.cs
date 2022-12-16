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
    public Slider m_immerseValue;
    public Slider m_soberValue;

    public void ImmerseAdd(int addNum)
    {
        m_immerseValue.DOValue(m_immerseValue.value + addNum, 1f);
    }
    public void SoberAdd(int addNum)
    {
        m_soberValue.DOValue(m_soberValue.value + addNum, 1f);
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

    protected override void OnStart()
    {
        HomeBtn.onClick.AddListener(OnHomeBtnClick);
        OptionBtn.onClick.AddListener(OnOptionBtnClick);
        BackpackBtn.onClick.AddListener(OnBackpackBtnClick);
        ArchiveBtn.onClick.AddListener(OnArchiveBtnClick);


    }

    private void OnHomeBtnClick()
    {
        //场景控制器 的当前场景id转换到主菜单
        SceneController.current_SceneID = 0;
        Scheduler.current.SwitchSceneByDefault("SceneID_ 0");
        UICenter.current.OpenUI<MenuUI>("MenuUI");
    }

    private void OnArchiveBtnClick()
    {
        UICenter.current.OpenUI("BackpackUI");
    }

    private void OnBackpackBtnClick()
    {
        UICenter.current.OpenUI("BackpackUI");
    }

    private void OnOptionBtnClick()
    {
        UICenter.current.OpenUI<OptionUI>("OptionUI");
    }
}
