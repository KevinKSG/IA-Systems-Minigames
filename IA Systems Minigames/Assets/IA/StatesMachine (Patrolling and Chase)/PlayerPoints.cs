using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int points = 0;
    public FinalBT finalBT;

    private bool finish = false;

    public void GetPoint()
    {
        points++;
    }

    void Update()
    {
        //Debug.Log(points);
        if(points >= 5 && finish==false)
        {
            finalBT.Setup(points,true);
            finish = true;
        }
    }

    public void LoseGame()
    {
        if(finish==false)
        {
            finalBT.Setup(points, false);
            finish = true;
        }
        
        
    }
}
