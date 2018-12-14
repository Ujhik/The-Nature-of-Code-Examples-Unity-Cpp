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
        for(float mass = 0.1f; mass<=2; mass += 0.3f){
            Instantiate(ball).Init(mass);
        }



        //obj.setSize();

        //Debug.Log("hola mundo");

	}
	
	// Update is called once per frame
	void Update () {
	}
} 
