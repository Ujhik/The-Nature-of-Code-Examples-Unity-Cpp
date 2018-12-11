﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Vector2 position;
    [SerializeField] Vector2 speed;
    [SerializeField] Vector2 aceleration;
    [SerializeField] Vector2 topSpeed = new Vector2 (10,10);
    [SerializeField] Vector2 mousePosition;


    float radius;


	// Use this for initialization
	void Start () {
        speed = Vector2.one.normalized; //Initial speed is (1,1) normalized
        
        radius = transform.localScale.x / 2;
	}
	
	// Update is called once per frame
	void Update () {


        position = transform.position;

        //Updating mouse position
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);  //Transforming coordinates from mouse on screen to world

        //Calculating new aceleration
        aceleration = mousePosition - position;
        aceleration = aceleration.normalized;
        aceleration *= 0.5f;

        //Adding aceleration to speed
        speed += aceleration;

        //Limiting the speed
        speed = Vector2.Min(speed, topSpeed);

        //Changing position to aceleration, making it depend on seconds instead of frames
        transform.Translate(speed * Time.deltaTime);

        //Rebound bottom
        if (transform.position.y < GameManager.bottomLeft.y + radius && speed.y < 0)
        {
            speed.y = -speed.y;
        }
        
        //Rebound top
        if (transform.position.y > GameManager.topRight.y - radius && speed.y > 0)
        {
            speed.y = -speed.y;
        }

        //Rebound left
        if (transform.position.x < GameManager.bottomLeft.x + radius && speed.x < 0)
        {
            speed.x = -speed.x;
        }

        //Rebound right
        if (transform.position.x > GameManager.topRight.x - radius && speed.x > 0)
        {
            speed.x = -speed.x;
        }
    }

}
