using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameKit;
using UnityEngine.EventSystems;

//这个是选项本身
public class UI_DialogOption : UIForm, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //文本内容
    public TextMeshProUGUI content;
    public int index = 0;
    private Button button;
    //选项内容
    public UI_DialogResponse response;

    public void OnInit(UI_DialogResponse response)
    {
        this.response = response;
        content = GetComponentInChildren<TextMeshProUGUI>();
        this.gameObject.SetActive(false);
    }
    public void OnReEnable(int index)
    {
        this.index = index;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        response.OnOptionDown(this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        response.OnOptionEnter(this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        response.OnOptionExit(this);
    }
}