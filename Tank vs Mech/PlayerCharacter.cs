using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private int health;
    // Use this for initialization
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "tank")
        {
            health--;
        }
    }

}

