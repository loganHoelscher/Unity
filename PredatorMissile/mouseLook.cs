using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public float mouseSens = 3.0f;
    float xRotation = 0f;
    float yRotation = 0f;
    public Transform player;
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

        xRotation -= mouseY;
        yRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -20f, 90f);
        yRotation = Mathf.Clamp(xRotation, -20f, 90f);
       // transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
       // transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        player.Rotate(Vector3.forward * mouseY);



    }
}
