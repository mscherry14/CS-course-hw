namespace Task2EventBus
{
    public class Subscriber
    {
        public string Name { get; }

        //Свойство для тестов
        public int NotificationCount { get; private set; } = 0;

        public Subscriber(string name)
        {
            Name = name;
        }

        public void HandleEvent(object sender, EventArgs e)
        {
            NotificationCount++;
        }
    }
}
