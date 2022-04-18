using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MechanicsManager : MonoBehaviour
{

    public float gameTimer = 60;
    public int zombiesKilled = 0;

    public TMP_Text timerText;
    public TMP_Text killedText;
    public TMP_Text resultText;
    public GameObject endScreen;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = "Time Left: " + gameTimer.ToString("F1");
            killedText.text = "Zombies Killed: " + zombiesKilled;
        }
        else
        {
            GameOver(true);
        }

        if(zombiesKilled > 50)
        {
            GameOver(true);
        }
    }

    public void KilledZombie()
    {
        zombiesKilled++;
    }

    public void GameOver(bool win)
    {
        Time.timeScale = 0;
        endScreen.SetActive(true);
        if(win)
        {
            resultText.text = "You Survived! Good Work";
        }
        else
        {
            resultText.text = "Game Over! You Lose";
        }
    }
}
