using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameUI : UIGroup
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public Button OptionBtn;
    public Button ArchiveBtn;
    public Button BackpackBtn;

    public GameObject uI_Option;
    public GameObject uI_Archive;
    public GameObject uI_Backpack;
    protected override void OnStart()
    {
     
        OptionBtn.onClick.AddListener(OnOptionBtnClick);
        BackpackBtn.onClick.AddListener(OnBackpackBtnClick);
        ArchiveBtn.onClick.AddListener(OnArchiveBtnClick);


        uI_Option.SetActive(false);
        uI_Archive.SetActive(false);
        uI_Backpack.SetActive(false);
    }

    private void OnArchiveBtnClick()
    {
        uI_Archive.SetActive(true);
    }

    private void OnBackpackBtnClick()
    {
        //打开界面
        uI_Backpack.SetActive(true);
    }

    private void OnOptionBtnClick()
    {
        //打开界面
        uI_Option.SetActive(true);
    }
}
