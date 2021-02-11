using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    PlaySound playSound;
    Score gameScore;

    private void Start()
    {
        playSound = FindObjectOfType<PlaySound>();
        gameScore = FindObjectOfType<Score>();

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadPlayScreen()
    {
        SceneManager.LoadScene(0);
        playSound.ButtonSound();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        playSound.ButtonSound();
        FindObjectOfType<Score>().Reset();
    }

    IEnumerator WaitAndLoad()
    {
        playSound.PlayTimeOverSound();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

}