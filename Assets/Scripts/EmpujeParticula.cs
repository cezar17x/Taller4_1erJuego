using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EmpujeParticula : MonoBehaviour
{
    public string tagToCollideWith = "BallGolf"; // Cambia esto al Tag deseado
    public float impulseForce = 6f;  // Fuerza de impulso hacia atrás

    private void OnParticleCollision(GameObject other)
    {
        // Verifica si el objeto con el que colisionó tiene el tag correcto
        if (other.CompareTag(tagToCollideWith))
        {
            // Obtiene el Rigidbody del objeto
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
               
                Vector3 forceDirection = -other.transform.up;  
                rb.AddForce(forceDirection * impulseForce, ForceMode.Impulse);
            }
        }
    }
}