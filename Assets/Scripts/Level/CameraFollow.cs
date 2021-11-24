using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Catapult_physics mainScript;
    public Transform followTransform;
    public GameObject goal;
    public float xOffset;
    public float yOffset;
    public float smoothTime;
    public float speed = 0.01F;
    public bool shaking = false;

    [SerializeField]
    private GameObject cameraBorder;
    [SerializeField]
    private GameObject angleSlider;
    private Slider slider;

    [SerializeField]
    private bool disableCameraScroll = false;
    private Vector3 velocity = Vector3.zero;
    private bool moving = false;
    private float maxValueX;
    private float minValueX;
    private float maxValueY;
    private float minValueY;

    void Start()
    {
        xOffset = 9;
        yOffset = 2.0f;
        smoothTime = 1.2f;

        ViewDistance("Level_9", 10.0f);
        ViewDistance("Level_11", 10.0f);
        ViewDistance("Level_12", 10.0f);
        ViewDistance("Level_13", 10.0f);
        ViewDistance("Level_20", 10.0f);
        ViewDistance("Level_23", 10.0f);
        ViewDistance("Level_25", 15.0f);
        ViewDistance("Level_30", 15.0f);

        cameraBorder = GameObject.Find("CameraBorder");
        angleSlider = GameObject.Find("AngleSlider");
        slider = angleSlider.GetComponent<Slider>();

        maxValueX = cameraBorder.transform.position.x + cameraBorder.transform.localScale.x / 2;
        minValueX = cameraBorder.transform.position.x - cameraBorder.transform.localScale.x / 2;
        maxValueY = cameraBorder.transform.position.y + cameraBorder.transform.localScale.y / 2;
        minValueY = cameraBorder.transform.position.y - cameraBorder.transform.localScale.y / 2;
 
    }

    void ViewDistance(string levelName, float ortSize)
    {
        // Set camera distance per level

        Camera mainCamera = GetComponent<Camera>();
        mainCamera.orthographic = true;
        Scene currScene = SceneManager.GetActiveScene();
        string currSceneName = currScene.name;

        // Add a clause to change camera view distance in a specific level
        if (currSceneName == levelName)
        
        {
            mainCamera.orthographicSize = ortSize;
        }
        else
        {
            mainCamera.orthographicSize = 7.0f;
        }
    }

    public void smoothToTarget(Vector3 target)
    {
        this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(target.x + xOffset,
        target.y + yOffset, -10), ref velocity, smoothTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            followTransform = goal.transform;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            followTransform = mainScript.newGnome.transform;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchStartPos = touch.position;
            if (touchStartPos.x > Screen.width / 2)
            {
                Debug.Log("right side");
                slider.interactable = false;
            }
            if (touchStartPos.x < Screen.width / 2)
            {
                Debug.Log("left side");
                Debug.Log("width=" + Screen.width);
                Debug.Log("touchposX=" + touchStartPos.x);
                disableCameraScroll = true;
            }

        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (!disableCameraScroll)
            {
                moving = true;
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(-touchDeltaPosition.x * (Time.deltaTime * 2), -touchDeltaPosition.y * (Time.deltaTime * 2), 0);
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            moving = false;
            disableCameraScroll = false;
            slider.interactable = true;
        }
        if (this.transform.position.x > maxValueX)
        {
            this.transform.position = new Vector3(maxValueX, this.transform.position.y, -10);
        }
        if (this.transform.position.x < minValueX)
        {
            this.transform.position = new Vector3(minValueX, this.transform.position.y, -10);
        }
        if (this.transform.position.y > maxValueY)
        {
            this.transform.position = new Vector3(this.transform.position.x, maxValueY, -10);
        }
        if (this.transform.position.y < minValueY)
        {
            this.transform.position = new Vector3(this.transform.position.x, minValueY, -10);
        }
    }
    
    void FixedUpdate()
    {   
        if (!shaking & !moving)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(followTransform.position.x + xOffset,
            followTransform.position.y + yOffset, -10), ref velocity, smoothTime); 
        }
        
        if (mainScript.launched)
        {
            xOffset = 3;  // Center the camera a bit on launch
            smoothTime = 0.3f;
        }
        else
        {
            xOffset = 6;
        }

        if (!mainScript.launched)
        {
            xOffset = 6;
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        shaking = true;
        Debug.Log("Camera shaking");
        Vector3 originalPos = transform.position;
        
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xShakeOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yShakeOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.position = new Vector3(originalPos.x + xShakeOffset, originalPos.y + yShakeOffset, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        shaking = false;
        transform.position = Vector3.SmoothDamp(transform.position, originalPos, ref velocity, smoothTime);
    }
}
