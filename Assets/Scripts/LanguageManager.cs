using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LanguageManager
{
    // 0 = English, 1 = German, 2 = Russian
    public static int langIndex = PlayerPrefs.GetInt("lang", 0);
}

