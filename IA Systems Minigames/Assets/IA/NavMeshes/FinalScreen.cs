using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    public TextMeshProUGUI playerPointsText;
    public TextMeshProUGUI enemyPointsText;

    public TextMeshProUGUI winnerText;

    public void Setup(int playerScore, int enemyScore, int winner)
    {
        gameObject.SetActive(true);
        playerPointsText.text = "JUGADOR: " + playerScore.ToString() + " PUNTOS";
        enemyPointsText.text = "NPC: " + enemyScore.ToString() + " PUNTOS";

        if(winner == 0)
        {
            winnerText.text = "HAS GANADO";
        }
        else if(winner == 1)
        {
            winnerText.text = "HAS PERDIDO";
        }
        else
        {
            winnerText.text = "HAS EMPATADO";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("NavMeshes");
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
