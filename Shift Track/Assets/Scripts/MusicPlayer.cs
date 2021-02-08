using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSrc;

    void Start()
    {
        DontDestroyOnLoad(this);
        audioSrc = GetComponent<AudioSource>();
    }

}
