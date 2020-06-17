using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mechHealth : MonoBehaviour {
    
    public GameObject bullet;
    public GameObject fire;

    private int startHealth = 100;
    private int updatedHealth;
    private string health;
    private int damage = 34;

   


	// Use this for initialization
	void Start () {
        updatedHealth = startHealth;
        fire.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
        if(updatedHealth <= 33)
        {
            fire.SetActive(true);
        }
        if(updatedHealth <= 0)
        {
            
            Destroy(this.gameObject);
        }

		
	}

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.name == "bullet(Clone)")
        {
            updatedHealth = updatedHealth - damage;
            Debug.Log(updatedHealth);
           
        }
	}
}
