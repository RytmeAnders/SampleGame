using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool canMove = true;
    public Rigidbody rb;
    public float thrust;

    public KeyCode forward, back, left, right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            roll();
        }
    }

    private void roll()
    {
        if (Input.GetKey(forward))
        {
            rb.AddForce(Vector3.forward * thrust);
        }

        if (Input.GetKey(left))
        {
            rb.AddForce(Vector3.left * thrust);
        }

        if (Input.GetKey(right))
        {
            rb.AddForce(Vector3.right * thrust);
        }

        if (Input.GetKey(back))
        {
            rb.AddForce(Vector3.back * thrust);
        }
    }
}
