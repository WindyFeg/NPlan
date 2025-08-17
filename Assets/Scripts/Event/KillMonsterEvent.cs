using LTK268.Enemy;
using System.Collections.Generic;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace LTK268.Event
{
    [CreateAssetMenu(menuName = "NightEvents/Kill Multiple Enemies")]
    public class KillEnemyEvent : EventBase
    {
        public List<KillTarget> killTargets = new();

        private Dictionary<EnemyType, int> killProgress = new();

        public override void BeginEvent()
        {
            Debug.Log("Kill Enemy Event Started!");
            killProgress.Clear();

            foreach (var target in killTargets)
            {
                killProgress[target.enemyType] = 0;

                for (int i = 0; i < target.killRequired; i++)
                {
                    // Random spawn position
                    var enemyBase = EnemyManager.Instance.SpawnEnemy(target.enemyType);
                    enemyBase.OnDead += RegisterKill;
                }
            }
        }

        public void RegisterKill(EnemyBase enemyBase)
        {
            enemyBase.OnDead -= RegisterKill; // Unsubscribe immediately
            
            var killedType = enemyBase.EnemyType;
            if (!killProgress.ContainsKey(killedType)) return;

            killProgress[killedType]++;
            Debug.Log($"RegisterKill: {killedType} killed. {killProgress[killedType]}/{GetRequiredKill(killedType)}");

            if (IsAllTargetsCompleted())
            {
                EndEvent();
            }
        }

        private int GetRequiredKill(EnemyType type)
        {
            foreach (var t in killTargets)
            {
                if (t.enemyType == type)
                    return t.killRequired;
            }
            return 0;
        }

        private bool IsAllTargetsCompleted()
        {
            foreach (var target in killTargets)
            {
                if (killProgress[target.enemyType] < target.killRequired)
                    return false;
            }
            return true;
        }

        public override void EndEvent()
        {
            Debug.Log("All enemies hunted. Event complete!");
            // Reward, notify player, etc.
            OnEndEvent?.Invoke();
        }
    }
    
    [System.Serializable]
    public class KillTarget
    {
        public EnemyType enemyType;
        public int killRequired;
    }
}
