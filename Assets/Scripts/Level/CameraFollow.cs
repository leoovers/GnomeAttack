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
    public bool shaking = false;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        xOffset = 9;
        yOffset = 2.0f;
        smoothTime = 1.7f;

        // ViewDistance("Level_1", 9.0f);
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
    }
    
    void FixedUpdate()
    {   
        if (!shaking)
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
