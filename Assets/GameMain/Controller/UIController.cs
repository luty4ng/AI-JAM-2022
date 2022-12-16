using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;

public class UIController : MonoSingletonBase<UIController>
{
    UIExample_Panel m_CachedUIExample;
    GameUI  m_gameUI;
    
    OptionUI m_optionUI;
    bool optionOpen=false;

    MenuUI m_menuUI;

    private void Update()
    {

        if (ProcessController.current.currentProcess==ProcessController.Process.isMenu)
        {
            m_menuUI = UICenter.current.OpenUI<MenuUI>("MenuUI");
            
        }
        else if(ProcessController.current.currentProcess == ProcessController.Process.isGaming)
        {           
            m_gameUI = UICenter.current.OpenUI<GameUI>("GameUI");

        }
    }
    public void OnArchiveBtnClick()
    {


    }

    public void OnBackpackBtnClick()
    {

    }

    public void OnOptionBtnClick()
    {
        if (!optionOpen)
        {
            m_optionUI = UICenter.current.OpenUI<OptionUI>("OptionUI");
            optionOpen = true;
        }
        else
        {
            UICenter.current.CloseUI<OptionUI>(m_optionUI.idName);
            optionOpen = false;
        }
        

    }

    public void CloseOptionUI()
    {
        UICenter.current.CloseUI<OptionUI>(m_optionUI.idName);
    }

    public void OnHomeBtnClick()
    {
        SceneController.current.BackToMenu();
    }

}
