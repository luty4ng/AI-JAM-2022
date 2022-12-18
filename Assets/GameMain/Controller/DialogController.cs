using UnityEngine;
using GameKit;
using System;
using System.Collections;
using System.Collections.Generic;

public class DialogController: MonoSingletonBase<DialogController>
{

    public List<DialogAsset> dialogAssetList = new List<DialogAsset>();

    public int SceneID_ImmerseEnding;
    public int SceneID_SoberEnding;

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCurrentDialog();
        }        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.LogWarning("debug");
        }

    }
    public void Start()
    {
        StartCurrentDialog();
    }


    public void StartCurrentDialog()
    {
        if (SceneController.current_SceneID!=0)
        {
            DialogSystem.current.StartDialog(dialogAssetList[SceneController.current_SceneID].title, dialogAssetList[SceneController.current_SceneID].contents);
        }
    }
      
    public void GoImmerse()
    {
        DialogSystem.current.StartDialog(dialogAssetList[SceneID_ImmerseEnding].title, dialogAssetList[SceneID_ImmerseEnding].contents);   
    }
    public void GoAwake()
    {
        DialogSystem.current.StartDialog(dialogAssetList[SceneID_SoberEnding].title, dialogAssetList[SceneID_SoberEnding].contents);
    }
}