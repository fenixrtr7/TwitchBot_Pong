using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 25f;
    bool hasTheBallMoved = false;
    // Start is called before the first frame update
    void Update()
    {
        if (GameManager.sharedInstance.gameStarted == true && hasTheBallMoved == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            hasTheBallMoved = true;
        }

        if (GameManager.sharedInstance.gameStarted)
        {
            string racketName = (GetComponent<Rigidbody2D>().velocity.x > 0 ? "Racket Left" : "Racket Right");
            GameObject racket = GameObject.Find(racketName);
            GetComponent<SpriteRenderer>().color = racket.GetComponent<SpriteRenderer>().color;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Racket Left")
        {
            float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);

            Vector2 direction = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (other.gameObject.name == "Racket Right")
        {
            float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);

            Vector2 direction = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float raquetHeight)
    {
        return (ballPosition.y - racketPosition.y) / raquetHeight;
    }
}
