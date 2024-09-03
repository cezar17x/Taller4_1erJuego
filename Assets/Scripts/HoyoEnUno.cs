using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoyoEnUno : MonoBehaviour
{
    public ParticleSystem confeti;
    public GameObject arrow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallGolf"))
        {
            Destroy(other.gameObject);
            Destroy(arrow);
            confeti.Play();
        }
    }
}