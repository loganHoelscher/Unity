using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaWander : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 1.0f;
    int count = 0;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.25f, out hit))
        {
            if (count % 15 == 0)
            {
                
                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                _fireball.transform.rotation = transform.rotation;
            }
            count++;
            if (count > 15)
                count = 1;
        }

        if (Physics.SphereCast(ray, obstacleRange, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.gameObject.name == "fireball(Clone)")
            {
                transform.Rotate(0, 0, 0);
            }
            else if(hitObject.gameObject.name == "tank")
            {
                Debug.Log("Health - 1");
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }

      
    }
}
