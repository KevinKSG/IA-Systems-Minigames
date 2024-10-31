using IA.GOAP.Behaviors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;

public class UIGOAP : MonoBehaviour
{
    public PlayerController playerController;
    public HealthBehaviour npcHealthBehaviour;

    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI npcHealthText;

    public FinalGOAP finalGOAP;

    // Start is called before the first frame update
    void Start()
    {
        int playerHealth = (int) playerController.health;
        int npcHealth = (int)npcHealthBehaviour.Health;

        playerHealthText.text = "Jugador: " + playerHealth.ToString();
        npcHealthText.text = "NPC: " + npcHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int playerHealth = (int)playerController.health;
        int npcHealth = (int)npcHealthBehaviour.Health;

        playerHealthText.text = "Jugador: " + playerHealth.ToString();
        npcHealthText.text = "NPC: " + npcHealth.ToString();

        if(playerHealth <= 0)
        {
            finalGOAP.Setup(false);
        }
        else if(npcHealth <= 0)
        {
            finalGOAP.Setup(true);
        }
    }
}
