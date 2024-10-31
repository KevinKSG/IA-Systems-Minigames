using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using IA;
using IA.GOAP.Config;

public class TaskAttack3 : Node
{
    private static int _enemyLayerMask = 1 << 6;
    //private static int _bulletLayerMask = 1 << 13;

    private Transform _transform;

    public TaskAttack3(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Attack3");

        Collider[] colliders = Physics.OverlapSphere(_transform.position, 100, _enemyLayerMask);
        parent.parent.SetData("target", colliders[0].transform);
        Transform target = (Transform)GetData("target");

        if (GuardBT.shot==true)
        {
            Debug.Log("Pium");
            //Shot shot;
            //GameObject.Instantiate(shot);
    

            if(GuardBT.shot)
            {
                _transform.LookAt(target.position);
                Shot2 bulletObj = GameObject.Instantiate(GuardBT.bullet2);
                bulletObj.transform.position = _transform.position;
                bulletObj.transform.forward = _transform.forward;
                bulletObj.gameObject.SetActive(true);
                bulletObj.Rigidbody.AddForce(_transform.forward * 5, ForceMode.Impulse);

                GuardBT.shot = false;
                state = NodeState.SUCCESS;
                return state;
            }
            else
            {
                state = NodeState.FAILURE;
                return state;
            }

            
            
        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }

        
    }
}
