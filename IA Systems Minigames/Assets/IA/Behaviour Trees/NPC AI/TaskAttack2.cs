using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using IA;

public class TaskAttack2 : Node
{
    private static int _ammunitionLayerMask = 1 << 12;

    private Transform _transform;

    public TaskAttack2(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Attack2");

        if (GuardBT.shot == false)
        {
            GuardBT.shot = true;
            Collider[] colliders = Physics.OverlapSphere(_transform.position, 6.0f, _ammunitionLayerMask);
            if (colliders.Length > 0)
            {
                GameObject gameObject = colliders[0].gameObject;
                gameObject.SetActive(false);
            }

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