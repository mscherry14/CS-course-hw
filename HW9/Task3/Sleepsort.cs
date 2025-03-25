namespace Task3
{
    public class Sleepsort
    {
        private readonly LinkedList<string> _sortedList = new LinkedList<string>();

        private readonly object _lockObject = new object();

        private CountdownEvent _countdown;

        public void Sort(string[] strings)
        {
            _countdown = new CountdownEvent(strings.Length);

            foreach (var str in strings)
            {
                new Thread(() => ProcessString(str)).Start();
            }

            _countdown.Wait();
        }

        private void ProcessString(string str)
        {
            Thread.Sleep(str.Length * 100);

            lock (_lockObject)
            {
                _sortedList.AddLast(str);
            }

            _countdown.Signal();
        }

        public IEnumerable<string> GetSortedList()
        {
            lock (_lockObject)
            {
                return new List<string>(_sortedList);
            }
        }
    }
}