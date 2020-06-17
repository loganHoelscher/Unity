using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileControl : MonoBehaviour
{
    public GameObject boom;
    public GameObject scorch;

    public float speed = 150.0f;
    public float blastRadius = 5f;
    public float blastForce = 100f;

    public Camera missileCamThird;
    public Camera missileCamFirst;
    public Camera sceneCam;


    bool hasBoomed = false;
    bool isScorched = false;

    // Use this for initialization
    void Start()
    {
        missileCamThird.enabled = true;
        missileCamFirst.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);

        if (transform.position.y < 600)
        {
            speed += 15;
            missileCamThird.enabled = false;
            missileCamFirst.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane" || collision.gameObject.name == "white")
        {
            if (!hasBoomed && !isScorched)
            {
                missileCamThird.enabled = false;
                missileCamFirst.enabled = true;
                sceneCam.enabled = true;
                Explode();
                hasBoomed = true;
                isScorched = true;
                Destroy(this.gameObject);
            }


        }
    }
    private void Explode()
    {
        Instantiate(boom, transform.position, transform.rotation);
        Instantiate(scorch, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(blastForce, transform.position, blastRadius);
            }
        }
    }
}

   
