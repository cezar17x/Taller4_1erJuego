using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarDeNuevo : MonoBehaviour
{
    public ManagerEscenas ME;
    public string nombreTagPelota;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(nombreTagPelota)) 
        {
            Destroy(other.gameObject);
            ME.Restart();
        }
    }
}