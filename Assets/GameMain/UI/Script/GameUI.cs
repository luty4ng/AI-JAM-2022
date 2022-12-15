using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameUI : UIGroup
{
    public Button OptionBtn;
    public Button ArchiveBtn;
    public Button BackpackBtn;

    public GameObject uI_Option;
    protected override void OnStart()
    {
        OptionBtn.onClick.AddListener(OnOptionBtnClick);
        BackpackBtn.onClick.AddListener(OnBackpackBtnClick);
        ArchiveBtn.onClick.AddListener(OnArchiveBtnClick);
    }

    private void OnArchiveBtnClick()
    {
        
    }

    private void OnBackpackBtnClick()
    {
        
    }

    private void OnOptionBtnClick()
    {
       //打开界面
    }
}
