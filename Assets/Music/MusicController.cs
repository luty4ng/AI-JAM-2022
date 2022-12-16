using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameKit;

public class MusicController : MonoSingletonBase<MusicController>
{

    public AudioSource alarmBGM;
    
    void Start()
    {
        //��������Ϊѭ������ 
        alarmBGM.loop = true;
    }
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    
    void Update()
    {
        //��������
        if (Input.GetKeyDown(KeyCode.E))
            alarmBGM.Play();
        if (Input.GetKeyDown(KeyCode.R))
            alarmBGM.Stop();

        //�����Ƿ����ڲ���
        //if (alarmBGM.isPlaying)
        //    print("�������ڲ���");
    }

    public void BGMstart()
    {
        alarmBGM.Play();
    }   
    public void BGMstop()
    {
        alarmBGM.Stop();
    }


}
