using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarDeNuevo : MonoBehaviour
{
    public ManagerEscenas ME;
    public string nombreTagPelota;
    public Mesh rota;
    public Vector3 newScale = new Vector3(0.05f, 0.05f, 0.05f);
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(nombreTagPelota)) 
        {
            Destroy(other.gameObject);
            ME.Restart();
        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(nombreTagPelota))
        {
            MeshFilter meshFilter = collision.gameObject.GetComponent<MeshFilter>();
            Rigidbody rig = collision.gameObject.GetComponent<Rigidbody>();
            Transform trans = collision.gameObject.GetComponent<Transform>();
            if (meshFilter != null && rig != null && trans != null)
            {
                trans.localScale = newScale;
                rig.isKinematic = true;
                meshFilter.mesh = rota;
                EmpezarCorrutina();
            }
        }
    }
    void EmpezarCorrutina()
    {
        StartCoroutine(Reinicio());
        StopCoroutine(Reinicio());
    }
    IEnumerator Reinicio()
    {
        yield return new WaitForSeconds(2);
        ME.Restart();
    }
}