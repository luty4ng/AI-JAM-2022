using UnityEngine;
using GameKit;

public class Gameplay : MonoBehaviour
{
    public int unitAwakenChange = 3;
    public int unitImmersiveChange = 5;
    void Start()
    {
        EventManager.instance.AddEventListener<int>(EventSettings.AWAKEN_CHANGE, OnAwakenChange);

        EventManager.instance.AddEventListener<int>(EventSettings.IMMERSIVE_CHANGE, OnImmersiveChange);
    }

    private void OnImmersiveChange(int immersiveChange)
    {
        // 在这里写Immersive值变化的处理
        if (immersiveChange == 0)
            return;
        Debug.Log(string.Format("Immersive Value {0} {1}", immersiveChange == 1 ? "Increase" : "Decrease", unitImmersiveChange));
    }

    private void OnAwakenChange(int awakenChange)
    {
        // 在这里写Awaken值变化的处理
        if (awakenChange == 0)
            return;
        Debug.Log(string.Format("Awaken Value {0} {1}", awakenChange == 1 ? "Increase" : "Decrease", unitAwakenChange));
    }
}