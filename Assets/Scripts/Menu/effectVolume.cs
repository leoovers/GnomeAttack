using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectVolume : MonoBehaviour
{
    private Slider fxSlider;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.fxVolume = PlayerPrefs.GetFloat("fxVolume", 0.5f);
        fxSlider = GetComponent<Slider>();
        fxSlider.onValueChanged.AddListener(delegate { effectVolumeUpdate(); });
        fxSlider.value = SoundManager.fxVolume;
    }

    void effectVolumeUpdate()
    {
        SoundManager.fxVolume = fxSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
