using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameKit;

public class MusicController : MonoSingletonBase<MusicController>
{

    public AudioSource alarmBGM;

    protected override void OnAwake()
    {
        
    }

    void Start()
    {
        //设置声音为循环播放 
        alarmBGM.loop = true;
    }
    
    void Update()
    {
        //声音播放
        if (Input.GetKeyDown(KeyCode.E))
            alarmBGM.Play();
        if (Input.GetKeyDown(KeyCode.R))
            alarmBGM.Stop();
    }

    public void BGMstart()
    {
        alarmBGM.Play();
    }   
    public void BGMstop()
    {
        alarmBGM.Stop();
    }

    public void ChangeBGMSoundValue(float value)
    {
        alarmBGM.volume = value;
    }


}
