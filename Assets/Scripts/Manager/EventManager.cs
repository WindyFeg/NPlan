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