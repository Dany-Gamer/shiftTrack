using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    Toggle soundToggle;
    void Start()
    {
        soundToggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (soundToggle.isOn == true)
        {
            FindObjectOfType<PlaySound>().MusteSoundAudio();
        }

        else
        {
            FindObjectOfType<PlaySound>().UnMuteSoundAudio();
        }
    }
}
