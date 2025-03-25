using Common;
using Task1;

namespace Tests;

[TestClass]
public class Task1Tests
{
    [TestMethod]
    public void TestConcatenateNames()
    {
        // Arrange
        var items = new List<Item>
        {
            new Item("Item1"),
            new Item("Item2"),
            new Item("Item3"),
            new Item("Item4"),
            new Item("Item5"),
            new Item("Item6")
        };

        // Act
        string result = TaskSolution.ConcatenateNames(items, ',');

        // Assert
        Assert.AreEqual("Item4,Item5,Item6", result);
    }

    [TestMethod]
    public void TestConcatenateNames_WithLessThanFourItems()
    {
        // Arrange
        var items = new List<Item>
        {
            new Item("Item1"),
            new Item("Item2"),
            new Item("Item3")
        };

        // Act
        string result = TaskSolution.ConcatenateNames(items, ',');

        // Assert
        Assert.AreEqual("", result); // ��������� ������ ������
    }

    [TestMethod]
    public void TestConcatenateNames_WithDifferentDelimeter()
    {
        // Arrange
        var items = new List<Item>
        {
            new Item("Item1"),
            new Item("Item2"),
            new Item("Item3"),
            new Item("Item4"),
            new Item("Item5")
        };

        // Act
        string result = TaskSolution.ConcatenateNames(items, ';');

        // Assert
        Assert.AreEqual("Item4;Item5", result);
    }
}