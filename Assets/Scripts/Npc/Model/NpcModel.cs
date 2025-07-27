using LTK268.Interface;
using LTK268.Manager;
using LTK268.Utils;
using Unity.Behavior;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    public class NpcModel : NPCBase
    {
        #region Public Properties
        public int PickupDistance { get => pickupDistance; set => pickupDistance = value; }
        #endregion

        #region Private Fields
        [SerializeField] private int pickupDistance = 2;
        [SerializeField] private BehaviorGraph sicknessBehaviorGraph;
        [SerializeField] private BehaviorGraph joblessBehaviorGraph;
        #endregion

        #region Public Constructors
        public NpcModel(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Methods
        #endregion

        #region Unity Methods
        private void Start()
        {
            Initialization();
            NpcManager.Instance.RegisterNPC(this);
        }
        #endregion

        #region Public Methods  
        public override void Initialization()
        {
            // This is temp initialization all if the init will be handle by game manager
            Id = 1;
            Name = "Jobless_NPC";
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            Level = 1;
            Damage = 10;
            Armor = 0;
            EntityType = EntityType.NPC;
            this.NpcType = NPCType.Sickness;
            pickupDistance = 2;
        }
        #endregion
    }

}