using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static float fxVolume = 0.5F;
    
    public static void PlaySound(AudioClip audioClip) 
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip, fxVolume);
    }
}
