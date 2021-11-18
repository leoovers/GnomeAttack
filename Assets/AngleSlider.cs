using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleSlider : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Slider angleSlider;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            angleSlider.interactable = false;
        }

        angleSlider = GetComponent<Slider>();
        angleSlider.onValueChanged.AddListener(delegate { angleUpdate(); });
        angleSlider.value = mainScript.angle;
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);
    }

    void angleUpdate()
    {
        mainScript.angle = angleSlider.value;
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angleSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
