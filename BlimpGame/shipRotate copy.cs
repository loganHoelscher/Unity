using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipRotate : MonoBehaviour {

    public enum Axis { horizontal, vertical, both  };

    public Axis axis;
    public float horSpeed = 6.0f;
    public float vertSpeed = 4.0f;
    public float moveSpeed = 4.0f;

    public float minHor = -48.0f;
    public float maxHor = 48.0f;
    public float minVert = -60.0f;
    public float maxVert = 60.0f;

    public float currentHor = 0.0f;
    public float currentVert = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        switch(axis)
        {
            case Axis.horizontal:
                transform.Rotate(0, horSpeed, 0);
                currentHor += horSpeed;
                if(currentHor == maxHor)
                {
                    horSpeed = -horSpeed;
                }
                if(currentHor == minHor)
                {
                    horSpeed = -horSpeed;
                }
                break;

            case Axis.vertical:
                transform.Rotate(vertSpeed, 0, 0);
                currentVert += vertSpeed;
                if(currentVert == maxVert)
                {
                    vertSpeed = -vertSpeed;
                }
                if(currentVert == minVert)
                {
                    vertSpeed = -vertSpeed;
                }
                break;

            case Axis.both:
                transform.Rotate(vertSpeed, horSpeed, 0);
                currentHor += horSpeed;
                currentVert += vertSpeed;
                if(currentVert == maxVert)
                {
                    vertSpeed = -vertSpeed;
                }
                if(currentVert == minVert)
                {
                    vertSpeed = -vertSpeed;
                }
                if(currentHor == maxHor)
                {
                    horSpeed = -horSpeed;
                }
                if(currentHor == minHor)
                {
                    horSpeed = -horSpeed;
                }
                break;

            default:
                print("sheeeeeeeit");
                break;
                
        }

        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        
		
	}
}
