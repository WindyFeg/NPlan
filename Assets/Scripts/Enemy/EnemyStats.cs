using System;
using UnityEngine;

namespace LKT268.Enemy
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy/New Stats", order = 0)]
    public class EnemyStats : ScriptableObject
    {
        #region Basic Stats
        public string EnemyName = "New Enemy";
        public int MaxHealth = 100;
        public int Damage = 10;
        public int Armor = 2;
        public float MoveSpeed = 2f;
        public float AttackRange = 1.5f;
        public float AttackCooldown = 1.2f;
        #endregion

        #region Detection
        public float DetectionRange = 5f;
        public float ChaseRange = 7f;
        public float LostSightDuration = 1f;
        #endregion

        #region Loot / XP
        public int ExperienceReward = 10;
        public int GoldReward = 5;
        #endregion

        #region Behavior Flags
        public bool CanPatrol = true;
        public bool CanChase = true;
        public bool CanAttack = true;
        public bool IsBoss = false;
        #endregion
    }
}