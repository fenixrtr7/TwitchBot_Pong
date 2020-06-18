using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int lives = 1;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ball"))
        {
            lives--;
            if(lives <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
