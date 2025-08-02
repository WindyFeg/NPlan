using System.Collections.Generic;
using UnityEngine;

namespace LTK268.Interface
{
    /// <summary>
    /// Interface for human control, extending IEntityControl.
    /// </summary>
    public interface IHumanControl : IEntityControl
    {
        /// <summary>
        /// Called when entity is dead
        /// </summary>
        void Dead();
    }

    public interface IHumanCommonChecking
    {
        /// <summary>
        /// Use to check if that NPC is an Functional NPC()
        /// </summary>
        /// <returns></returns>
        public bool IsHuman();
    }

    public interface IHuman : IHumanCommonChecking, IHumanControl
    {
        List<GameObject> HoldItems { get; set; }
        int MaxNumberOfHoldItems { get; set; }
        /// <summary>
        /// List of items that the human is currently holding.
        /// </summary>
        public void AddHoldItem(GameObject item);
        /// <summary>
        /// Removes an item from the human's hold items.
        /// </summary>
        public GameObject RemoveHoldItem();
    }
}