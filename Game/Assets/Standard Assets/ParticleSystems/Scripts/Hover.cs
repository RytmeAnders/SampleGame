using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float hoverSpeed;
    public float hoverHeight;

    private Vector3 initialPosition;
    private float yRotate;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        yRotate = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initialPosition + new Vector3(0, Mathf.Cos(Time.time * hoverSpeed) * 0.5f, 0);
        transform.Rotate(0, yRotate, 0);
    }
}
