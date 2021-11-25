using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioClip menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlayBackGround(menuMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
