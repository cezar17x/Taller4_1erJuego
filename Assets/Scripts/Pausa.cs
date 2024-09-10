using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject pause;
    private bool isPaused = false;

    private void Start()
    {
        pause.SetActive(false);
    }
    public void Pausa1()
    {
        if (!isPaused)
        {
            isPaused = true;
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Despausa()
    {
        if (isPaused)
        {
            isPaused = false;
            pause.SetActive(false);
            Time.timeScale = 1;
        }
    }
}