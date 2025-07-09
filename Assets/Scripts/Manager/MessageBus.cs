
namespace LTK268.Manager
{
    public class MessageBus : IMessageBus
    {
		private Dictionary<MessageType, List<Action>> observers = new Dictionary<MessageBusType, List<Action>>(50);

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