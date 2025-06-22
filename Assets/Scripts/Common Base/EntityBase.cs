using System;
using UnityEngine;
using LKT268.Interface;
using LKT268.Utils;

namespace LKT268.Model.CommonBase
{
    [Serializable]
    public class EntityBase : MonoBehaviour, IEntity
    {
        #region Public Properties
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => entityName;
            set => entityName = value;
        }

        public int CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = value < 0 ? 0 : (value > MaxHealth ? MaxHealth : value);
        }

        public int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value < 0 ? 0 : value;
        }

        public int Level
        {
            get => level;
            set => level = value < 0 ? 0 : value;
        }
        public int Damage
        {
            get => damage;
            set => damage = value < 0 ? 0 : value;
        }
        public int Armor
        {
            get => armor;
            set => armor = value < 0 ? 0 : value;
        }
        public EntityType EntityType
        {
            get => entityType;
            set => entityType = value;
        }
        #endregion

        #region Private Fields
        [SerializeField] private int id;
        [SerializeField] private string entityName;
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;
        [SerializeField] private int level;
        [SerializeField] private int damage;
        [SerializeField] private int armor;
        [SerializeField] private EntityType entityType = EntityType.None;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the EntityBase class with default values.
        /// </summary>

        public EntityBase(int id, string name, int maxHealth, int level, int damage)
        {
            this.id = id;
            this.entityName = name;
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth; // Start with full health
            this.level = level;
            this.damage = damage;
        }

        /// <summary>
        /// Method to apply damage to the entity.
        /// </summary>
        /// <param name="amount">The amount of damage</param>
        public virtual void TakeDamage(int amount)
        {
            if (amount < 0)
            {
                Debug.LogWarning("EntityBase - TakeDamage: Damage amount cannot be negative.");
                return;
            }

            int effectiveDamage = amount - Armor;
            if (Armor >= amount)
            {
                effectiveDamage = 1;
            }
            if (effectiveDamage < 0)
            {
                effectiveDamage = 0; // Ensure damage is not negative
            }

            CurrentHealth -= effectiveDamage;
        }

        /// <summary>
        /// Method to heal the entity.
        /// </summary>
        /// <param name="amount">The amount of health</param>
        public virtual void Heal(int amount)
        {
            if (amount < 0)
            {
                Debug.LogWarning("EntityBase - Heal: Heal amount cannot be negative.");
                return;
            }
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth; // Ensure health does not exceed max health
            }
        }

        /// <summary>
        /// Method to level up the entity, increasing its level and restoring health.
        /// </summary>
        public virtual void LevelUp()
        {
            Level++;
            CurrentHealth = MaxHealth;
        }

        /// <summary>
        /// Returns a string representation of the entity, including its name, ID, level, health, and damage.
        /// </summary>
        public override string ToString()
        {
            return $"EntityBase: Name={Name}, ID={Id}, Level={Level}, Health={CurrentHealth}/{MaxHealth}, Damage={Damage}, Armor={Armor}\n";
        }

        /// <summary>
        /// Initializes the entity with default values.
        /// </summary>
        public virtual void Initialization()
        {
            Id = 0;
            Name = "Default Entity";
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            Level = 1;
            Damage = 10;
            Armor = 0;
            EntityType = EntityType.None;
            Debug.Log($"EntityBase Initialized: {this}");
        }
        #endregion

        #region Private Unity Methods
        private void Start()
        {
            Initialization();
        }
        #endregion

        #region Private Methods

        public bool IsNpc() => this.entityType == EntityType.NPC;

        public bool IsPlayer() => this.entityType == EntityType.Player;

        public bool IsObject() => this.entityType == EntityType.Object;
        #endregion
    }
}
