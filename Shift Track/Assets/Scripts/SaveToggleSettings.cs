using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveToggleSettings : MonoBehaviour
{
    static Toggle soundToggle;
    const string checkSoundToggle = "SOUNDACTIVE";

    private void Start()
    {
       
        if ((PlayerPrefs.GetInt(checkSoundToggle) == 1))
        {
            soundToggle.isOn = true;
        }
        else
        {
            soundToggle.isOn = false;
        }
    }

    private void Update()
    {
        SetSound();
    }

   
    private static void SetSound()
    {
        if (soundToggle.isOn == true)
        {
            PlayerPrefs.SetInt(checkSoundToggle, 1);
        }
        else
        {
            PlayerPrefs.SetInt(checkSoundToggle, 0);
        }

    }

}
