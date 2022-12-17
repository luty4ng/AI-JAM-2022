using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

public class ArchiveUI : UIGroup
{
    public Button archiveBtn_1;
    public Button archiveBtn_2;
    public Button archiveBtn_3;

    public bool archiveFlag_1;
    public GameObject archivePanel_1;
    public bool archiveFlag_2;
    public GameObject archivePanel_2;
    public bool archiveFlag_3;
    public GameObject archivePanel_3;

    protected override void OnStart()
    {
        archiveBtn_1.onClick.AddListener(OnArchiveBtn1Click);
        archiveBtn_1.onClick.AddListener(OnArchiveBtn2Click);
        archiveBtn_1.onClick.AddListener(OnArchiveBtn3Click);
    }

    private void OnArchiveBtn1Click()
    {
        //如果没有得到一个存档数
        if (ArchiveController.current.GetArchive(1)==404)
        {
            ArchiveController.current.SaveArichive(1, SceneController.current_SceneID);
            archiveFlag_1 =true;
            archivePanel_1.SetActive(true);
        }
        else
        {
            ArchiveController.current.LoadArichive(1);
        }

}

    private void OnArchiveBtn2Click()
    {
        ArchiveController.current.SaveArichive(2, SceneController.current_SceneID);
        archivePanel_2.SetActive(true);
    }

    private void OnArchiveBtn3Click()
    {
        ArchiveController.current.SaveArichive(3,SceneController.current_SceneID);
        archivePanel_3.SetActive(true);
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

    public void OnQuitBtnClick()
    {
        UIController.current.OnArchiveBtnClick();
    }

}
