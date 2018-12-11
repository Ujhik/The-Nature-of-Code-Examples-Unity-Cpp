using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] float speed;

    float radius;
    Vector2 direction;

	// Use this for initialization
	void Start () {
        direction = Vector2.one.normalized; //Direction is (1,1) normalized
        radius = transform.localScale.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);

        //Rebound bottom
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        
        //Rebound top
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //Rebound left
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            direction.x = -direction.x;
        }

        //Rebound right
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            direction.x = -direction.x;
        }


    }
}
