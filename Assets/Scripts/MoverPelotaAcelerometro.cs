using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPelotaAcelerometro : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;
    public float threshold = 0.1f; // Umbral de movimiento

    void Start()
    {
        if(rb == null) rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        float moveHorizontal = Mathf.Abs(tilt.x) > threshold ? tilt.x : 0.0f;  
        float moveVertical = Mathf.Abs(tilt.z) > threshold ? -tilt.z : 0.0f; 

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}