namespace Task2EventBus
{
    public delegate void EventHandler(object sender, EventArgs e);

    public class Publisher
    {
        public event EventHandler Event;

        public void RaiseEvent(EventArgs args)
        {
            Event?.Invoke(this, args);
        }
    }
}
