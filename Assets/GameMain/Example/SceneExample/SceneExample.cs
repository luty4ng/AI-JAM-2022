using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class SceneExample : MonoBehaviour
{
    public void GoToScene(string name)
    {
        Scheduler.current.SwitchSceneByDefault(name, () =>
        {
            Debug.Log(string.Format("场景{0}切换完毕", name));
        });
    }
}
