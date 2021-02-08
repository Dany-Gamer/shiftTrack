using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [Header("Swipe Sound")]

    [SerializeField] AudioClip swipeSound;
    [SerializeField] [Range(0, 1)] float swipeSoundVolume = 0.5f;

    [Header("Buton Sound")]

    [SerializeField] AudioClip btnSound;
    [SerializeField] [Range(0, 1)] float btnSoundVolume = 0.5f;

    [Header("Score Sound")]

    [SerializeField] AudioClip scoreSound;
    [SerializeField] [Range(0, 1)] float scoreSoundVolume = 0.5f;

    [Header("TimeOver Sound")]

    [SerializeField] AudioClip timeOverSound;
    [SerializeField] [Range(0, 1)] float timeOverSoundVolume = 0.5f;

    public void PlaySwipeSound()
    {
    }

    public void PlayButtonSound()
    {
        AudioSource.PlayClipAtPoint(btnSound, Camera.main.transform.position, btnSoundVolume);

    }

    public void PlayScoreSound()
    {
        AudioSource.PlayClipAtPoint(scoreSound, Camera.main.transform.position, scoreSoundVolume);

    }

    public void PlayTimeOverSound()
    {
        AudioSource.PlayClipAtPoint(timeOverSound, Camera.main.transform.position, timeOverSoundVolume);

    }


}
