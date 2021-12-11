using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LanguageManager
{
    // 0 = English, 1 = German, 2 = Russian, 3 = dutch, 4 = kazach, 5 = spanish
    public static int langIndex = PlayerPrefs.GetInt("lang", 0);
}

