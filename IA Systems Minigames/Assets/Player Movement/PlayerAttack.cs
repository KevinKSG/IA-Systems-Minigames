using CrashKonijn.Goap.Interfaces;
using IA;
using IA.GOAP.Config;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public Melee MeleePrefab;
    public Shot ShotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shot instance = GameObject.Instantiate(ShotPrefab);
            instance.gameObject.SetActive(true);

            instance.transform.position = transform.position + (transform.forward * 3);
            instance.transform.forward = transform.forward;
            instance.Rigidbody.AddForce(instance.transform.forward * instance.Force, ForceMode.Impulse);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Melee instance = GameObject.Instantiate(MeleePrefab);
            instance.gameObject.SetActive(true);

            instance.transform.position = transform.position + (transform.forward * 2f);
            instance.transform.forward = transform.forward;
        }
        
    }
}
