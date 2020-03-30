using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    //public int slopeRotation;
   
    private float maxSpeed = 15f;

    private Vector3 input;
	// Use this for initialization
	void Start () 
    {
        transform.position.Set(0f, 0.75f, -19.4f);
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));


        if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed); 
        }

        if(transform.position.y < -20)
        {
            Respawn();
        }
	}

    private void Respawn()
    {
        transform.position = new Vector3(0, 5, -18);
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;

    }
}
