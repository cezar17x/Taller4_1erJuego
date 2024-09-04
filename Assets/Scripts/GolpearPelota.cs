using UnityEngine;

public class GolpearPelota : MonoBehaviour
{
    public float fuerzaImpulso = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallGolf"))
        {
            print("Colisiono");
            Vector3 impulseDirection = transform.forward;
            other.GetComponent<Rigidbody>().AddForce(impulseDirection * fuerzaImpulso, ForceMode .Impulse);
            other.GetComponent<MoverPelotaAcelerometro>().enabled = true; 
        }
    }
}