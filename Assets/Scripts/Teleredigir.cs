using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleredigir : MonoBehaviour
{
    // El tag del GameObject con el que colisionar
    public string targetTag = "Hoyo";
    // El GameObject al que el objeto se mover�
    public Transform destination;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene el tag especificado
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Llama a la funci�n para mover el objeto
            StartCoroutine(MoveToDestination());
        }
    }

    private IEnumerator MoveToDestination()
    {
        // Verifica si el destino est� asignado
        if (destination == null)
        {
            Debug.LogWarning("No destination set for CollisionMover.");
            yield break;
        }

        // Obt�n el transform del GameObject actual
        Transform startTransform = transform;

        // Define la velocidad de movimiento
        float speed = 5f;
        // Define el tiempo total que tardar� en llegar al destino
        float journeyLength = Vector3.Distance(startTransform.position, destination.position);
        float startTime = Time.time;

        // Mueve el objeto hasta que llegue al destino
        while (Vector3.Distance(startTransform.position, destination.position) > 0.1f)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startTransform.position, destination.position, fractionOfJourney);
            yield return null;
        }

        // Aseg�rate de que el objeto llegue exactamente al destino
        transform.position = destination.position;
    }
}