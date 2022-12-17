using UnityEngine;
using GameKit;
using System;
using System.Collections;
using System.Collections.Generic;

public class DialogController: MonoSingletonBase<DialogController>
{

    

   
    public List<DialogAsset> dialogAssetList = new List<DialogAsset>();


    public DialogAsset ImmerseEnding;
    public DialogAsset SoberEnding;

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            DialogSystem.current.StartDialog(dialogAssetList[SceneController.current_SceneID-1].title, dialogAssetList[SceneController.current_SceneID - 1].contents);
        }

    }

    public void GoImmerse()
    {
        DialogSystem.current.StartDialog(ImmerseEnding.title, ImmerseEnding.contents);
    }
    public void GoAwake()
    {
        DialogSystem.current.StartDialog(SoberEnding.title, SoberEnding.contents);
    }
}