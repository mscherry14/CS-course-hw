using Task2;

namespace Tests;

[TestClass]
public class Task2Tests
{
    [TestMethod]
    public void Test_FindMin()
    {
        // Arrange
        int[] array = { 5, 3, 8, 1, 9, 2 };
        var threadSafeArray = new ThreadSafeArray(array);

        // Act
        int min = threadSafeArray.FindMin();

        // Assert
        Assert.AreEqual(1, min);
    }

    [TestMethod]
    public void Test_FindAverage()
    {
        // Arrange
        int[] array = { 5, 3, 8, 1, 9, 2 };
        var threadSafeArray = new ThreadSafeArray(array);

        // Act
        double avg = threadSafeArray.FindAverage();

        // Assert
        Assert.AreEqual(4.666666666666667, avg, 0.0001);
    }
}