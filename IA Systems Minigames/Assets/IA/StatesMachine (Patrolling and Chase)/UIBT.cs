using IA.GOAP.WorldKeys;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBT : MonoBehaviour
{
    public PlayerPoints playerPoints;
    public TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "Objetos recogidos: " + playerPoints.points.ToString() + "/5";
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Objetos recogidos: " + playerPoints.points.ToString() + "/5";
    }
}
