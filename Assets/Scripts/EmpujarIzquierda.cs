using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujarIzquierda : MonoBehaviour
{
    public float fuerza = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BallGolf"))
        {
            Vector3 impulso = -transform.right;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(impulso * fuerza, ForceMode.Impulse);
        }
    }
}