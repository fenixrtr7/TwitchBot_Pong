using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalZone : MonoBehaviour
{
    public GameObject racket;
    public Text scoreText;
    int score;

    private void Awake() {
        score = 0;
        scoreText.text = score.ToString();

        //scoreText.color = racket.GetComponent<SpriteRenderer>().color;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ball"))
        {
            score++;
            scoreText.text = score.ToString();

            GameManager.sharedInstance.GoalScored();
        }
    }
}
