using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameKit;

public class MusicController : MonoSingletonBase<MusicController>
{

    public AudioSource alarmBGM;
    
    void Start()
    {
        //设置声音为循环播放 
        alarmBGM.loop = true;
    }
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    
    void Update()
    {
        //声音播放
        if (Input.GetKeyDown(KeyCode.E))
            alarmBGM.Play();
        if (Input.GetKeyDown(KeyCode.R))
            alarmBGM.Stop();

        //声音是否正在播放
        //if (alarmBGM.isPlaying)
        //    print("音乐正在播放");
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
