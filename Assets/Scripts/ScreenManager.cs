using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class ScreenManager : MonoBehaviour
{
    public GameObject settingScreen;
    public bool isSettingScreenActive;

    public GameObject helpScreen;
    public bool isHelpScreenActive;
    
    public void ToggleSettingsScreen()
    {
        if (!isSettingScreenActive)
        {
            Debug.Log("Opening Settings Screen");
            settingScreen.SetActive(true);
            isSettingScreenActive = true;
        }
        else
        {
            Debug.Log("Closing Settings Screen");
            settingScreen.SetActive(false);
            isSettingScreenActive = false;
        }
    }
    public void ToggleHelpScreen()
    {
        if (!isHelpScreenActive)
        {
            Debug.Log("Opening Help Screen");
            helpScreen.SetActive(true);
            isHelpScreenActive = true;
        }
        else
        {
            Debug.Log("Closing Help Screen");
            helpScreen.SetActive(false);
            isHelpScreenActive = false;
        }
    }

   
}