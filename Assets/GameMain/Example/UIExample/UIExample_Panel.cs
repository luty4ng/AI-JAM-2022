using UnityEngine;
using GameKit;
using DG.Tweening;
using UnityEngine.Events;

public class UIExample_Panel : UIGroup
{
    public void Confirm()
    {
        Debug.Log("Confirm Open UIExample");
    }

    public override void Show(UnityAction callback = null)
    {
        // 淡入打开面板
        panelCanvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public override void Hide(UnityAction callback = null)
    {
        panelCanvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }


}