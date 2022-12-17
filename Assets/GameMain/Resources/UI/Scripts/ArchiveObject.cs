using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

namespace Assets.GameMain.Resources.UI.Scripts
{
    public class ArchiveObject : UIGroup
    {
        public int ArchiveNum;
        public int SceneID;

        public Text textArchiveNum;
        public Text textSceneID;

        protected override void OnStart()
        {
            textArchiveNum.text = ArchiveNum.ToString();
            textSceneID.text = SceneID.ToString();
        }
    }
}