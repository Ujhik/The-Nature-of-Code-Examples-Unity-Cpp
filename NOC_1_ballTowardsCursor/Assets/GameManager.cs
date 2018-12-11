using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Ball ball;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;


    // Use this for initialization
    void Start () {

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));



        //Create ball
        Instantiate(ball);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
} 
