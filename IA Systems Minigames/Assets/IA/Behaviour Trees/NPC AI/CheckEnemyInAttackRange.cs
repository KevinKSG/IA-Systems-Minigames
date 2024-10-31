using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckEnemyInAttackRange : Node
{
    private static int _ammunitionLayerMask = 1 << 12;

    private Transform _transform;

    public CheckEnemyInAttackRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        //Debug.Log("Checking Attack");
        object t = GetData("target");
        if(t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Collider[] colliders = Physics.OverlapSphere(_transform.position, 6.0f, _ammunitionLayerMask);

        if(colliders.Length > 0)
        {
            parent.parent.SetData("target", colliders[0].transform);
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }

        
    }
}
