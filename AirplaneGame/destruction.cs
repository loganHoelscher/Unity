using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction : MonoBehaviour {
    public GameObject target;
    public GameObject redEmission;
    public Transform targetBox;

    bool isHit = false;

	// Use this for initialization
	void Start () {
        target.SetActive(true);
        redEmission.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
        if(isHit == true)
        {
            redEmission.SetActive(true);
            Instantiate(redEmission, targetBox.position, targetBox.rotation);
            Destroy(target);

        }

	}
	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.name == "bullet(Clone)")
        {
            /*
            redEmission.SetActive(true);
            target.SetActive(false);
                */
            isHit = true;

        }
	}
}
