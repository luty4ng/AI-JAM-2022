using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using GameKit;
using System.Linq;
using UnityEngine.Events;

public class UI_DialogResponse : UIGroup
{
    public UI_Selector selector;
    public List<UI_DialogOption> ui_options = new List<UI_DialogOption>();
    private List<Option> currentOptions = new List<Option>();
    private VerticalLayoutGroup verticalLayoutGroup;
    private Sequence selectorSeq;
    private int currentIndex = 0;
    private float animDistance = 0;
    private Vector2 selectorInitPos = Vector2.zero;
    private Animator animator;

    public int CurIndex
    {
        get
        {
            return currentIndex;
        }
    }
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        verticalLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>();
        ui_options = GetComponentsInChildren<UI_DialogOption>(true).ToList();
        selectorSeq = DOTween.Sequence();
        for (int i = 0; i < ui_options.Count; i++)
            ui_options[i].OnInit(this);

        selectorInitPos = selector.rectTransform.anchoredPosition = ui_options.First().rectTransform.anchoredPosition;
        animDistance = verticalLayoutGroup.spacing + ui_options.First().rectTransform.sizeDelta.y;
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        if (!IsActive)
            return;

        foreach (var ui_option in ui_options)
            ui_option.OnTick();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex = (currentIndex + 1) % currentOptions.Count;
            MoveSelector(currentIndex);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex = currentIndex - 1 == -1 ? currentOptions.Count - 1 : currentIndex - 1;
            MoveSelector(currentIndex);
        }
    }

    public override void Show(UnityAction callback = null)
    {
        base.Show(callback);
        animator.SetTrigger("FadeIn");
        animator.OnComplete(callback: callback);
        currentIndex = 0;
        selectorInitPos = selector.rectTransform.anchoredPosition = ui_options.First().rectTransform.anchoredPosition;
        for (int i = 0; i < currentOptions.Count; i++)
        {
            if (i >= ui_options.Count)
            {
                Debug.LogWarning("Too many options.");
                continue;
            }
            ui_options[i].OnReEnable(i);
            ui_options[i].gameObject.SetActive(true);
            ui_options[i].content.text = currentOptions[i].text;
        }
    }

    public override void Hide(UnityAction callback = null)
    {
        base.Hide(callback);
        animator.SetTrigger("FadeOut");
        animator.OnComplete(callback: callback);
        currentOptions.Clear();
        // foreach (var ui_option in ui_options)
        // {
        //     ui_option.gameObject.SetActive(false);
        // }
    }

    public void OnOptionEnter(UI_DialogOption option)
    {
        // currentIndex = option.index;
        // MoveSelector(currentIndex);
    }

    public void OnOptionExit(UI_DialogOption option)
    {

    }

    public void OnOptionDown(UI_DialogOption option)
    {

    }

    private void MoveSelector(int index)
    {
        selectorSeq.Kill();
        selectorSeq.Append(selector.rectTransform.DOAnchorPosY(selectorInitPos.y - animDistance * index, 0.1f));
    }

    public void UpdateOptions(List<Option> options) => currentOptions = options;

}
