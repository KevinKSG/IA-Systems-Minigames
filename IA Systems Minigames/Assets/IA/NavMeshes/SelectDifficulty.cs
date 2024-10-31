using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour
{
    public SetDifficulty setDifficulty;

    public void SelectEasy()
    {
        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject gameObject in gameObjects)
        {
            if(gameObject.name == "FinalScreen")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
            
        }

        setDifficulty.difficulty = SetVelocityZone.Difficulty.Easy;

        this.gameObject.SetActive(false);


    }

    public void SelectMedium()
    {

        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == "FinalScreen")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

        }

        setDifficulty.difficulty = SetVelocityZone.Difficulty.Medium;

        this.gameObject.SetActive(false);
    }

    public void SelectHard()
    {

        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == "FinalScreen")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

        }

        setDifficulty.difficulty = SetVelocityZone.Difficulty.Hard;

        this.gameObject.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
