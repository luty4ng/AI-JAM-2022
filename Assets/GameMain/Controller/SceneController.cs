using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class SceneController: MonoSingletonBase<SceneController>
{
    public GameObject continueBtn;
    
    public static int current_SceneID = 0;

    //这个变量的设置单纯是为了在编辑器里能看到具体数字
    public int current_SceneID_cansee = 0;


    public string LastScene;
    protected override void OnAwake()
    {
        base.OnAwake();
        if (LastScene == null) 
        {
            continueBtn.SetActive(false);
        }
    }

    public void Update()
    {
        current_SceneID_cansee = current_SceneID;
    }
    public void GoToSceneByID(int sceneID)
    {
        current_SceneID = sceneID;
        
        Scheduler.current.SwitchSceneByDefault("SceneID_ "+sceneID.ToString(), () =>
        {
            Debug.Log(string.Format("场景SceneID_ {0}切换完毕", sceneID));
        });
    }
    public void GoToScene(string name)
    {
        Scheduler.current.SwitchSceneByDefault(name, () =>
        {
            Debug.Log(string.Format("场景{0}切换完毕", name));
        });
    }
    public void GoToLastScene() 
    {
        Scheduler.current.SwitchSceneByDefault(LastScene);
    }

    public void BackToMenu()
    {
        
        ProcessController.current.currentProcess = ProcessController.Process.isMenu;
        current_SceneID = 0;
        GoToSceneByID(1);
        UICenter.current.CloseUI<GameUI>("GameUI");
        UICenter.current.OpenUI<MenuUI>("MenuUI");
    }
}
