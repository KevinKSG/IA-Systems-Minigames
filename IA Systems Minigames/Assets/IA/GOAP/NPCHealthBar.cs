using IA.GOAP.Behaviors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHealthBar : MonoBehaviour
{
    public HealthBehaviour npcHealthBehaviour;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = npcHealthBehaviour.Health;
    }
}
