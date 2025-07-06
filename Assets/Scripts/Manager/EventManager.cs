using System;
using System.Collections.Generic;
using LKT268.Utils;

namespace LKT268.Manager
{
    public class EventManager : UnityEngine.MonoBehaviour
    {
        private static readonly Dictionary<EventType, Action> eventTable = new Dictionary<EventType, Action>();
        private static EventType? currentEvent;

        public static EventType? CurrentEvent => currentEvent;
        // instance set awake
        public static EventManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static void Subscribe(EventType eventType, Action listener)
        {
            if (eventTable.ContainsKey(eventType))
                eventTable[eventType] += listener;
            else
                eventTable[eventType] = listener;
        }

        public static void Unsubscribe(EventType eventType, Action listener)
        {
            if (eventTable.ContainsKey(eventType))
            {
                eventTable[eventType] -= listener;
                if (eventTable[eventType] == null)
                    eventTable.Remove(eventType);
            }
        }

        public static void Trigger(EventType eventType)
        {
            currentEvent = eventType;
            if (eventTable.ContainsKey(eventType))
                eventTable[eventType]?.Invoke();
            currentEvent = null;
        }
    }
}
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
            DontDestroyOnLoad(gameObject);
        }
        
        public void TriggerRandomEvent()
        {
            currentEvent = Instantiate(events[Random.Range(0, events.Count)]);
            currentEvent.BeginEvent();
            currentEvent.OnEndEvent += CompleteCurrentEvent; // Register end event action
            EnemyManager.Instance.SetIsInEvent(true);
        }

        public void CompleteCurrentEvent()
        {
            currentEvent.EndEvent();
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