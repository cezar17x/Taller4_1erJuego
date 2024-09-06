using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocimetro : MonoBehaviour
{
    public RectTransform aguja;  
    public float minAngle = -90f;  
    public float maxAngle = 90f;   
    public float velocidad = 2f;
    public GameObject agujaimage, velocimetro;
    public float valorVelocimetro = 0f;  // Valor actual del velocímetro (0-1)
    private bool activo = true; 
    public Animator brian;

    void Update()
    {
        if (activo)
        {
            valorVelocimetro = Mathf.PingPong(Time.time * velocidad, 1);
            float angle = Mathf.Lerp(minAngle, maxAngle, valorVelocimetro);
            aguja.localEulerAngles = new Vector3(0, 0, -angle);       
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && activo)
        {
            brian.SetFloat("VelocimetroValor", valorVelocimetro);
            Debug.Log("Valor del Velocímetro: " + valorVelocimetro);
            if (valorVelocimetro <= 0.2f)
            {
                brian.Play("golpeSuave");
                Debug.Log("Estamos en verde");
            }
            else if (valorVelocimetro >= 0.8f)
            {
                brian.Play("GolpeFuerte");
                Debug.Log("Estamos en rojo");
            }
            else
            {
                brian.Play("golpeSuave");
                Debug.Log("Estamos en el centro");
            }
            activo = false;
            DesactivarVelocimetro();
        }
        
    }
    IEnumerator Descativar()
    {
        yield return new WaitForSeconds(2);
        agujaimage.SetActive(false);
        velocimetro.SetActive(false);
    }
    void DesactivarVelocimetro()
    {
        /* Desaparecer el velocímetro (opcional: hacer fade out)
        gameObject.SetActive(false);*/
        StartCoroutine(Descativar());
        GolpearPelota.instance.ActualizarFuerzaImpulso(valorVelocimetro);
    }
}