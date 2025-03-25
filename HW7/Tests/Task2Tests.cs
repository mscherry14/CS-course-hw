using Common;
using Task2;

namespace Tests;

[TestClass]
public class Task2Tests
{
    [TestMethod]
    public void TestFindItemsWithLongName()
    {
        // Arrange
        var items = new List<Item>
        {
            new Item("A"),
            new Item("BB"),
            new Item("CCC"),
            new Item("DD"),
            new Item("EEE"),
            new Item("FFFF")
        };

        // Act
        var result = Task2Solution.FindItemsWithLongName(items).ToList();

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("A", result[0].Name);
        Assert.AreEqual("BB", result[1].Name);
        Assert.AreEqual("CCC", result[2].Name);
    }

    [TestMethod]
    public void TestFindItemsWithLongName_EmptyList()
    {
        // Arrange
        var items = new List<Item>();

        // Act
        var result = Task2Solution.FindItemsWithLongName(items).ToList();

        // Assert
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void TestFindItemsWithLongName_NoMatches()
    {
        // Arrange
        var items = new List<Item>
        {
            new Item(""),
            new Item("A"),
            new Item("B"),
            new Item("C")
        };

        // Act
        var result = Task2Solution.FindItemsWithLongName(items).ToList();

        // Assert
        Assert.AreEqual(0, result.Count);
    }
}
