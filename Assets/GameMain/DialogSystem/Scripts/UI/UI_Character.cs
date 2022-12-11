using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameKit;
using System.Collections.Generic;
using Febucci.UI;

public class UI_Character : UIForm
{
    public Animator animator;
    public Image avatar;
    public override void OnStart()
    {
        animator = GetComponent<Animator>();
        avatar = GetComponent<Image>();
    }
    public void SetSpeaker(Image avatar, Animator animator)
    {
        this.avatar = avatar;
        this.animator = animator;
    }
}