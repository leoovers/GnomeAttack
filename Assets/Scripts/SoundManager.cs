using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static float fxVolume = 0.5F;
    public static float ambientVolume = 0.2F;
    
    public static void PlaySound(AudioClip audioClip) 
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip, fxVolume);
    }

    public static void PlayBackGround(AudioClip audioClip)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.PlayOneShot(audioClip, ambientVolume);
    }
}
