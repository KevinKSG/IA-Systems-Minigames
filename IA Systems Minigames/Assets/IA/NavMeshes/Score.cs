using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public ObjectivePoint points;
    public FinalScreen finalScreen;

    public TextMeshProUGUI scorePlayerText;
    public TextMeshProUGUI scoreEnemyText;

    public TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    private bool gameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        scorePlayerText.text = "Jugador: " + points.playerPoints.ToString() + " PUNTOS";
        scoreEnemyText.text = "NPC: " + points.enemyPoints.ToString() + " PUNTOS";
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime <= 1 && gameFinished == false)
        {
            gameFinished = true;
            int winner;

            if (points.playerPoints > points.enemyPoints)
            {
                winner = 0;
            }
            else if (points.playerPoints < points.enemyPoints)
            {
                winner = 1;
            }
            else
            {
                winner = 2;
            }

            finalScreen.Setup(points.playerPoints, points.enemyPoints, winner);
        }

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;
        }

        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        scorePlayerText.text = "Jugador: " + points.playerPoints.ToString() + " PUNTOS";
        scoreEnemyText.text = "NPC: " + points.enemyPoints.ToString() + " PUNTOS";
    }
}
