using IA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node _root = null;
        public FieldOfView fov;
        public NavMeshAgent agent;
        public Shot2 bullet;

        protected void Start()
        {
            fov = GetComponent<FieldOfView>();
            agent = GetComponent<NavMeshAgent>();

            _root = SetupTree(fov,agent,bullet);
        }

        private void Update()
        {
            if(_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree(FieldOfView fov, NavMeshAgent agent, Shot2 bullet);
    }
}

