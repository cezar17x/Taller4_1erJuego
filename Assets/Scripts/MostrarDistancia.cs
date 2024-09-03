using TMPro;
using UnityEngine;

public class MostrarDistancia : MonoBehaviour
{
    public Transform Pelota;
    public Transform Hoyo; 
    public TextMeshProUGUI distanceText; // Texto para mostrar la distancia
    public float updateInterval = 1f; // Intervalo de actualización en segundos

    private float timeSinceLastUpdate;

    void Start()
    {
        if (Pelota == null || Hoyo == null || distanceText == null)
        {
            Debug.LogError("Por favor, asigna todos los objetos necesarios en el inspector.");
            enabled = false;
            return;
        }

        // Inicializar el texto en la pantalla
        UpdateDistanceText();
    }

    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
            UpdateDistanceText();  
    }

    void UpdateDistanceText()
    {
        if (Pelota == null || Hoyo == null)
            return;

        // Calcular la distancia entre los dos objetos
        float distance = Vector3.Distance(Pelota.position, Hoyo.position);

        // Actualizar el texto en la pantalla
        distanceText.text = $"{distance:F2} mtrs";
    }
}