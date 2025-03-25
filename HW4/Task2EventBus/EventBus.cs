namespace Task2EventBus
{
    public class EventBus
    {
        private static readonly Lazy<EventBus> _instance = new Lazy<EventBus>(() => new EventBus());
        public static EventBus Instance => _instance.Value;

        private readonly Dictionary<Publisher, List<Subscriber>> _subscriptions = new();

        private EventBus() { }

        public void Subscribe(Publisher publisher, Subscriber subscriber)
        {
            if (!_subscriptions.ContainsKey(publisher))
            {
                _subscriptions[publisher] = new List<Subscriber>();
            }

            if (!_subscriptions[publisher].Contains(subscriber))
            {
                _subscriptions[publisher].Add(subscriber);
                publisher.Event += subscriber.HandleEvent;
            }
        }

        public void Unsubscribe(Publisher publisher, Subscriber subscriber)
        {
            if (_subscriptions.ContainsKey(publisher))
            {
                _subscriptions[publisher].Remove(subscriber);
                publisher.Event -= subscriber.HandleEvent;
            }
        }

        public void Notify(Publisher publisher, EventArgs args)
        {
            if (_subscriptions.ContainsKey(publisher))
            {
                publisher.RaiseEvent(args);
            }
        }
    }
}
