using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    public float thrust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roll();
    }

    private void roll()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * thrust);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * thrust);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * thrust);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * thrust);
        }
    }
}
