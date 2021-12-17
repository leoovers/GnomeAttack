using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework;
public class SkinsMenu : MonoBehaviour
{
    [SerializeField]
    GameObject menuCatapult;
    
    GameObject skinsManager;
    SkinsManager sm;
    CubismParameterStore cps;
    int[] currentSkins;
    int[] currentSkinValues;

    private void Start() {
        skinsManager = GameObject.Find("SkinsManager");
        sm = skinsManager.GetComponent<SkinsManager>();
        currentSkins = sm.GetSkins();
        currentSkinValues = sm.GetSkinValues();
        cps = menuCatapult.GetComponent<CubismParameterStore>();
        InitializeMenuCatapult();
    }

    private void InitializeMenuCatapult() {
        Debug.Log("YOYOYOOY" + cps.DestinationParameters);

    }
}
