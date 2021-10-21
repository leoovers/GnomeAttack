using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsVolumeSlider : MonoBehaviour
{
    public float effectsVolume = 0.5f;
    private Slider effectsVolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        effectsVolumeSlider = GetComponent<Slider>();
        effectsVolumeSlider.onValueChanged.AddListener(delegate { effectsUpdate(); });
        effectsVolumeSlider.value = effectsVolume;
    }

    void effectsUpdate()
    {
        effectsVolume = effectsVolumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
