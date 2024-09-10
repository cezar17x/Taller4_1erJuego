using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Velocimetro : MonoBehaviour
{
    public RectTransform aguja;  
    public float minAngle = -90f;  
    public float maxAngle = 90f;   
    public float velocidad = 2f;
    //public GameObject agujaimage, velocimetro, fondo;
    public float valorVelocimetro = 0f;  // Valor actual del velocímetro (0-1)
    private bool activo = true; 
    public Animator brian;
    public CanvasGroup velocimetro, Instrucciones;
    private void Start()
    {
        Scene escena = SceneManager.GetActiveScene();
    }
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
            //Debug.Log("Valor del Velocímetro: " + valorVelocimetro);
            if (valorVelocimetro <= 0.2f)
            {
                brian.Play("golpeSuave");
                //Debug.Log("Estamos en verde");
            }
            else if (valorVelocimetro >= 0.8f)
            {
                brian.Play("GolpeFuerte");
                //Debug.Log("Estamos en rojo");
            }
            else
            {
                brian.Play("golpeSuave");
                //Debug.Log("Estamos en el centro");
            }
            activo = false;
            DesactivarVelocimetro();
        }
        
    }
    void DesactivarVelocimetro()
    {
        Scene escena = SceneManager.GetActiveScene();
        /* Desaparecer el velocímetro (opcional: hacer fade out)
        gameObject.SetActive(false);
        StartCoroutine(Descativar());*/
        FadeOut();
        GolpearPelota.instance.ActualizarFuerzaImpulso(valorVelocimetro);
        if (escena.buildIndex == 1)
        {
            StartCoroutine(Aparecer());
        }    
    }
    IEnumerator Aparecer()
    {
        Instrucciones.DOFade(1, 3f).OnComplete(() =>
        {
            //Debug.Log("Fade Out completado");
        });
        yield return new WaitForSeconds(8);
        Instrucciones.DOFade(0, 2f).OnComplete(() =>
        {
            //Debug.Log("Fade Out completado");
        });
    }
    public void FadeOut()
    {
        // Reduce el alpha a 0 en 2 segundos (fade out)
        velocimetro.DOFade(0, 2f).OnComplete(() =>
        {
            //Debug.Log("Fade Out completado");
        });
    }
}