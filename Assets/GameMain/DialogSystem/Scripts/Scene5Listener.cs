using System.Collections;
using UnityEngine;
using GameKit;

namespace Assets.GameMain.DialogSystem.Scripts
{
    public class Scene5Listener : MonoBehaviour
    {
        public void Start()
        {
            EventManager.instance.AddEventListener<string>(EventSettings.DIALOG_END,(string  str)=>
            {
                Debug.Log(str);
            });
        }

    }
}