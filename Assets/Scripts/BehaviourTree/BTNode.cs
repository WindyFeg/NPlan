using System;

namespace LKT268.BehaviourTree
{
    /// <summary>
    /// Base class for all Behavior Tree nodes.
    /// </summary>
    public abstract class BTNode
    {
        #region Public Properties

        /// <summary>
        /// The parent node of this node.
        /// </summary>
        public BTNode Parent { get; set; }

        /// <summary>
        /// The current state of this node.
        /// </summary>
        public abstract NodeState State { get; }

        #endregion

        #region Public Method

        /// <summary>
        /// Execute this node and return its state (Success, Failure, Running).
        /// </summary>
        public abstract NodeState Run();

        #endregion
    }
    public enum NodeState
    {
        Success,
        Failure,
        Running
    }
}
