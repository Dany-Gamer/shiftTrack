using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    GameTimer timer;
    int score = 0;
    private int previousScore = 0;

    void Start()
    {
        timer = FindObjectOfType<GameTimer>();
        SetUpSingelton();
    }

    void Update()
    {

        if ((score != previousScore) && ((score % 5) == 0))
        {
            timer.SubtractFromTime(10);
        }

        previousScore = score;

    }

    private void SetUpSingelton()
    {
        int numberOfGameSessions = FindObjectsOfType<Score>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


     public void AddToScore(int add)
    {
        score += add;
    }

    public int  GetScore()
    {
        return score;
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

}
