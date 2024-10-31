using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckEnemyInFOVRange2 : Node
{
    private static int _enemyLayerMask = 1 << 6;

    private Transform _transform;

    public CheckEnemyInFOVRange2(Transform transform)
    {
        _transform = transform;
        
    }

    public override NodeState Evaluate()
    {
        //Debug.Log("FOV");
        object t = GetData("target");
        if(t == null)
        {
            //Debug.Log(GuardBT.fov2.canSeePlayer);
            
            Collider[] colliders = Physics.OverlapSphere(_transform.position,GuardBT.fovRange, _enemyLayerMask);

            if(GuardBT.fov2.canSeePlayer)
            {
                parent.parent.SetData("target", colliders[0].transform);
                

                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        Collider[] colliders2 = Physics.OverlapSphere(_transform.position, GuardBT.fovRange, _enemyLayerMask);

        if (colliders2.Length > 0)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            parent.parent.ClearData("target");
            state = NodeState.FAILURE;
            return state;
        }

        
    }
}
