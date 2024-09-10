using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujarBola : MonoBehaviour
{
    public string tagToCollideWith = "BallGolf"; 
    public float impulseForce = 6f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToCollideWith))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {

                Vector3 forceDirection = -collision.gameObject.transform.up;
                rb.AddForce(forceDirection * impulseForce, ForceMode.Impulse);
            }
        }
    }
}