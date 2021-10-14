using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        moveCameraSlider.onValueChanged.AddListener(delegate { cameraUpdate(); });  // Add listener for the slider

        toggleFreeLook = false;
        xOffset = 9;
        yOffset = 2.0f;
        smoothTime = 1.7f;
    }

    void cameraUpdate()
    {
        cameraXvalue = moveCameraSlider.value;  // Move camera along X axis when slider is moved
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggleFreeLook = !toggleFreeLook;
            if (toggleFreeLook)
            {
                moveCamera.Select();
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
            
        }

        if (!toggleFreeLook){
            moveCamera.gameObject.SetActive(false);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(followTransform.position.x + xOffset,
            followTransform.position.y + yOffset, -10), ref velocity, smoothTime);
        }
        else{
            moveCamera.gameObject.SetActive(true);
            this.transform.position = new Vector3(cameraXvalue,
            followTransform.position.y + yOffset, this.transform.position.z);
        }
    }
}
