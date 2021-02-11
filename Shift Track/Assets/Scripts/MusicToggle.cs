using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    Toggle musicToggle;
    void Start()
    {
        musicToggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (musicToggle.isOn == true)
        {
            FindObjectOfType<MusicPlayer>().MusteMusicAudio();
        }

        else
        {
            FindObjectOfType<MusicPlayer>().UnMuteMusicAudio();
        }
    }
}
