using UnityEngine;
using System.Collections;

public class NewMonoBehaviour : MonoBehaviour
{
    public bool onGround;
    private Rigidbody rb;

	// Use this for initialization
	void Start()
	{
        onGround = true;
        rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
        if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(0f, 5f, 0f);
                onGround = false;
            }
        }
	}
}
