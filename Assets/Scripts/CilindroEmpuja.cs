using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilindroEmpuja : MonoBehaviour
{
    public float fuerza = 5f;
    public bool izquierda = false, derecha = false;
    Vector3 impulso = Vector3.zero;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BallGolf"))
        {
            if (izquierda) impulso = -transform.right;
            else if (derecha) impulso = transform.right;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(impulso * fuerza, ForceMode.Impulse);
        }
    }
}