using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePoint : MonoBehaviour
{
    Transform player;
    Transform enemy;

    List<Transform> spawnPoints = new List<Transform>();

    public int playerPoints = 0;
    public int enemyPoints = 0;
    private float getPointsDistance = 4.0f;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
            spawnPoints.Add(t);
    }

    // Update is called once per frame
    void Update()
    {
        

        //Debug.Log("Player: " + playerPoints);
        //Debug.Log("Enemy: " + enemyPoints);

        float distancePlayer = Vector3.Distance(player.position, transform.position);
        float distanceEnemy = Vector3.Distance(enemy.position, transform.position);

        if (distancePlayer < getPointsDistance)
        {
            playerPoints += 10;
            transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        }

        if(distanceEnemy < getPointsDistance)
        {
            enemyPoints += 10;
            transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        }


    }
}
