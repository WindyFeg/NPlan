using LTK268.Interface;
using LTK268.Manager;
using LTK268.Popups;
using LTK268.Utils;
using Unity.Behavior;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    public class NPCBase : HumanBase, INPC, IEntity
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
        void Start()
        {
            NpcManager.Instance.RegisterNPC(this);
        }
        void OnValidate()
        {
            if (!gameObject.CompareTag("NPC"))
            {
                gameObject.tag = "NPC";
                gameObject.layer = LayerMask.NameToLayer("NPC");
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
            Debug.Log($"Curing sickness for NPC: {Name}");
            NpcType = NPCType.Jobless;
            try
            {
                Debug.Log($"Setting NPCState to Wandering for NPC: {Name}");
                GetComponent<BehaviorGraphAgent>().BlackboardReference.SetVariableValue("NPCState", NPCState.Wandering);
            }
            catch (System.Exception e)
            {
                LTK268Log.LogFalseConfig($"Failed to set NPCState to Wandering: {e.Message}", this);
            }
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
            // if (Input.GetKeyDown(KeyCode.M))
            // {
            //     PopupManager.Instance.Show(
            //         PopupType.Template,
            //         "Are you sure you want to close the popup?",
            //         "Có",
            //         "Kó"
            //     );
            // }

            PopupManager.Instance.Show(
                PopupType.Ok,
                $"Hello, I am a {npcType} NPC. How can I assist you today?",
                "OK"
            );
        }

        public new void InteractWithEntity(IEntity target)
        {
            Debug.Log($"NPCBase InteractWithEntity called by {target.Name}");
            OnInteractedByEntity(target);
        }

        public new void OnInteractedByEntity(IEntity target)
        {
            Debug.Log($"NPCBase npcType: {npcType}, target: {target.Name}");
            switch (npcType)
            {
                case NPCType.Jobless:
                    Talk();
                    break;
                case NPCType.Sickness:
                    CureSickness();
                    break;
                case NPCType.Function:
                case NPCType.Warrior:
                    break;
                default:
                    LTK268Log.LogNotImplement(this);
                    break;
            }
        }
    }
    #endregion
}