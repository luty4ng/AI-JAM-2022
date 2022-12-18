using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using GameKit;
using System;

public class MusicController : MonoSingletonBase<MusicController>
{
 
    public AudioMixer audioMixer;    // 进行控制的Mixer变量

    

    internal void ChangeBGMSoundValue(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
        // MasterVolume为我们暴露出来的Master的参数
    }
}
