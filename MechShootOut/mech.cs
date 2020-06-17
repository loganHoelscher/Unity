using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mech : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 3.0f;
    int count = 0;
    [SerializeField] private GameObject laserPrefab;
    private GameObject laser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(ray, obstacleRange, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.gameObject.name == "laser(Clone)")
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
                else
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
            }
        }

        if (Physics.SphereCast(ray, 1.0f, out hit))
        {
            if (count % 15 == 0)
            {

                laser = Instantiate(laserPrefab) as GameObject;
                laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                laser.transform.rotation = transform.rotation;
            }
            count++;
            if (count > 15)
                count = 1;
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.name == "wall")
        {
            float angle = Random.Range(-110, 110);
            transform.Rotate(0, angle, 0);
        }
	}

}
