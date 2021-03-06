﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSceneCtrlr : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;
    public Transform bulletSpawn;
    RaycastHit hit;
    public Camera camera;
    private int speed = 50;

    Vector3 bulletPos;


	// Use this for initialization
	void Start () {
        hit = new RaycastHit();
	}

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 800.0f))
                {
                     GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
                    bullet.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * speed * Time.deltaTime;
                }
             
            }
    }

}
