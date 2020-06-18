﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<BallArkanoid>().ResetBall();
            GetComponent<AudioSource>().Play();
        }
    }
}
