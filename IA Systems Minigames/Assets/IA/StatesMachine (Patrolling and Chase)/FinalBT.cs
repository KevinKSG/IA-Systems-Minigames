using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBT : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI finalPoints;

    public void Setup(int points, bool winner)
    {
        gameObject.SetActive(true);
        finalPoints.text = "OBJETOS RECOGIDOS: " + points + "/5";

        if (winner)
        {
            winnerText.text = "HAS GANADO";
        }
        else
        {
            winnerText.text = "HAS PERDIDO";
        }
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("MazeScene");
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
