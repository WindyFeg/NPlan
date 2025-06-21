using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class NpcBehaviour : HumanBase, IHumanControl
    {
        #region Public Properties
        public NPCType NpcType
        {
            get => npcType;
            set => npcType = value;
        }
        #endregion

        #region Private Fields
        [SerializeField] NPCType npcType;
        #endregion

        #region Public Constructors
        public NpcBehaviour(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Methods
        #endregion

        #region Public Methods
        public override void Initialization()
        {
            base.Initialization();
        }
        #endregion
    }

}