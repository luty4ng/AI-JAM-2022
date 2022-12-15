using UnityEngine;
using UnityEngine.UI;
using GameKit;
using UnityEngine.EventSystems;

namespace Assets.GameMain.DialogSystem.Scripts.UI
{
    public class UI_CharacterPic : UIForm 
    {
        public Image characterPic;
        public void OnInit()
        {
            characterPic = GetComponentInChildren<Image>();
            this.gameObject.SetActive(false);

        }
    }
}