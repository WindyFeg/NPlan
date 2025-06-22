using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class NPCBase : HumanBase, INPC
    {
        #region Private Field
        [Header("NPC Type")]
        [SerializeField] NPCType npcType = NPCType.Sickness;
        [SerializeField] private NPCFunctionType nPCFunctionType = NPCFunctionType.None;
        [SerializeField] private NPCWarriorType nPCWarriorType = NPCWarriorType.None;
        [Header("NPC Unique Stats")]
        [SerializeField] private int happiness = 0;
        #endregion

        #region Public Properties
        public NPCType NpcType
        {
            get => npcType;
            set
            {
                if (npcType.Equals(NPCType.Sickness) && value.Equals(NPCType.Jobless))
                {
                    nPCFunctionType = NPCFunctionType.None;
                    nPCWarriorType = NPCWarriorType.None;
                    npcType = value;
                }
            }
        }
        public int Happiness
        {
            set { happiness = value; }
            get { return happiness; }
        }
        [Header("NPC Type")]
        // Handle for correct assign job
        public NPCFunctionType NPCFunctionType
        {
            set
            {
                if (nPCFunctionType.Equals(NPCFunctionType.None) || nPCWarriorType.Equals(NPCWarriorType.None))
                {
                    if (NpcType.Equals(NPCType.Function) || NpcType.Equals(NPCType.Jobless))
                    {
                        nPCFunctionType = value;
                        nPCWarriorType = NPCWarriorType.None;
                        NpcType = NPCType.Function;
                    }
                    else
                    {
                        LTK268Log.LogFalseConfig($"Can not assign {value} to {npcType}", this);
                    }
                }
            }
            get
            {
                return nPCFunctionType;
            }
        }
        // Handle for correct assign job
        public NPCWarriorType NPCWarriorType
        {
            set
            {
                if (nPCFunctionType.Equals(NPCFunctionType.None) || nPCWarriorType.Equals(NPCWarriorType.None))
                {
                    if (NpcType.Equals(NPCType.Function) || NpcType.Equals(NPCType.Jobless))
                    {
                        nPCWarriorType = value;
                        nPCFunctionType = NPCFunctionType.None;
                        NpcType = NPCType.Function;
                    }
                    else
                    {
                        LTK268Log.LogFalseConfig($"Can not assign {value} to {npcType}", this);
                    }
                }
            }
            get
            {
                return nPCWarriorType;
            }
        }
        #endregion

        #region Public Unity Methods
        void OnValidate()
        {
            if (!gameObject.CompareTag("NPC"))
            {
                gameObject.tag = "NPC";
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

        public void CureSickness()
        {
            NpcType = NPCType.Jobless;
        }

        public bool IsFunctionNPC() => NPCFunctionType != NPCFunctionType.None;

        public bool IsWarriorNPC() => NPCWarriorType != NPCWarriorType.None;

        public override string ToString()
        {
            return base.ToString() +
               $"NPCBase: npcType={npcType}, nPCFunctionType={nPCFunctionType}, nPCWarriorType={nPCWarriorType}, happiness={happiness}\n";
        }

        public void Talk()
        {
            throw new System.NotImplementedException();
        }

        #endregion


    }
}