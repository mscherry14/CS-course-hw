namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "apple", "banana", "kiwi", "orange", "grape" };
            PartA(strings);
        }

        private static void PartA(string[] strings)
        {
            foreach (var str in strings)
            {
                new Thread(() =>
                {
                    Thread.Sleep(str.Length * 100);
                    Console.WriteLine(str);
                }).Start();
            }
        }
    }
}