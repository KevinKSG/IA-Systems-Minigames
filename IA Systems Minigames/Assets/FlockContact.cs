using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlockContact : MonoBehaviour
{
    private static int _enemyLayerMask = 1 << 6;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.7f, _enemyLayerMask);

        if(colliders.Length > 0)
        {
            
            colliders[0].gameObject.GetComponent<PlayerController>().loseFlocking();

        }
    }
}
