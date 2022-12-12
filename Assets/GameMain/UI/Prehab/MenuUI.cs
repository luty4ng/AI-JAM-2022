using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MenuUI : UIForm
{
    public Button startBtn;
    public Button optionBtn;
    public Button quitBtn;

    public void Start()
    {
        startBtn.onClick.AddListener(OnStartBtnClick);
        optionBtn.onClick.AddListener(OnOptionBtnClick);
        quitBtn.onClick.AddListener(OnQuitBtnClick);

    }
    private void OnQuitBtnClick()
    {
        Application.Quit();
    }

    private void OnOptionBtnClick()
    {

        //UIManager.instance.ShowUI("OptionUI");
    }

    private void OnStartBtnClick()
    {
        SceneManager.LoadScene("DialogExample");
    }
}
