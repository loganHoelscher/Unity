using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinoMover : MonoBehaviour {

    public float speed = 2.0f;
    public float obstacleRange = 0.1f;
    Vector3 originalPos;

    public GameObject mech;

    // Use this for initialization
    void Start()
    {
        mech = GameObject.Find("mechred(Clone)");
        originalPos = new Vector3(gameObject.transform.position.x,
                                  gameObject.transform.position.y,
                                  gameObject.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, speed * Time.deltaTime);
        //transform.Translate(-speed * Time.deltaTime,0,0);

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            print(hit.distance);
            if (hit.distance < obstacleRange)
            {
                mech.SetActive(false);
                gameObject.transform.position = originalPos;
                float angle = Random.Range(0, 360);
                transform.Rotate(0, angle, 0);
                mech.SetActive(true);
            }


        }
    }
}
