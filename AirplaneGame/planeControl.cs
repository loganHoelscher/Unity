using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeControl : MonoBehaviour
{
    
    public float mouseSens = 3.0f;
    float xRotation = 0f;
    float yRotation = 0f;
    public Transform plane;
    // Use this for initialization
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens;

        //xRotation -= mouseY;
        yRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        //yRotation = Mathf.Clamp(yRotation, -45f, 45f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
       // transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        //plane.Rotate(Vector3.up * mouseX);
        plane.Rotate(Vector3.forward * mouseY);



    }
}
