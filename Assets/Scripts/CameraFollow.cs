using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public Slider moveCamera;
    public float cameraXvalue;
    public bool toggleFreeLook;
    private Slider moveCameraSlider;

    void Start()
    {
        moveCameraSlider = moveCamera.GetComponent<Slider>();
        moveCameraSlider.onValueChanged.AddListener(delegate { cameraUpdate(); });

        toggleFreeLook = false;
    }

    void cameraUpdate()
    {
        cameraXvalue = moveCameraSlider.value;
    }
    // Update is called once per frame
    
    void FixedUpdate()
    {   
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggleFreeLook = !toggleFreeLook;
        }

        if (!toggleFreeLook){
            moveCamera.gameObject.SetActive(false);
            this.transform.position = new Vector3(followTransform.position.x + 6,
            followTransform.position.y + 1, this.transform.position.z);
        }
        else{
            moveCamera.gameObject.SetActive(true);
            this.transform.position = new Vector3(cameraXvalue,
            followTransform.position.y + 1, this.transform.position.z);
        }
    }
}
