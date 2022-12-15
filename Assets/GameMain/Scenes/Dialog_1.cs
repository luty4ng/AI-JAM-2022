using UnityEngine;
using GameKit;
using System;

public class Dialog_1 : MonoBehaviour
{
    public DialogAsset dialogAsset;
    public GameObject Hint;
    public GameObject Bkg;
    public GameObject GameUI;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Hint.SetActive(false);
            DialogSystem.current.StartDialog(dialogAsset.title, dialogAsset.contents);
        }

        if (DialogSystem.SceneID >= 0)
        {
            GameUI.SetActive(true);
        }
   

    }
}