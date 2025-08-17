using System.Collections.Generic;
using LTK268.Utils;
using LTK268.Event;
using LTK268.Popups;
using Unity.AppUI.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LTK268.Manager
{
    public class EventManager : MonoBehaviour
    {
        [Tooltip("Event chance = 1 / eventRate. (e.g. 2 = 50%, 4 = 25%)")]
        public int eventRate = 6;
        public static EventManager Instance;
        public List<EventBase> events;

        private EventBase currentEvent;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
        
        public void TriggerRandomEvent()
        {
            if (events == null || events.Count == 0)
            {
                return;
            }
            
            // Roll the eventRate dice
            var rnd = Random.Range(0, eventRate);
            if (rnd != 0)
            {
                LTK268Log.LogInfo($"EventManager: {rnd} => There is no event tonight");
                return;
            }

            currentEvent = Instantiate(events[Random.Range(0, events.Count)]);
            if (currentEvent == null)
            {
                LTK268Log.ManagerError("TriggerRandomEvent: Failed to instantiate event");
                return;
            }

            currentEvent.BeginEvent();
            currentEvent.OnEndEvent += CompleteCurrentEvent; // Register end event action
            EnemyManager.Instance.SetIsInEvent(true);
            LTK268Log.ManagerLog($"Random event triggered: {currentEvent.GetType().Name}");
            PopupManager.Instance.Show(PopupType.Toast, $"{currentEvent.eventName}", $"{currentEvent.description}");
        }

        public void CompleteCurrentEvent()
        {
            if (currentEvent == null)
            {
                LTK268Log.ManagerError("CompleteCurrentEvent: No current event to complete");
                return;
            }

            PopupManager.Instance.Show(PopupType.Toast, "Event Completed!");
            LTK268Log.ManagerLog($"Event completed: {currentEvent.GetType().Name}");
            currentEvent = null;
            EnemyManager.Instance.SetIsInEvent(false);
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TriggerRandomEvent();
            }
        }
#endif
    }
}