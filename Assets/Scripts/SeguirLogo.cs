using UnityEngine;
using Cinemachine;

public class SeguirLogo : MonoBehaviour
{
    // Asigna tu Cinemachine Virtual Camera en el Inspector para referencia
    public CinemachineVirtualCamera virtualCamera;

    void Update()
    {
        // La Cinemachine Virtual Camera controla la Camera.main
        Camera cam = Camera.main;

        // Usa la distancia desde la cámara actual para mantener el objeto visible
        float distanceFromCamera = cam.transform.position.z + 1f;

        // Esquina superior derecha de la vista (1, 1 en Viewport)
        Vector3 screenPosition = new Vector3(1, 1, cam.transform.position.z + cam.nearClipPlane + 10f);

        // Convierte las coordenadas de Viewport a coordenadas del mundo
        Vector3 worldPosition = cam.ViewportToWorldPoint(screenPosition);

        // Ajusta la posición del objeto en la esquina superior derecha
        transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
    }
}