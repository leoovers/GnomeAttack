using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangDropDown : MonoBehaviour
{
    private Dropdown dropDown;

    // Start is called before the first frame update
    void Start()
    {
        dropDown = GetComponent<Dropdown>();
        dropDown.onValueChanged.AddListener(delegate {dropdownValueChangedHandler(dropDown); });
        LanguageManager.langIndex = dropDown.value;
    }

    private void dropdownValueChangedHandler(Dropdown target)
    {
        LanguageManager.langIndex = dropDown.value;
        PlayerPrefs.SetInt("lang", dropDown.value);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
