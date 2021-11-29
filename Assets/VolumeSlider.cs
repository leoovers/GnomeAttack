using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.onValueChanged.AddListener(delegate { musicVolumeUpdate(); });
        volumeSlider.value = SoundManager.ambientVolume;
    }

    void musicVolumeUpdate()
    {
        SoundManager.ambientVolume = volumeSlider.value;
        SoundManager.loopSrc.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
