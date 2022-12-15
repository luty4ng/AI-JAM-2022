using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class SceneController: MonoBehaviour
{
    public GameObject ctnBtn;
    public string LastScene;
    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (LastScene == null) 
        {
            ctnBtn.SetActive(false);
        }
    }
    public void GoToScene(string name)
    {
        Scheduler.current.SwitchSceneByDefault(name, () =>
        {
            Debug.Log(string.Format("����{0}�л����", name));
        });
    }

    public void GoToLastScene() 
    {
        Scheduler.current.SwitchSceneByDefault(LastScene);
    }
}
