using System;
using System.Collections.Generic;
using LTK268.Utils;

using System;
using System.Collections.Generic;
using LTK268.Enemy;
using LTK268.Event;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LTK268.Manager
{
    public class EventManager : MonoBehaviour
    {
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
                LTK268Log.ManagerError("TriggerRandomEvent: No events available");
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
        }

        public void CompleteCurrentEvent()
        {
            if (currentEvent == null)
            {
                LTK268Log.ManagerError("CompleteCurrentEvent: No current event to complete");
                return;
            }

            currentEvent.EndEvent();
            LTK268Log.ManagerLog($"Event completed: {currentEvent.GetType().Name}");
            currentEvent = null;
            EnemyManager.Instance.SetIsInEvent(false);
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerRandomEvent();
            }
        }
#endif
    }
}