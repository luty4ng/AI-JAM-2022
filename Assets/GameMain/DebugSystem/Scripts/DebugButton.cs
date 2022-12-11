using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DebugButton : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button button;
    public void AddListener(UnityAction call)
    {
        button.onClick.AddListener(call);
    }

    public void ClearListener()
    {
        button.onClick.RemoveAllListeners();
    }
}