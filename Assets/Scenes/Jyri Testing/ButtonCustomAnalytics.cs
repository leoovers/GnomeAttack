using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ButtonCustomAnalytics : MonoBehaviour
{
    public void TestButtonPressed() {
        //if (ENABLE_CLOUD_SERVICES_ANALYTICS) 
        Analytics.CustomEvent("TestButtonPressed");        
    }
}
