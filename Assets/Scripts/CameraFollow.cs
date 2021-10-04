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
    public float xOffset;
    public float yOffset;
    private Slider moveCameraSlider;
    public float smoothTime = 0.01F;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        moveCameraSlider = moveCamera.GetComponent<Slider>();
        moveCameraSlider.onValueChanged.AddListener(delegate { cameraUpdate(); });

        toggleFreeLook = false;
        xOffset = 6;
        yOffset = 1.5f;
    }

    void cameraUpdate()
    {
        cameraXvalue = moveCameraSlider.value;
    }
    // Update is called once per frame
    
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggleFreeLook = !toggleFreeLook;
        }

        if (!toggleFreeLook){
            moveCamera.gameObject.SetActive(false);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(followTransform.position.x + xOffset, followTransform.position.y + yOffset, -10), ref velocity, smoothTime);
        }
        else{
            moveCamera.gameObject.SetActive(true);
            this.transform.position = new Vector3(cameraXvalue,
            followTransform.position.y + yOffset, this.transform.position.z);
        }
    }
}
