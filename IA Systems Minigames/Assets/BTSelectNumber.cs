using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTSelectNumber : MonoBehaviour
{
    public void selectTwo()
    {
        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == "FinalBT" || gameObject.name == "NPC Vision Cone 2" || gameObject.name == "NPC Vision Cone 3")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

        }

        this.gameObject.SetActive(false);
    }

    public void selectThree() 
    {
        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == "FinalBT" || gameObject.name == "NPC Vision Cone 3")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

        }

        this.gameObject.SetActive(false);
    }

    public void selectFour() 
    {
        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == "FinalBT")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

        }

        this.gameObject.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
