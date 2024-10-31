using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int ejemplo;
    public void Juego1()
    {
        SceneManager.LoadScene("NavMeshes");
    }
    public void Juego2()
    {
        SceneManager.LoadScene("MazeScene");
    }

    public void Juego3()
    {
        SceneManager.LoadScene("GOAPScene");
    }

    public void Juego4()
    {
        SceneManager.LoadScene("FlockingScene");
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
