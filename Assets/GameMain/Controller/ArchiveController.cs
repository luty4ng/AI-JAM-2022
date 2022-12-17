using UnityEngine;
using GameKit;
using System;
using System.Collections;
using System.Collections.Generic;

public class ArchiveController : MonoSingletonBase<ArchiveController>
{
    public void SaveArichive(int archNum, int sceneID)
    {
        PlayerPrefs.SetInt("ArchNum="+archNum, sceneID);
        PlayerPrefs.Save(); //保存我们设置的PlayerPrefs
    }

    public void LoadArichive(int archNum)
    {
        int sceneID = ArchiveController.current.GetArchive(archNum);
        SceneController.current.GoToSceneByID(sceneID);
    }
    
    public int GetArchive(int archNum)
    {
        return PlayerPrefs.GetInt("ArchNum=" + archNum, 404);

    }





}