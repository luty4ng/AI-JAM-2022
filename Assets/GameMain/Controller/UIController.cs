using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIController : MonoSingletonBase<UIController>
{

    public List<Image> BackGroundList;
    public int current_BackgroundID=-1;
    UIExample_Panel m_CachedUIExample;

    OptionUI m_optionUI;
    bool optionOpen=false;

    MenuUI m_menuUI;

    GameUI m_gameUI;
    bool gameUIOpen = false;

    ArchiveUI m_archiveUI;
    bool archiveOpen=false;  

    BackpackUI m_backpackUI;
    bool backpackOpen=false;

    protected override void OnAwake()
    {
        base.OnAwake();
        

    }

    private void Start()
    {
        EventManager.instance.AddEventListener<int>(EventSettings.BACKGROUND_CHANGE, BackGroundChangeID);
        UICenter.current.OpenUI<MenuUI>("MenuUI");
    }

    public void BackGroundChangeID(int background_ID)
    {
        Debug.Log(background_ID);
        if (current_BackgroundID!=-1)
        {
              BackGroundList[current_BackgroundID].gameObject.SetActive(false);
        }
        BackGroundList[background_ID].gameObject.SetActive(true);
        current_BackgroundID = background_ID;
    }

    public void OpenOrCloseGameUI()
    {
        if (!gameUIOpen)
        {
            m_gameUI = UICenter.current.OpenUI<GameUI>("GameUI");
            gameUIOpen = true;
        }
        else
        {
            UICenter.current.CloseUI<GameUI>(m_gameUI.idName);
            gameUIOpen = false;
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



    //第几张图片去掉
    public void ChangeBackGround(int num)
    {
        BackGroundList[num].DOFade(1, 0.5f);

    }
}
