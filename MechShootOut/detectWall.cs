using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.name == "static scene")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}
}
