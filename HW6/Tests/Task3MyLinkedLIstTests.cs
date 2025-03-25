using Task3MyLinkedList;

namespace Tests;

[TestClass]
public class Task3MyLinkedLIstTests
{
    [TestMethod]
    public void TestAdd()
    {
        // Arrange
        var list = new MyLinkedList<int>();

        // Act
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Assert
        Assert.AreEqual(3, list.Count);
        var expected = new List<int> { 10, 20, 30 };
        CollectionAssert.AreEqual(expected, new List<int>(list));
    }

    [TestMethod]
    public void TestRemove()
    {
        // Arrange
        var list = new MyLinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        bool removed = list.Remove(20);

        // Assert
        Assert.IsTrue(removed);
        Assert.AreEqual(2, list.Count);
        var expected = new List<int> { 10, 30 };
        CollectionAssert.AreEqual(expected, new List<int>(list));
    }

    [TestMethod]
    public void TestRemoveNonExistent()
    {
        // Arrange
        var list = new MyLinkedList<int>();
        list.Add(10);
        list.Add(20);

        // Act
        bool removed = list.Remove(30);

        // Assert
        Assert.IsFalse(removed);
        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void TestRemoveFromEmptyList()
    {
        // Arrange
        var list = new MyLinkedList<int>();

        // Act
        bool removed = list.Remove(10);

        // Assert
        Assert.IsFalse(removed);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void TestRemoveFirstElement()
    {
        // Arrange
        var list = new MyLinkedList<int>();
        list.Add(10);
        list.Add(20);

        // Act
        bool removed = list.Remove(10);

        // Assert
        Assert.IsTrue(removed);
        Assert.AreEqual(1, list.Count);
        var expected = new List<int> { 20 };
        CollectionAssert.AreEqual(expected, new List<int>(list));
    }

    [TestMethod]
    public void TestRemoveLastElement()
    {
        // Arrange
        var list = new MyLinkedList<int>();
        list.Add(10);
        list.Add(20);

        // Act
        bool removed = list.Remove(20);

        // Assert
        Assert.IsTrue(removed);
        Assert.AreEqual(1, list.Count);
        var expected = new List<int> { 10 };
        CollectionAssert.AreEqual(expected, new List<int>(list));
    }
}
