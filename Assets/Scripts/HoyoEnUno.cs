using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HoyoEnUno : MonoBehaviour
{
    public ParticleSystem confeti;
    public GameObject arrow;
    public string Escena;
    public TextMeshProUGUI countdownText;
    private float countdown = 5f;
    private bool startCountdown = false;
    private void Start()
    {
        Scene escena = SceneManager.GetActiveScene();
        countdownText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallGolf"))
        {
            Destroy(other.gameObject);
            Destroy(arrow);
            confeti.Play();
            countdownText.gameObject.SetActive(true);
            startCountdown = true;
        }
    }
    private void Update()
    {
        Scene escena = SceneManager.GetActiveScene();
        if (startCountdown)
        {
            countdown -= Time.deltaTime;
            if(escena.buildIndex == 3)
            {
                countdownText.text = "El Juego Termina en " + Mathf.Ceil(countdown).ToString();
            }
            else
                countdownText.text = "Siguiente Nivel en " + Mathf.Ceil(countdown).ToString();

            if (countdown <= 0)
            {
                LoadNextLevel(); 
            }
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(Escena);
    }
}