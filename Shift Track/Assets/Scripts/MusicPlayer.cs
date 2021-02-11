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
        SetUpSingelton();
    }

    private void SetUpSingelton()
    {
        int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numberOfMusicPlayers> 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void MusteMusicAudio()
    {
        audioSrc.mute = true;
    }

    public void UnMuteMusicAudio()
    {
        audioSrc.mute = false;
    }

}
