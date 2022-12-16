using UnityEngine;
using GameKit;
using System;
using System.Collections;
using System.Collections.Generic;

public class DialogController: MonoSingletonBase<DialogController>
{

    

    public DialogAsset dialogAsset;
    public List<DialogAsset> dialogAssetList = new List<DialogAsset>();




    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            DialogSystem.current.StartDialog(dialogAssetList[SceneController.current_SceneID-1].title, dialogAssetList[SceneController.current_SceneID - 1].contents);
        }

    }



}