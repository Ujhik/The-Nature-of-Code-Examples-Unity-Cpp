using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Ball ball_;
    public Atractor atractor_;

    Ball mover;
    Atractor atractor;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;


    // Use this for initialization
    void Start () {

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));



        mover = Instantiate(ball_);
        mover.Init(0.5f);

        atractor = Instantiate(atractor_);
        atractor.Init(30);
        



        //obj.setSize();

        //Debug.Log("hola mundo");

	}
	
	// Update is called once per frame
	void Update () {
        mover.atracted(atractor.transform.position, atractor.mass);
	}
} 
