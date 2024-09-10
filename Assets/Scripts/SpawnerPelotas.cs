using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPelotas : MonoBehaviour
{
    public GameObject particlePrefab; // Prefab del GameObject a generar
    public Collider spawnArea; // Collider que define el área de generación
    public float spawnInterval = 0.5f; // Intervalo en segundos entre cada generación

    private void Start()
    {
        if (spawnArea == null)
        {
            Debug.LogError("Spawn Area Collider no asignado.");
            return;
        }

        InvokeRepeating(nameof(SpawnParticle), 0f, spawnInterval);
    }

    void SpawnParticle()
    {
        Vector3 randomPosition = GetRandomPositionInCollider(spawnArea);
        Instantiate(particlePrefab, randomPosition, Quaternion.identity);
    }

    Vector3 GetRandomPositionInCollider(Collider collider)
    {
        Bounds bounds = collider.bounds;
        Vector3 randomPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
        return randomPoint;
    }
}