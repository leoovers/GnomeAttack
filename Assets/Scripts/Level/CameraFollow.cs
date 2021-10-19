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
    public bool shaking = false;

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

        if (!toggleFreeLook & !shaking)
        {
            moveCamera.gameObject.SetActive(false);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(followTransform.position.x + xOffset,
            followTransform.position.y + yOffset, -10), ref velocity, smoothTime);
        }
        else
        {
            if (toggleFreeLook)
            {
                moveCamera.gameObject.SetActive(true);
                this.transform.position = new Vector3(cameraXvalue,
                followTransform.position.y + yOffset, this.transform.position.z);
            }

        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        shaking = true;
        Debug.Log("Shaking");
        Vector3 originalPos = transform.position;
        
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xShakeOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yShakeOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.position = new Vector3(xShakeOffset, yShakeOffset, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        shaking = false;
        transform.position = Vector3.SmoothDamp(transform.position, originalPos, ref velocity, smoothTime);
    }
}
