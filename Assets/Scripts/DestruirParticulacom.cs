using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirParticulacom : MonoBehaviour
{
    public string targetTag = "Terreno"; // Tag del collider con el que queremos colisionar
    public float destructionDelay = 7f; // Tiempo en segundos antes de destruir el GameObject

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(targetTag))
        {
            // Inicia la corutina para destruir el GameObject después de un retraso
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destructionDelay);
        Destroy(gameObject);
    }
}