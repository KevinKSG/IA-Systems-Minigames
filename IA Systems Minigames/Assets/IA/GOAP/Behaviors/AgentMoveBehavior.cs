using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using IA.GOAP.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace IA.GOAP.Behaviors
{
    [RequireComponent(requiredComponent:typeof(NavMeshAgent),requiredComponent2:typeof(Animator),requiredComponent3:typeof(AgentBehaviour))]
    public class AgentMoveBehavior : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator animator;
        private AgentBehaviour agentBehaviour;
        private ITarget currentTarget;
        [SerializeField] private float minMoveDistance = 0.25f;

        private Vector3 lastPosition;
        private static readonly int WALK = Animator.StringToHash(name: "Walk");

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            agentBehaviour = GetComponent<AgentBehaviour>();
        }

        private void OnEnable()
        {
            agentBehaviour.Events.OnTargetChanged += EventsOnTargetChanged;
            agentBehaviour.Events.OnTargetOutOfRange += EventsOnTargetOutOfRange;

        }

        private void OnDisable()
        {
            agentBehaviour.Events.OnTargetChanged -= EventsOnTargetChanged;
            agentBehaviour.Events.OnTargetOutOfRange -= EventsOnTargetOutOfRange;
        }

        private void EventsOnTargetOutOfRange(ITarget target)
        {
            animator.SetBool(id: WALK, value: false);
        }

        private void EventsOnTargetChanged(ITarget target, bool inRange)
        {
            currentTarget = target;
            lastPosition = currentTarget.Position;
            agent.SetDestination(target.Position);
            animator.SetBool(id:WALK,value:true);
        }

        private void Update()
        {
            
            if(currentTarget == null)
            {
                return;
            }
            
            if (minMoveDistance <= Vector3.Distance(a:currentTarget.Position, b:lastPosition))
            {
                lastPosition = currentTarget.Position;
                if(agentBehaviour.CurrentAction != null)
                {
                    if (agentBehaviour.CurrentAction.ToString() == "IA.GOAP.Actions.ShotAction")
                    {
                        agent.SetDestination(agent.transform.position);
                    }
                    else
                    {
                        agent.SetDestination(currentTarget.Position);
                    }
                }
                
                
            }
            
            animator.SetBool(id:WALK,value:agent.velocity.magnitude > 0.1f);
        }
    }

}
