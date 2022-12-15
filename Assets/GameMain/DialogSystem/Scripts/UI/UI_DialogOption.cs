using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameKit;
using UnityEngine.EventSystems;

//�����ѡ���
public class UI_DialogOption : UIForm, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //�ı�����
    public TextMeshProUGUI content;
    public int index = 0;
    private Button button;
    //ѡ������
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