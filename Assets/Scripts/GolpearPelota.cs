using UnityEngine;

public class GolpearPelota : MonoBehaviour
{
    public float fuerzaImpulso = 10f;
    public static GolpearPelota instance;
    private void Awake()
    {
        instance = this;    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallGolf"))
        {
            print("Colisiono");
            Vector3 impulseDirection = transform.up;
            other.GetComponent<Rigidbody>().AddForce(impulseDirection * fuerzaImpulso, ForceMode.Impulse);
            other.GetComponent<MoverPelotaAcelerometro>().enabled = true; 
        }
    }
    public void ActualizarFuerzaImpulso(float valorVelocimetro)
    {
        fuerzaImpulso = Mathf.Lerp(2f, 20f, valorVelocimetro);  // Ajusta los valores mínimo y máximo según sea necesario
    }
}