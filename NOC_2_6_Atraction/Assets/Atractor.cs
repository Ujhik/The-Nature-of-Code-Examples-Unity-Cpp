using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atractor : MonoBehaviour {

    [SerializeField]public float radius;
    [SerializeField]public float mass;
    float frictionCoef, frictionNormalForce;


	// Use this for initialization
	void Start () {
        
        transform.localScale = new Vector3(1, 1, 1);

        radius = transform.localScale.x / 2;

        //All balls bottom line at the same y position to see adjusted gravity effect. 2 is the max ball size
        transform.position = new Vector2(-6 ,3 - (2-radius));
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Init(float mass){
        this.radius = 0.1f;

        this.mass = mass;
    }

    void OnMouseDrag(){
        float distance = 10;
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = objPosition;
	}
    

}
