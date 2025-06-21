using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class NPCBase : HumanBase, INPC
    {
        #region Private Field
        [SerializeField] private NPCFunctionType nPCFunctionType = NPCFunctionType.None;
        [SerializeField] private NPCWarriorType nPCWarriorType = NPCWarriorType.None;
        #endregion

        #region Public Properties
        public NPCFunctionType NPCFunctionType
        {
            set
            {
                if (nPCFunctionType.Equals(NPCFunctionType.None) || nPCWarriorType.Equals(NPCWarriorType.None))
                {
                    nPCFunctionType = value;
                    nPCWarriorType = NPCWarriorType.None;
                }
            }
            get
            {
                return nPCFunctionType;
            }
        }

        public NPCWarriorType NPCWarriorType
        {
            set
            {
                if (nPCFunctionType.Equals(NPCFunctionType.None) || nPCWarriorType.Equals(NPCWarriorType.None))
                {
                    nPCWarriorType = value;
                    nPCFunctionType = NPCFunctionType.None;
                }
            }
            get
            {
                return nPCWarriorType;
            }
        }
        #endregion

        #region Public Method
        public NPCBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }

        public void AssignFunctionJob(NPCFunctionType _type)
        {
            NPCFunctionType = _type;
        }

        public void AssignWarriorJob(NPCWarriorType _type)
        {
            NPCWarriorType = _type;
        }

        public bool IsFunctionNPC() => NPCFunctionType != NPCFunctionType.None;

        public bool IsWarriorNPC() => NPCWarriorType != NPCWarriorType.None;
        #endregion


    }
}