using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerController playerController;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = playerController.health;
    }
}
