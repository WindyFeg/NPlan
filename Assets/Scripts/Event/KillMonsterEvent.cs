using LTK268.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace LTK268.Event
{
    [CreateAssetMenu(menuName = "NightEvents/Kill Multiple Enemies")]
    public class KillEnemyEvent : EventBase
    {
        public List<KillTarget> killTargets = new();

        private Dictionary<EnemyType, int> killProgress = new();

        public override void BeginEvent()
        {
            Debug.Log("Multiple Enemy Hunt Started!");
            killProgress.Clear();
            foreach (var target in killTargets)
            {
                killProgress[target.enemyType] = 0;
                Debug.Log($"Kill {target.killRequired} of {target.enemyType}");
            }
        }

        public void RegisterKill(EnemyType killedType)
        {
            if (!killProgress.ContainsKey(killedType)) return;

            killProgress[killedType]++;
            Debug.Log($"{killedType} killed. {killProgress[killedType]}/{GetRequiredKill(killedType)}");

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
