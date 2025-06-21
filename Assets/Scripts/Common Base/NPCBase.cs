using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class NPCBase : HumanBase
    {
        public NPCBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #region Public Properties
        public new EntityType GetEntityType() => EntityType.NPC;

        #endregion


    }
}