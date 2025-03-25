namespace Task2;

using System;
using System.Runtime.ExceptionServices;

public class Program
{
    public static void Main()
    {
        try
        {
            MethodThatThrowsException();
        }
        catch (Exception ex)
        {
            var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);

            RethrowException(exceptionDispatchInfo);
        }
    }

    private static void MethodThatThrowsException()
    {
        throw new InvalidOperationException("Произошла ошибка в MethodThatThrowsException!");
    }

    private static void RethrowException(ExceptionDispatchInfo exceptionDispatchInfo)
    {
        try
        {
            exceptionDispatchInfo.Throw();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Исключение было повторно выброшено:");
            Console.WriteLine(ex);
        }
    }
}