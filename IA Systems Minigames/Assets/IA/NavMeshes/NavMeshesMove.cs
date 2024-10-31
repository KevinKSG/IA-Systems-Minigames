using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static SetVelocityZone;

public class NavMeshesMove : MonoBehaviour
{

    [SerializeField]
    Transform _destination;
    NavMeshAgent _navMeshAgent;

    public CharacterController npc;
    public SetDifficulty setDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<CharacterController>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_navMeshAgent.speed);

        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        //Debug.DrawRay(ray.origin,ray.direction * 30f);

        if(Physics.Raycast(ray,out hit))
        {
            if(setDifficulty.difficulty == Difficulty.Easy)
            {
                _navMeshAgent.speed = (hit.transform.gameObject.GetComponent<SetVelocityZone>().speed) * 0.8f;
            }
            else if(setDifficulty.difficulty == Difficulty.Medium)
            {
                _navMeshAgent.speed = (hit.transform.gameObject.GetComponent<SetVelocityZone>().speed) * 0.9f;
            }
            else
            {
                _navMeshAgent.speed = hit.transform.gameObject.GetComponent<SetVelocityZone>().speed;
            }
            
            //_navMeshAgent.acceleration = hit.transform.gameObject.GetComponent<SetVelocityZone>().speed;
        }

        //Debug.Log(_navMeshAgent.speed);
        if (_navMeshAgent != null)
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position; 
            _navMeshAgent.SetDestination(targetVector);
        }
    }

}
