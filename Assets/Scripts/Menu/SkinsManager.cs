using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsManager : MonoBehaviour
{

    [SerializeField]
    int numberOfArmSkins;
    [SerializeField]
    int numberOfLegSkins;
    [SerializeField]
    int numberOfGnomeSkins;
    [SerializeField]
    int numberOfDifferentSkinTypes;

    private List<int> armSkinValues = new List<int>();
    private List<int> legSkinValues = new List<int>();
    private List<int> gnomeSkinValues = new List<int>();

    int[] currentSkins = {0,0,0};
    

    private void Awake() {
        Debug.Log("WUUU");
        initializeSkins();
        Debug.Log(armSkinValues[1]);
        currentSkins[0] = PlayerPrefs.GetInt("currentArmSkinID", 0);
        currentSkins[1] = PlayerPrefs.GetInt("currentLegSkinID", 0);
        currentSkins[2] = PlayerPrefs.GetInt("currentGnomeSkinID", 0);
        Debug.Log("Current Skins" + currentSkins);
    }

    private void initializeSkins() {
        for (int i = 0; i < numberOfArmSkins; i++)
        {
            armSkinValues.Add(((30 / (numberOfArmSkins - 1)) * i));
        }

        for (int i = 0; i < numberOfLegSkins; i++)
        {
            legSkinValues.Add((30 / (numberOfLegSkins - 1)) * i);
        }

        for (int i = 0; i < numberOfGnomeSkins; i++)
        {
            if (numberOfGnomeSkins > 1)
            legSkinValues.Add((30 / (numberOfGnomeSkins - 1)) * i);
            else legSkinValues.Add(0);
        }
    }

    public int[] GetSkins() {
        return currentSkins;
    }
    
    public int[] GetSkinValues() {
        int[] skinValues = new int[numberOfDifferentSkinTypes];
        Debug.Log("skinvalues" + skinValues);
        skinValues[0] = armSkinValues[currentSkins[0]];
        skinValues[1] = legSkinValues[currentSkins[1]];
        skinValues[2] = legSkinValues[currentSkins[2]];
        return skinValues;
    }

    public void SetSkins(int[] skins) {
        currentSkins = skins;
        PlayerPrefs.SetInt("currentArmSkinID", skins[0]);
        PlayerPrefs.SetInt("currentLegSkinID", skins[1]);
        PlayerPrefs.SetInt("currentGnomeSkinID", skins[2]);
    }
}
