using Task1FrogAndLake;

namespace Tests;

[TestClass]
public class Task1FrogAndLakeTests
{
    [TestMethod]
    public void TestExample1()
    {
        // Arrange
        var stones = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        var lake = new Lake(stones);

        // Act
        var result = new List<int>();
        foreach (var stone in lake)
        {
            result.Add(stone);
        }

        // Assert
        var expected = new List<int> { 1, 3, 5, 7, 8, 6, 4, 2 };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestExample2()
    {
        // Arrange
        var stones = new List<int> { 13, 23, 1, -8, 4, 9 };
        var lake = new Lake(stones);

        // Act
        var result = new List<int>();
        foreach (var stone in lake)
        {
            result.Add(stone);
        }

        // Assert
        var expected = new List<int> { 13, 23, 1, 9, 4, -8 };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestEmptyLake()
    {
        // Arrange
        var stones = new List<int>();
        var lake = new Lake(stones);

        // Act
        var result = new List<int>();
        foreach (var stone in lake)
        {
            result.Add(stone);
        }

        // Assert
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void TestSingleStone()
    {
        // Arrange
        var stones = new List<int> { 5 };
        var lake = new Lake(stones);

        // Act
        var result = new List<int>();
        foreach (var stone in lake)
        {
            result.Add(stone);
        }

        // Assert
        var expected = new List<int> { 5 };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestNegativeNumbers()
    {
        // Arrange
        var stones = new List<int> { -3, -2, -1, 0, 1, 2, 3 };
        var lake = new Lake(stones);

        // Act
        var result = new List<int>();
        foreach (var stone in lake)
        {
            result.Add(stone);
        }

        // Assert
        var expected = new List<int> { -3, -1, 1, 3, 2, 0, -2 };
        CollectionAssert.AreEqual(expected, result);
    }
}