using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MenuUI : UIGroup
{
    public Button startBtn;
    public Button continueBtn;
    public Button optionBtn;
    public Button quitBtn;
    public GameObject uI_Option;

    public void GoToScene(string name)
    {
        Scheduler.current.SwitchSceneByDefault(name, () =>
        {
            Debug.Log(string.Format("³¡¾°{0}ÇÐ»»Íê±Ï", name));
        });
    }

    public void Start()
    {

       // uI_Option= UIManager.instance.GetUI<OptionUI>("OptionUI");

        startBtn.onClick.AddListener(OnStartBtnClick);
        continueBtn.onClick.AddListener(OnContinueBtnClick);
        optionBtn.onClick.AddListener(OnOptionBtnClick);
        quitBtn.onClick.AddListener(OnQuitBtnClick);

        if (true)
        {
            continueBtn.gameObject.SetActive(false);
        }

    }
    private void OnStartBtnClick()
    {
      //  GameController.current.current_SceneID = 1;
        GoToScene("SceneID_ "+DialogSystem.SceneID);


    }

    private void OnContinueBtnClick()
    {
        GoToScene("Scene");
    }
    private void OnOptionBtnClick()
    {
        
        //uI_Option.gameObject.SetActive(true);
    }

    private void onOptionUIOpenSucc()
    {
        throw new NotImplementedException();
    }

    private void OnQuitBtnClick()
    {
        Application.Quit();
    }
}
