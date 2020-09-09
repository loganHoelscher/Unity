using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovement : MonoBehaviour {
    public float speed = 10f;
    public float driftSpeed = 15f;
    public float rotationSpeed = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);


        //rudder control
        if(Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0, 0, -driftSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.C))
        {
            transform.Translate(0, 0, driftSpeed * Time.deltaTime);
        }

        //rotation control
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }

        //speed control
        if(Input.GetKey(KeyCode.W))
        {
            speed += 5;
        }
        if(Input.GetKey(KeyCode.S))
        {
            speed -= 5;
        }
        if(speed > 60)
        {
            speed = 60;
        }
        else if(speed < 10)
        {
            speed = 10;
        }
	}
}
