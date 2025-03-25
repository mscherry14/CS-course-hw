namespace Task1;

public class FizzBuzz
{
    private readonly int n;
    private int current = 1;
    private readonly SemaphoreSlim fizzSemaphore = new SemaphoreSlim(0, 1); 
    private readonly SemaphoreSlim buzzSemaphore = new SemaphoreSlim(0, 1); 
    private readonly SemaphoreSlim fizzBuzzSemaphore = new SemaphoreSlim(0, 1); 
    private readonly SemaphoreSlim numberSemaphore = new SemaphoreSlim(1, 1); 

    public FizzBuzz(int n)
    {
        this.n = n;
    }

    public void Fizz(Action printFizz)
    {
        while (current <= n)
        {
            fizzSemaphore.Wait(); 
            if (current > n) 
                break; 

            printFizz(); 
            current++;
            ReleaseSemaphores();
        }
    }

    public void Buzz(Action printBuzz)
    {
        while (current <= n)
        {
            buzzSemaphore.Wait(); 
            if (current > n)
                break; 

            printBuzz(); 
            current++;
            ReleaseSemaphores(); 
        }
    }

    public void Fizzbuzz(Action printFizzBuzz)
    {
        while (current <= n)
        {
            fizzBuzzSemaphore.Wait(); 
            if (current > n) 
                break; 

            printFizzBuzz(); 
            current++;
            ReleaseSemaphores(); 
        }
    }

    public void Number(Action<int> printNumber)
    {
        while (current <= n)
        {
            numberSemaphore.Wait(); 
            if (current > n) 
                break; 

            printNumber(current); 
            current++;
            ReleaseSemaphores(); 
        }
    }

    private void ReleaseSemaphores()
    {
        if (current > n)
        {
            fizzSemaphore.Release();
            buzzSemaphore.Release();
            fizzBuzzSemaphore.Release();
            numberSemaphore.Release();
            return;
        }

        if (current % 3 == 0 && current % 5 == 0)
        {
            fizzBuzzSemaphore.Release();
        }
        else if (current % 3 == 0)
        {
            fizzSemaphore.Release();
        }
        else if (current % 5 == 0)
        {
            buzzSemaphore.Release();
        }
        else
        {
            numberSemaphore.Release();
        }
    }
}
