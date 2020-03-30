using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour {

    public float speed = 2.3f;
    public float obstacleRange = 1.0f;

    public GameObject mecha;

    // Use this for initialization
    void Start()
    {
        mecha = GameObject.Find("mecha(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.gameObject.name == "mecha(Clone)")
            {
                mecha.SetActive(false);
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);

            }
        }



    }
}

