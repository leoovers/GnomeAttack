using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LanguageManager
{

    // 0 = English, 1 = German, 2 = Russian, 3 = Dutch, 4 = Kazach, 5 = Spanish, 6 = French, 7 = Finnish,
    public static int langIndex = PlayerPrefs.GetInt("lang", 0);
}

