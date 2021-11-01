using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{
    public Catapult_physics mainScript;
    public float thrust;
    private Slider powerslider;

    // Start is called before the first frame update
    void Start()
    {
        powerslider = GetComponent<Slider>();
        powerslider.onValueChanged.AddListener(delegate { thrustValueUpdate(); }); // Adds a listener on the slider

        mainScript.thrust = 10f;
    }

    void thrustValueUpdate()
    {
        mainScript.thrust = powerslider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainScript.launched)
        {
            powerslider.value = (Mathf.Cos(Time.time * 2.5f) + 1.25f) * 20;  // Add time multiplier to add slider speed
        }
    }
}
