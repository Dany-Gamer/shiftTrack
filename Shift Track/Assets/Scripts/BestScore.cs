using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    Text txt;
    Score gameScore;
    int finalScore;
    static int bestScore = 0;
    void Start()
    {
        txt = GetComponent<Text>();
        gameScore = FindObjectOfType<Score>();
    }

    void Update()
    {
        finalScore = gameScore.GetScore();

        if (finalScore > bestScore)
        {
            bestScore = finalScore;
        }

        txt.text = bestScore.ToString();
    }
}
