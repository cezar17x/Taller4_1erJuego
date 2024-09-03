using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpearPelota : MonoBehaviour
{
    public float fuerzaImpulso = 10f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BallGolf"))
        {
            Vector3 impulseDirection = transform.forward;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(impulseDirection * fuerzaImpulso, ForceMode.Impulse);
        }
    }
}