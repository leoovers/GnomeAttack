using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectVolume : MonoBehaviour
{
    private Slider fxSlider;
    public float fxVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        fxSlider = GetComponent<Slider>();
        fxSlider.onValueChanged.AddListener(delegate { effectVolumeUpdate(); });
        fxSlider.value = fxVolume;
    }

    void effectVolumeUpdate()
    {
        fxVolume = fxSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
