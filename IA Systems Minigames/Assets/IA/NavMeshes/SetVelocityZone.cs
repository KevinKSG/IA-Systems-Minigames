using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class SetVelocityZone : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard };

    public SetDifficulty setDifficulty;
    private Difficulty difficulty;

    public float speed = 20.0f;

    private float timer = 0.0f;
    private float maxTimer = 60.0f;
    private int counter = 0;
    private int randomInt = 0;

    private Renderer rendererObject;
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20.0f;
        timer = 40.0f;
        difficulty = setDifficulty.difficulty;

        rendererObject = GetComponent<Renderer>();
        defaultColor = rendererObject.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(difficulty);

        timer += Time.fixedDeltaTime;

        if(timer > maxTimer)
        {
            counter += 1;
            timer = 0.0f;

            randomInt = Random.Range(0, 6);

            if(randomInt % 3 == 1)
            {
                speed = 10.0f;
                rendererObject.material.color = Color.red;
                string areaName = rendererObject.gameObject.name;
                int areaIndex = NavMesh.GetAreaFromName(areaName);
                if(difficulty == Difficulty.Easy)
                {
                    NavMesh.SetAreaCost(areaIndex, 1f);
                }
                else if(difficulty == Difficulty.Medium)
                {
                    if(Random.Range(0.0f,1.0f) > 0.6f)
                    {
                        NavMesh.SetAreaCost(areaIndex, 4f);
                        //Debug.Log(areaName + ": " + 4f);
                    }
                    else
                    {
                        NavMesh.SetAreaCost(areaIndex, 2f);
                        //Debug.Log(areaName + ": " + 2f);
                    }
                }
                else
                {
                    NavMesh.SetAreaCost(areaIndex, 4f);
                }
                
                //Debug.Log(areaName + ": " + NavMesh.GetAreaCost(areaIndex));
            }
            else if(randomInt % 3 == 2)
            {
                speed = 40.0f;
                rendererObject.material.color = Color.green;
                string areaName = rendererObject.gameObject.name;
                int areaIndex = NavMesh.GetAreaFromName(areaName);
                if (difficulty == Difficulty.Easy)
                {
                    NavMesh.SetAreaCost(areaIndex, 4f);
                }
                else if (difficulty == Difficulty.Medium)
                {
                    if (Random.Range(0.0f, 1.0f) > 0.6f)
                    {
                        NavMesh.SetAreaCost(areaIndex, 1f);
                        //Debug.Log(areaName + ": " + 1f);
                    }
                    else
                    {
                        NavMesh.SetAreaCost(areaIndex, 2f);
                        //Debug.Log(areaName + ": " + 2f);
                    }
                }
                else
                {
                    NavMesh.SetAreaCost(areaIndex, 1f);
                }
                //Debug.Log(areaName + ": " + NavMesh.GetAreaCost(areaIndex));
            }
            else
            {
                speed = 20.0f;
                rendererObject.material.color = defaultColor;
                string areaName = rendererObject.gameObject.name;
                int areaIndex = NavMesh.GetAreaFromName(areaName);
                NavMesh.SetAreaCost(areaIndex, 2f);
                //Debug.Log(areaName + ": " + 2f);
                //Debug.Log(areaName + ": " + NavMesh.GetAreaCost(areaIndex));
            }
            
            
        }
    }
}
