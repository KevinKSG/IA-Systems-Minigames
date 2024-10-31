using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFlock : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    private bool finish = false;

    public void Setup(bool winner)
    {
        if(winner)
        {
            if(finish == false)
            {
                finish = true;
                winnerText.text = "HAS GANADO";
                this.gameObject.SetActive(true);
            }
        }
        else
        {
            if(finish == false)
            {
                finish = true;
                winnerText.text = "HAS PERDIDO";
                this.gameObject.SetActive(true);
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("FlockingScene");
        finish = false;
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
