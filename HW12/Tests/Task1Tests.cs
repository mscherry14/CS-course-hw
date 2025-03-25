using System.Text;
using Task1;

namespace Tests;

[TestClass]
public class Task1Tests
{
    [TestMethod]
    public void Test_FizzBuzz_WithN5()
    {
        // Arrange
        int n = 5;
        var fizzBuzz = new FizzBuzz(n);
        var output = new StringBuilder();

        // Act
        var threadA = new Thread(() => fizzBuzz.Fizz(() => output.Append("Fizz, ")));
        var threadB = new Thread(() => fizzBuzz.Buzz(() => output.Append("Buzz, ")));
        var threadC = new Thread(() => fizzBuzz.Fizzbuzz(() => output.Append("FizzBuzz, ")));
        var threadD = new Thread(() => fizzBuzz.Number(x => output.Append($"{x}, ")));

        threadA.Start();
        threadB.Start();
        threadC.Start();
        threadD.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();
        threadD.Join();

        // Assert
        string expected = "1, 2, Fizz, 4, Buzz, ";
        Assert.AreEqual(expected, output.ToString());
    }

    [TestMethod]
    public void Test_FizzBuzz_WithN15()
    {
        // Arrange
        int n = 15;
        var fizzBuzz = new FizzBuzz(n);
        var output = new StringBuilder();

        // Act
        var threadA = new Thread(() => fizzBuzz.Fizz(() => output.Append("Fizz, ")));
        var threadB = new Thread(() => fizzBuzz.Buzz(() => output.Append("Buzz, ")));
        var threadC = new Thread(() => fizzBuzz.Fizzbuzz(() => output.Append("FizzBuzz, ")));
        var threadD = new Thread(() => fizzBuzz.Number(x => output.Append($"{x}, ")));

        threadA.Start();
        threadB.Start();
        threadC.Start();
        threadD.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();
        threadD.Join();

        // Assert
        string expected = "1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz, ";
        Assert.AreEqual(expected, output.ToString());
    }

    [TestMethod]
    public void Test_FizzBuzz_WithN1()
    {
        // Arrange
        int n = 1;
        var fizzBuzz = new FizzBuzz(n);
        var output = new StringBuilder();

        // Act
        var threadA = new Thread(() => fizzBuzz.Fizz(() => output.Append("Fizz, ")));
        var threadB = new Thread(() => fizzBuzz.Buzz(() => output.Append("Buzz, ")));
        var threadC = new Thread(() => fizzBuzz.Fizzbuzz(() => output.Append("FizzBuzz, ")));
        var threadD = new Thread(() => fizzBuzz.Number(x => output.Append($"{x}, ")));

        threadA.Start();
        threadB.Start();
        threadC.Start();
        threadD.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();
        threadD.Join();

        // Assert
        string expected = "1, ";
        Assert.AreEqual(expected, output.ToString());
    }
}