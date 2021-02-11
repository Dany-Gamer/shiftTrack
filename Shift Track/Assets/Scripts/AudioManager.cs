using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioListener list;
    void Start()
    {
        list = FindObjectOfType<AudioListener>();
    }

    public void ManageSound()
    {
        list.enabled = false;
    }

    
}
