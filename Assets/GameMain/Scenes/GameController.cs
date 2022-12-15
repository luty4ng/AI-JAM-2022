using UnityEngine;
using GameKit;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController: MonoSingletonBase<GameController>
{
    //
    public DialogAsset dialogAsset;
    //
    public List<DialogAsset> dialogAssetList = new List<DialogAsset>();

    public GameObject Hint;
    public GameObject Bkg;
    public int current_SceneID = DialogSystem.SceneID;

    public GameObject GameUI;
    public GameObject uI_Option;
    public GameObject uI_Archive;
    public GameObject uI_Backpack;

  
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        uI_Option.SetActive(false);
        uI_Archive.SetActive(false);
        uI_Backpack.SetActive(false);
    }
    void Update()
    {
        current_SceneID = DialogSystem.SceneID;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Hint.SetActive(false);
            DialogSystem.current.StartDialog(dialogAssetList[DialogSystem.SceneID].title, dialogAssetList[DialogSystem.SceneID].contents);
        }

        if (DialogSystem.SceneID == 1)
        {
            GameUI.SetActive(true);
        }
    }
    public void OnArchiveBtnClick()
    {
        
        if (uI_Archive.activeSelf == false)
        {
            uI_Archive.SetActive(true);
        }
        else
        {
            uI_Archive.SetActive(false);
        }
    }

    public void OnBackpackBtnClick()
    {
        if (uI_Backpack.activeSelf == false)
        {
            uI_Backpack.SetActive(true);
        }
        else
        {
            uI_Backpack.SetActive(false);
        }
    }

    public void OnOptionBtnClick()
    {
        //打开界面
        if (uI_Option.activeSelf ==false) 
        {
          uI_Option.SetActive(true);
        }
        else
        {
            uI_Option.SetActive(false);
        }

    }

    public void OnHomeBtnClick()
    {
        DialogSystem.current.GoToNextScene("GameMenu");
    }


}