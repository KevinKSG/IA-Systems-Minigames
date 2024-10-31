using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGOAP : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    public void Setup(bool winner)
    {
        gameObject.SetActive(true);

        if (winner == true)
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
        SceneManager.LoadScene("GOAPScene");
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
