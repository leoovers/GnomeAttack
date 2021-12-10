using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public AudioClip levelMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlayOnLoop(levelMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
