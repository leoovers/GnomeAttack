using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    private GameObject launchBtn;
    private GameObject menuBtn;
    private GameObject objBg;

    // Start is called before the first frame update
    void Start()
    {
        launchBtn = GameObject.Find("LaunchButton");
        menuBtn = GameObject.Find("PauseButton");
        objBg = GameObject.Find("WoodSignDescription");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            launchBtn.SetActive(false);
            menuBtn.SetActive(false);
            objBg.SetActive(false);
        }
        else
        {
            launchBtn.SetActive(true);
            menuBtn.SetActive(true);
            objBg.SetActive(true);
        }
    }
}
