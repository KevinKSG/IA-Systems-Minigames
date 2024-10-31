using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using CrashKonijn.Goap.Interfaces;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        //Debug.Log("Apatrullando");
        if (_waiting)
        {
            _waitCounter += Time.fixedDeltaTime;
            if(_waitCounter >= _waitTime)
                _waiting = false;
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if(Vector3.Distance(_transform.position, wp.position) < 1.5f)
            {
                _waitCounter = 0f;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                GuardBT.agent2.SetDestination(wp.position);
                _transform.LookAt(wp.position);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
