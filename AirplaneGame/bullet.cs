using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public GameObject bullets;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(bullets, 4f);
	}

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.name == "Plane")
        {
            Destroy(bullets);
        }
	}
}
