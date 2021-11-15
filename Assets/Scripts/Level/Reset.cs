using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button resetButton = GetComponent<Button>();
        resetButton.onClick.AddListener(TaskOnClick_reset);
    }

    void TaskOnClick_reset(){
		Debug.Log ("You have clicked the reset button!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Reset"))
        {
            TaskOnClick_reset();
        }
    }
}
