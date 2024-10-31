using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlocking : MonoBehaviour
{
    public PlayerController controller;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, controller.transform.position);
        Debug.Log("Distancia: " + dist);
        if (dist < 3f)
        {
            controller.winFlocking();
        }
    }
}
