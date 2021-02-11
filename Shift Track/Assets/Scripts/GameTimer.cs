using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    Text timeText;
    int secondsLeft = 60;
    bool timeRunning = false;


    void Start()
    {
        timeText = GetComponent<Text>();
        timeText.text = secondsLeft + " :00";

    }

    void Update()
    {
        if (timeRunning == false && secondsLeft > 0)
        {
            StartCoroutine(RunTimer());
        }

        if(secondsLeft < 1)
        {
            FindObjectOfType<LevelLoader>().LoadGameOver();

        }
    }

    IEnumerator RunTimer()
    {
        timeRunning = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

        if (secondsLeft < 10)
        {
            timeText.text = "00:0" + secondsLeft;
        }

        else
        {
            timeText.text = "00:" + secondsLeft;
        }

        timeRunning = false;
    }

    public void SubtractFromTime(int sub)
    {
        secondsLeft -= sub;
    }

    public int GetTime()
    {
        return secondsLeft;
    }

}
