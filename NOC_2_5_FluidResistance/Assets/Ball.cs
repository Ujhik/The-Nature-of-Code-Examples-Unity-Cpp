using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Vector2 position;
    [SerializeField] Vector2 velocity;
    [SerializeField] Vector2 aceleration;
    [SerializeField] Vector2 topvelocity = new Vector2 (10,10);
    [SerializeField] Vector2 mousePosition;
    [SerializeField] Vector2 wind;
    [SerializeField] Vector2 gravity;
    [SerializeField] Vector2 friction;
    [SerializeField] Vector2 drag;


    [SerializeField]public float radius;
    [SerializeField]public float mass;
    float frictionCoef, frictionNormalForce, dragMagnitude;

    float xPosition;


	// Use this for initialization
	void Start () {
        velocity = Vector2.one.normalized; //Initial velocity is (1,1) normalized

        wind = new Vector2 (0.01f, 0);
        gravity = new Vector2 (0, -0.1f * mass);

        frictionCoef = 0.005f;
        frictionNormalForce = 1;
        dragMagnitude = 0.01f;
        
        transform.localScale = new Vector3(mass, mass, mass);

        radius = transform.localScale.x / 2;

        //All balls bottom line at the same y position to see adjusted gravity effect. 2 is the max ball size
        transform.position = new Vector2(xPosition ,5 - (2-radius));
	}
	
	// Update is called once per frame
	void Update () {
    
        

        position = transform.position;

        //Updating mouse position
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);  //Transforming coordinates from mouse on screen to world

        //Calculating new aceleration
        friction = frictionCoef * frictionNormalForce * velocity.normalized * -1;
        this.addForce(friction);
        //this.addForce(wind);
        this.addForce(gravity);

            //Calculating water dragging
        if(transform.position.y < 0){
            float speed = velocity.magnitude;
            drag = dragMagnitude * speed * speed * -1 * velocity.normalized;

            this.addForce(drag);
        }
        

        //Adding aceleration to velocity
        velocity += aceleration;

        //Limiting the velocity
        velocity = Vector2.Min(velocity, topvelocity);

        //Changing position to aceleration, making it depend on seconds instead of frames
        transform.Translate(velocity * Time.deltaTime);

        //Rebound bottom
        if (transform.position.y < GameManager.bottomLeft.y + radius && velocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, GameManager.bottomLeft.y + radius);            
            velocity.y = -velocity.y;
        }
        
        //Rebound top
        if (transform.position.y > GameManager.topRight.y - radius && velocity.y > 0)
        {
            transform.position = new Vector2(transform.position.x, GameManager.topRight.y - radius);
            velocity.y = -velocity.y;
        }

        //Rebound left
        if (transform.position.x < GameManager.bottomLeft.x + radius && velocity.x < 0)
        {
            transform.position = new Vector2(GameManager.bottomLeft.x + radius, transform.position.y);
            velocity.x = -velocity.x;
        }

        //Rebound right
        if (transform.position.x > GameManager.topRight.x - radius && velocity.x > 0)
        {
            transform.position = new Vector2(GameManager.topRight.x - radius, transform.position.y);
            velocity.x = -velocity.x;
        }

        //Reseting aceleration
        aceleration *= 0;
    }

    void addForce(Vector2 force){
        aceleration += force / mass;
    }

    public void Init(float mass, float xPosition){
        this.radius = 0.1f;

        this.mass = mass;

        this.xPosition = -10 + xPosition*8;
    }

    

}
