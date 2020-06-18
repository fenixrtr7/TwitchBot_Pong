using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    public GameObject ballStartPosition;
    public float speed = 25f;
    public int lives = 3;
    [SerializeField]
    [Range(1.0f, 2.0f)]
    public float difficultyFactor = 1.005f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        StartCoroutine(UpgradeDifficulty());
    }

    IEnumerator UpgradeDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            speed *= difficultyFactor;   
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().Play();
        if (other.gameObject.CompareTag("Player"))
        {
            float x = hitFactor(this.transform.position, other.transform.position, other.collider.bounds.size.x);
            Vector2 direction = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    float hitFactor(Vector2 ball, Vector2 paddle, float paddleWidth)
    {
        return (ball.x - paddle.x) / paddleWidth;
    }

    public void ResetBall()
    {
        lives--;
        speed = 10;
        transform.position = ballStartPosition.transform.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if(lives > 0)
        {
            Invoke("RestartBallMovement", 2f);
        }
    }

    void RestartBallMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
    
}
