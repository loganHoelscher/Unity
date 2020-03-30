using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

    public float speed = 10.0f;
    public int damage = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.name == "Cube" || collision.gameObject.name == "Cylinder")
        {
            Destroy(this.gameObject);
        }
	}

}
	

