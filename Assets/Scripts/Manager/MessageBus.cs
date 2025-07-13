
using System;
using System.Collections.Generic;
using LTK268.Utils;

namespace LTK268.Manager
{
    public class MessageBus
    {
        private Dictionary<MessageType, List<Action>> observers = new Dictionary<MessageType, List<Action>>(50);

        public void Subscribe(MessageType type, Action observer)
        {
            if (!observers.ContainsKey(type))
            {
                observers[type] = new List<Action>();
            }
            observers[type].Add(observer);
        }

        public void Unsubscribe(MessageType observer)
        {
            if (observers.ContainsKey(observer))
            {
                observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            foreach (var observerList in observers.Values)
            {
                foreach (var observer in observerList)
                {
                    observer?.Invoke();
                }
            }
        }
    }
}