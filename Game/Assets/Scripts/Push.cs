using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private Rigidbody rb;

    public float forceMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Colliding!");
        if (collision.gameObject.CompareTag("Player"))
        {
            float otherMagnitude = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

            if (rb.velocity.magnitude < otherMagnitude)
            {
                Vector3 force = collision.relativeVelocity * forceMultiplier;
                rb.AddForce(force);
            }
            //Vector3 force = collision.gameObject.GetComponent<Rigidbody>().velocity * 500;
        }
    }
}
