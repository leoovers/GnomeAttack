using System;
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

    public static void PlayOnLoop(AudioClip clip)
    {
        GameObject soundGameObject = new GameObject("SoundLoop");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = ambientVolume;
        audioSource.loop = true;
        audioSource.Play();
    }

    public static void PlayRandom(AudioClip[] list)
    {
        System.Random rnd = new System.Random();
        int rand = rnd.Next(0, list.Length);
        PlaySound(list[rand]);
    }
}
