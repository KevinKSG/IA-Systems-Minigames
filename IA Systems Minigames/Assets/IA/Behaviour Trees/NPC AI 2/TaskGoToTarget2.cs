using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget2 : Node
{
    private Transform _transform;

    public TaskGoToTarget2(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        //Debug.Log("Perseguir");
        Transform target = (Transform)GetData("target");

        if(Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            GuardBT.agent2.SetDestination(target.position);
            _transform.LookAt(target.position);
        }

        if(Vector3.Distance(_transform.position, target.position) < 1.0f)
        {
            target.gameObject.GetComponent<PlayerController>().loseGame();
        }

        state = NodeState.RUNNING;
        return state;
    }
}
