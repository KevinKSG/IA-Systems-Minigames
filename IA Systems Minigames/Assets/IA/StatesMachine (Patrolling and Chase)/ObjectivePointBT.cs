using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointBT : MonoBehaviour
{
    Transform player;
    public PlayerPoints playerPoints;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;

    List<Transform> spawnPoints = new List<Transform>();

    public float getPointsDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        spawnPoints.Add(spawn1);
        spawnPoints.Add(spawn2);
        spawnPoints.Add(spawn3);

        int spawnPos = Random.Range(0, 2);
        transform.position = spawnPoints[spawnPos].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float distancePlayer = Vector3.Distance(player.position, transform.position);
        //Debug.Log("Transform: " + transform.position);
        //Debug.Log("DistancePlayer: " + distancePlayer);

        if (distancePlayer < getPointsDistance)
        {
            playerPoints.GetPoint();
            gameObject.SetActive(false);
        }

    }
}
