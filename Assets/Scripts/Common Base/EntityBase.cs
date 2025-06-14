using UnityEngine;
using LKT268.Interface;

namespace LKT268.Model.CommonBase
{
    public class EntityBase : IEntity
    {
        #region Public Properties
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
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
        #endregion

        #region Private Fields
        private int id;
        private string name;
        private int currentHealth;
        private int maxHealth;
        private int level;
        private int damage;
        private int armor;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the EntityBase class with default values.
        /// </summary>
        public EntityBase(int id, string name, int maxHealth, int level, int damage)
        {
            this.id = id;
            this.name = name;
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
            return $"EntityBase: Name={Name}, ID={Id}, Level={Level}, Health={CurrentHealth}/{MaxHealth}, Damage={Damage}, Armor={Armor}";
        }
        #endregion
    }
}
