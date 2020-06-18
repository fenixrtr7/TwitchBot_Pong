using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArkanoidHUD : MonoBehaviour
{
    public Image life1, life2, life3;
    public Text gameOverText, winText, timeText, highScoreText;
    bool hasTheGameEnded = false;

    float gameTime = 0f;
    BallArkanoid ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<BallArkanoid>();
        highScoreText.text = "Best: " + PlayerPrefs.GetFloat ("highscore", 9999).ToString("N2");
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTheGameEnded)
        {
            return;
        }
        gameTime += Time.deltaTime;
        timeText.text = gameTime.ToString("N2");

        if(ball.lives < 3)
        {
            life3.enabled = false;
        }
        if (ball.lives < 2)
        {
            life2.enabled = false;
        }
        if(ball.lives < 1)
        {
            life1.enabled = false;
            gameOverText.enabled = true;
            Invoke("GoToMainMenu", 2f);
            hasTheGameEnded = true;
        }
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if(blocks.Length == 0)
        {
            winText.enabled = true;
            Invoke("GoToMainMenu", 2f);
            hasTheGameEnded = true;

            float highScore = PlayerPrefs.GetFloat("highscore",9999);
            if(gameTime < highScore)
            {
                PlayerPrefs.SetFloat("highscore", gameTime);
            }
        }
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
