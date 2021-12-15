using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour
{
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);  // Adds a listener on the button
    }

    void TaskOnClick()
    {
        this.transform.parent.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.transform.parent.transform.parent.gameObject.active)
        //{
          //  GameManager.IsInputEnabled = false; //disable all inputs
        //}
    }
}
