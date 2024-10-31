using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskAttack12 : Node
{
    private Transform _transform;

    public TaskAttack12(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Attack");

        Transform target = (Transform)GetData("target");
        Debug.Log("Distancia: " + (Vector3.Distance(_transform.position, target.position) > 1.0f));
        if (Vector3.Distance(_transform.position, target.position) > 1.0f)
        {
            GuardBT.agent2.SetDestination(target.position);
            _transform.LookAt(target.position);

            state = NodeState.FAILURE;
            return state;
        }
        else
        {
            state = NodeState.SUCCESS;
            return state;
        }

        
    }
}
