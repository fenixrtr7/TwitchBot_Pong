﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         transform.position = new Vector3(transform.position.x, Mathf.Clamp(mousePos.y, -3.7f, 3.7f), transform.position.z);
    }
}
