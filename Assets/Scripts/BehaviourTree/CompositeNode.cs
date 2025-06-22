using System;
using System.Collections.Generic;
using LTK268.BehaviourTree.Actions;
using UnityEngine;

namespace LKT268.BehaviourTree
{
    /// <summary>
    /// Base class for all composite nodes (Sequence, Selector, etc).
    /// </summary>
    public abstract class CompositeNode : BTNode
    {
        public List<BTNode> children = new List<BTNode>();

        public override NodeState State => state;
        protected NodeState state;

        public void AddChild(BTNode node)
        {
            node.Parent = this;
            children.Add(node);
        }

        public override NodeState Run()
        {
            throw new NotImplementedException("Tick method must be implemented in derived classes.");
        }
    }

    public class Sequence : CompositeNode
    {
        /// <summary>
        /// Runs all child nodes in sequence.
        /// If any child returns Failure or Running, the sequence stops and returns that state.
        /// If all children return Success, the sequence returns Success.
        /// </summary>
        public override NodeState Run()
        {
            // no child -> then failed (sometime designer forgot to add Leaf nodes)
            if (children.Count == 0) return NodeState.Failure;
            // evaluate childs
            for (int n = 0, amount = children.Count; n < amount; n++)
            {
                var state = children[n].Run();
                // break when reach any child that return Failure or Running
                if (state != NodeState.Success) return state;
            }
            // all child are Success, then return Success
            return NodeState.Success;
        }
    }

    public class Selector : CompositeNode
    {
        public override NodeState Run()
        {
            // no child -> then failed (sometime designer forgot to add Leaf node in tree)
            if (children.Count == 0) return NodeState.Failure;
            // evaluate childs
            for (int n = 0, amount = children.Count; n < amount; n++)
            {
                var state = children[n].Run();
                // break when reach the first child with status = Sucess or Running (not Failure)
                if (state != NodeState.Failure) return state;
            }
            // no child success or running, then return failed
            return NodeState.Failure;
        }
    }

    public abstract class Decorator : BTNode
    {
        public BTNode child;

        /// Derivered classes will override this function to modify children node's state
        public virtual NodeState ProcessResult(NodeState childState)
        {
            return NodeState.Failure;
        }

        public override NodeState Run()
        {
            var childState = child.Run();
            return ProcessResult(childState);
        }
    }

    public abstract class Inverter : Decorator
    {
        public virtual NodeState ProcessResult(NodeState childState)
        {
            if (childState == NodeState.Success) return NodeState.Failure;
            if (childState == NodeState.Failure) return NodeState.Success;
            return NodeState.Running;
        }
    }

    public abstract class Succeeder : Decorator
    {
        public virtual NodeState ProcessResult(NodeState childState)
        {
            return NodeState.Success;
        }
    }
}
