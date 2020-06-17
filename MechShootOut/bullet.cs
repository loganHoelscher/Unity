using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {


    public float speed = 10.0f;
    public GameObject bullets;
    public GameObject laser;
    public GameObject mech;
  


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, 0, speed * Time.deltaTime);
        Destroy(bullets, 2f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            Destroy(laser);
        }
    }
}
