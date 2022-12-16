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
    MenuUI m_menuUI;

    private void Start()
    {
        
        m_menuUI = UICenter.current.OpenUI<MenuUI>("MenuUI");
        m_gameUI = UICenter.current.OpenUI<GameUI>("GameUI");

    }
    private void Update()
    {

        if (SceneController.current_SceneID == 0)
        {
            m_menuUI = UICenter.current.OpenUI<MenuUI>("MenuUI");
            
        }
        else
        {
            UICenter.current.CloseUI<MenuUI>(m_menuUI.idName);
        }

        if (SceneController.current_SceneID >= 0)
        {
             m_gameUI = UICenter.current.OpenUI<GameUI>("GameUI");
        }
        else
        {
        
            UICenter.current.CloseUI<GameUI>(m_gameUI.idName);
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

        m_optionUI = UICenter.current.OpenUI<OptionUI>("OptionUI");
        

    }

    public void CloseOptionUI()
    {
        UICenter.current.CloseUI<OptionUI>(m_optionUI.idName);
    }

    public void OnHomeBtnClick()
    {
        DialogSystem.current.GoToNextScene("GameMenu");
    }

}
