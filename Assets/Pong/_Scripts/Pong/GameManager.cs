using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance = null;
    public bool gameStarted = false;

    public Text title;
    public Button button;
    GameObject ball;
    Vector2 nextDirection;

    // Start is called before the first frame update
    void Start()
    {
        if( sharedInstance == null)
        {
            sharedInstance = this;
        }
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void StartGame()
    {
        gameStarted = true;
        button.gameObject.SetActive(false);
        title.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoalScored()
    {
        ball.GetComponent<TrailRenderer>().enabled = false;
        ball.transform.position = Vector2.zero;
        nextDirection = new Vector2(-ball.GetComponent<Rigidbody2D>().velocity.x, 0);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        
        Invoke("LaunchBall", 3f);
    }

    void LaunchBall()
    {
        ball.GetComponent<TrailRenderer>().enabled = true;
        Ball b = ball.GetComponent<Ball>();
        ball.GetComponent<Rigidbody2D>().velocity = nextDirection.normalized * b.speed;
    }
}
