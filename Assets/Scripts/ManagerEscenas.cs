using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerEscenas : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Comenzar(string nombrePrimerNivel)
    {
        SceneManager.LoadScene(nombrePrimerNivel);
    }
}