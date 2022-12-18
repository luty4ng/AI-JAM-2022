using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class hint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("fade", 15f);
    }

    private void fade()
    {
        this.gameObject.GetComponent<Text>().DOFade(0f, 0.5f);
    }


}
