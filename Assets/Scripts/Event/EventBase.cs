using System;
using UnityEngine;

namespace LTK268.Event
{
    public abstract class EventBase : ScriptableObject
    {
        public string eventName;
        public string description;

        public Action OnStartEvent;
        public Action OnEndEvent;

        public abstract void BeginEvent();
        public abstract void EndEvent();
    }
}