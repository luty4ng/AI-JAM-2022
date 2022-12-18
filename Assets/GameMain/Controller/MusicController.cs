using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using GameKit;
using System;

public class MusicController : MonoSingletonBase<MusicController>
{
 
    public AudioMixer audioMixer;    // ���п��Ƶ�Mixer����

    

    internal void ChangeBGMSoundValue(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
        // MasterVolumeΪ���Ǳ�¶������Master�Ĳ���
    }
}
