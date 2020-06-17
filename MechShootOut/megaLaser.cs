using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaLaser : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;
    public GameObject lasers;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, -0.8f, speed * Time.deltaTime);
        Destroy(lasers, 2f);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "player")
        {
            Destroy(lasers);
        }
        else if (collision.gameObject.name == "wall")
        {
            Destroy(lasers);
        }
    }
}

