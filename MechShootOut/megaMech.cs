using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaMech : MonoBehaviour {

    public GameObject bossPrefab;
    private GameObject boss;

    // spawn points
    private Vector3 left = new Vector3(-199.6f, 81.0f, -156.4f);
    private Vector3 mid = new Vector3(-199.6f, 127.0f, -1.0f);
    private Vector3 right = new Vector3(-199.6f, 95.6f, 174.2f);


	// Use this for initialization
	void Start () {
       // boss = GameObject.FindGameObjectWithTag("Respawn");

        //boss.transform.position = mid;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(boss == null)
        {
            boss = Instantiate(bossPrefab) as GameObject;

        int pos = Random.Range(0, 3);
            if (pos == 0)
            {
                boss.transform.position = left;

            }
            else if (pos == 1)
            {
                boss.transform.position = mid;
               
            }
            else if (pos == 2)
            {
                boss.transform.position = right;

            }
        }

	}

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.name == "bullet(Clone)")
        {
            Destroy(boss);
        }
	}
}
