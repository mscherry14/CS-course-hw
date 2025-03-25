using System.Text;
using Task1;

namespace Tests;

[TestClass]
public class Task1Tests
{
    [TestMethod]
    public void Test_ZeroEvenOdd_OutputCorrectSequence()
    {
        // Arrange
        int n = 5;
        var zeroEvenOdd = new ZeroEvenOdd(n);
        var output = new StringBuilder();

        Action<int> printNumber = (x) => { output.Append(x); };

        // Act
        var threadZero = new Thread(() => zeroEvenOdd.Zero(printNumber));
        var threadEven = new Thread(() => zeroEvenOdd.Even(printNumber));
        var threadOdd = new Thread(() => zeroEvenOdd.Odd(printNumber));

        threadZero.Start();
        threadEven.Start();
        threadOdd.Start();

        threadZero.Join();
        threadEven.Join();
        threadOdd.Join();

        // Assert
        Assert.AreEqual("0102030405", output.ToString());
    }

    [TestMethod]
    public void Test_ZeroEvenOdd_WithN2_OutputCorrectSequence()
    {
        // Arrange
        int n = 2;
        var zeroEvenOdd = new ZeroEvenOdd(n);
        var output = new StringBuilder();

        Action<int> printNumber = (x) => { output.Append(x); };

        // Act
        var threadZero = new Thread(() => zeroEvenOdd.Zero(printNumber));
        var threadEven = new Thread(() => zeroEvenOdd.Even(printNumber));
        var threadOdd = new Thread(() => zeroEvenOdd.Odd(printNumber));

        threadZero.Start();
        threadEven.Start();
        threadOdd.Start();

        threadZero.Join();
        threadEven.Join();
        threadOdd.Join();

        // Assert
        Assert.AreEqual("0102", output.ToString());
    }

    [TestMethod]
    public void Test_ZeroEvenOdd_WithN1_OutputCorrectSequence()
    {
        // Arrange
        int n = 1;
        var zeroEvenOdd = new ZeroEvenOdd(n);
        var output = new StringBuilder();

        Action<int> printNumber = (x) => { output.Append(x); };

        // Act
        var threadZero = new Thread(() => zeroEvenOdd.Zero(printNumber));
        var threadEven = new Thread(() => zeroEvenOdd.Even(printNumber));
        var threadOdd = new Thread(() => zeroEvenOdd.Odd(printNumber));

        threadZero.Start();
        threadEven.Start();
        threadOdd.Start();

        threadZero.Join();
        threadEven.Join();
        threadOdd.Join();

        // Assert
        Assert.AreEqual("01", output.ToString());
    }
}