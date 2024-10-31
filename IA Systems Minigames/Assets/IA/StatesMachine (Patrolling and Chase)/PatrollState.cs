using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrollState : StateMachineBehaviour
{

    
    List<Transform> wayPoints = new List<Transform> ();
    NavMeshAgent agent;
    Transform player;
    //float chaseRange = 10;

    FieldOfView fov;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fov = animator.GetComponent<FieldOfView>();
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 5.0f;

        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform) 
            wayPoints.Add(t);

        int randomWayPoint = Random.Range(1, wayPoints.Count);
        Debug.Log(wayPoints.Count);
        agent.SetDestination(wayPoints[randomWayPoint].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("isPatrolling", false);
        }

        //float distance = Vector3.Distance(player.position, animator.transform.position);
        if (fov.canSeePlayer)
        {
            animator.SetBool("isChasing", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }


}
