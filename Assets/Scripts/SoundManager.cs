using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static float fxVolume = 0.5F;
    public static float ambientVolume = 0.2F;
    public static AudioSource loopSrc;
    
    public static void PlaySound(AudioClip audioClip) 
    {
        // Take an audio clip as argument, play it once

        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip, fxVolume);
    }

    public static void PlayOnLoop(AudioClip clip)
    {
        // Take an audio clip as argument, play it on loop

        GameObject soundGameObject = new GameObject("SoundLoop");
        loopSrc = soundGameObject.AddComponent<AudioSource>();
        loopSrc.clip = clip;
        loopSrc.volume = ambientVolume;
        loopSrc.loop = true;
        loopSrc.Play();
    }

    public static void PlayRandom(AudioClip[] list)
    {
        // Take a list of audio clips as argument, play a random clip once

        System.Random rnd = new System.Random();
        int rand = rnd.Next(0, list.Length);
        PlaySound(list[rand]);
    }
}
