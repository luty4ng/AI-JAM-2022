using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;

public class OptionUI : UIGroup
{
    public Button quitBtn;

    public void Start()
    {
        quitBtn.onClick.AddListener(OnQuitBtnClick);
    }

    private void OnQuitBtnClick()
    {
        this.gameObject.active = false;
        UIManager.instance.HideUI("OptionUI");
    }

}
