namespace Task2;

public class Foo
{
    private readonly ManualResetEventSlim _event1 = new ManualResetEventSlim(false);
    private readonly ManualResetEventSlim _event2 = new ManualResetEventSlim(false);

    public void First()
    {
        Console.Write("first");
        _event1.Set();
    }

    public void Second()
    {
        _event1.Wait();
        Console.Write("second");
        _event2.Set();
    }

    public void Third()
    {
        _event2.Wait();
        Console.Write("third");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Foo foo = new Foo();
        
        Thread threadA = new Thread(foo.First);
        Thread threadB = new Thread(foo.Second);
        Thread threadC = new Thread(foo.Third);
        
        threadA.Start();
        threadB.Start();
        threadC.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();

        Console.WriteLine();

        foo = new Foo();
        threadA = new Thread(foo.First);
        threadB = new Thread(foo.Second);
        threadC = new Thread(foo.Third);
        
        threadA.Start();
        threadC.Start();
        threadB.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();
    }
}