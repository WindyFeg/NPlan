using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class NpcModel : NPCBase
    {
        #region Public Properties
        #endregion

        #region Private Fields
        #endregion

        #region Public Constructors
        public NpcModel(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Methods
        #endregion

        #region Public Methods
        public override void Initialization()
        {
            // This is temp initialization all if the init will be handle by game manager
            Id = 1;
            Name = "Default NPC";
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            Level = 1;
            Damage = 10;
            Armor = 0;
            EntityType = EntityType.NPC;
            this.NpcType = NPCType.Sickness;
        }
        #endregion
    }

}