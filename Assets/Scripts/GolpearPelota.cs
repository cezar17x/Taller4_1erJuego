using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GolpearPelota : MonoBehaviour
{
    public float fuerzaImpulso = 10f;
    public static GolpearPelota instance;
    private void Awake()
    {
        instance = this;    
    }
    private void Start()
    {
        Scene escena = SceneManager.GetActiveScene(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        Scene escena = SceneManager.GetActiveScene();
        if (other.CompareTag("BallGolf"))
        {
            print("Colisiono");
            Vector3 impulseDirection = transform.up;
            if (escena.buildIndex == 3)
                impulseDirection = transform.up;  
            else
                impulseDirection = transform.up;
            other.GetComponent<Rigidbody>().AddForce(impulseDirection * fuerzaImpulso, ForceMode.Impulse);
            other.GetComponent<MoverPelotaAcelerometro>().enabled = true; 
        }
    }
    public void ActualizarFuerzaImpulso(float valorVelocimetro)
    {
        Scene escena = SceneManager.GetActiveScene();
        if (escena.buildIndex == 3)
            fuerzaImpulso = Mathf.Lerp(1f, 10f, valorVelocimetro);
        else if(escena.buildIndex == 1)
            fuerzaImpulso = Mathf.Lerp(0.5f, 5f, valorVelocimetro);
        else
            fuerzaImpulso = Mathf.Lerp(2f, 20f, valorVelocimetro);  // Ajusta los valores mínimo y máximo según sea necesario
        //print(fuerzaImpulso);
    }
}