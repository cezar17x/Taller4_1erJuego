using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeFlecha : MonoBehaviour
{
    public Transform objetivo; // El transform al que la flecha debe apuntar
    public Transform personaje; // El transform del personaje

    void Update()
    {
        // Calcula la dirección hacia el objetivo
        Vector3 direccion = objetivo.position - transform.position;

        // Calcula la rotación necesaria para apuntar hacia el objetivo
        Quaternion rotacion = Quaternion.LookRotation(direccion, Vector3.up);

        // Aplica la rotación a la flecha
        transform.rotation = rotacion;

        // Asegura que la flecha esté encima del personaje
        transform.position = personaje.position + Vector3.up * 1.0f; // Ajusta 2.0f para la altura deseada

        // Asegura que la flecha se gire cuando el personaje se voltee
        Vector3 escalaFlecha = transform.localScale;
        escalaFlecha.x = personaje.localScale.x >= 0 ? 1 : -1; // Invierte la escala en X si el personaje se voltea
        transform.localScale = escalaFlecha;
    }
}