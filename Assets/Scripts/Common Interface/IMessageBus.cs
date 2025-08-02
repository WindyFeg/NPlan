using System;
using LTK268.Utils;

namespace LTK268.Interface
{
    public interface IMessageBus
    {
        void Subscribe(MessageType type, Action observer);
        void Unsubscribe(MessageType observer);
        void NotifyObservers();
    }
}