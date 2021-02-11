using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [Header("TimeOver Sound")]
    [SerializeField] AudioClip timeOverSound;

    [Header("Buton Sound")]
    [SerializeField] AudioClip btnSound;

    [Header("Swipe Sound")]
    [SerializeField] AudioClip swipeSound;

    [Header("Score Sound")]
    [SerializeField] AudioClip scoreSound;


    AudioSource audioSrc;

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlayTimeOverSound()
    {
        audioSrc.PlayOneShot(timeOverSound);
    }

    public void ButtonSound()
    {
        audioSrc.PlayOneShot(btnSound);
    }

    public void PlaySwipeSound()
    {
        audioSrc.PlayOneShot(swipeSound);
    }

    public void ScoreSound()
    {
        audioSrc.PlayOneShot(scoreSound);

    }

    public void MusteSoundAudio()
    {
        audioSrc.mute = true;
    }

    public void UnMuteSoundAudio()
    {
        audioSrc.mute = false;
    }


}
