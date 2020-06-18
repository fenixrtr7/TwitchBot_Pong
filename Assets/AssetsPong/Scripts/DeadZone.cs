using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText;
    public Text scoreEnemyText;

    int scorePlayerQuantity;
    int scoreEnemyQuantity;

    SceneChanger sceneChanger;
    public AudioSource deadAudio;

    private void Awake() {
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    private void OnTriggerEnter2D(Collider2D ball)
    {
        if (gameObject.CompareTag("Izquierdo"))
        {
            scoreEnemyQuantity++;
            deadAudio.Play();
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
        }
        else if (gameObject.CompareTag("Derecho"))
        {
            scorePlayerQuantity++;
            deadAudio.Play();
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }
        ball.GetComponent<BowlBehaviour>().gameStarted = false;
        CheckScore();
    }

    void CheckScore()
    {
        if (scorePlayerQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("SceneWin");
        }
        else if (scoreEnemyQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("SceneLose");
        }
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
        
    }
    
}
