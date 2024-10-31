using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : Node
    {
        public Selector()
        {
            this.parent = null;
            this.children = new List<Node>();
        }
        public Selector(List<Node> children2)
        {
            this.children = new List<Node>();
            foreach (Node child in children2)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public override NodeState Evaluate()
        {
            
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}


