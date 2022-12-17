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

    ArchiveUI m_archiveUI;
    bool archiveOpen=false;  

    BackpackUI m_backpackUI;
    bool backpackOpen=false;


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
        if (!archiveOpen)
        {
            m_archiveUI = UICenter.current.OpenUI<ArchiveUI>("ArchiveUI");
            archiveOpen = true;
        }
        else
        {
            UICenter.current.CloseUI<ArchiveUI>(m_archiveUI.idName);
            archiveOpen = false;
        }

    }

    public void OnBackpackBtnClick()
    {
        if (!backpackOpen)
        {
            m_backpackUI = UICenter.current.OpenUI<BackpackUI>("BackpackUI");
            backpackOpen = true;
        }
        else
        {
            UICenter.current.CloseUI<BackpackUI>(m_backpackUI.idName);
            backpackOpen = false;
        }
    }

    public void OnOptionBtnClick()
    {
        //OpenOrCloseUI<OptionUI>(optionOpen, "OptionUI");
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


    public void OnHomeBtnClick()
    {
        SceneController.current.BackToMenu();
    }

    public void OpenOrCloseUI<T>(bool ui_open,string uiName)where T:UIGroup
    {
        
        if (!ui_open)
        {
            UICenter.current.OpenUI<T>(uiName);
            ui_open = true;
        }
        else
        {
            UICenter.current.CloseUI<T>(uiName);
            ui_open = false;
        }
    }
}
