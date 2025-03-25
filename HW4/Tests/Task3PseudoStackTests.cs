using Task3PseudoStack;

namespace Tests;

[TestClass]
public class Task3PseudoStackTests
{
    [TestMethod]
    public void TestPushAndPop()
    {
        // Arrange
        var pseudoStack = new PseudoStack<int>(2);

        // Act
        pseudoStack.Push(1);
        pseudoStack.Push(2);
        pseudoStack.Push(3); 

        // Assert
        Assert.AreEqual(3, pseudoStack.Pop()); 
        Assert.AreEqual(2, pseudoStack.Pop()); 
        Assert.AreEqual(1, pseudoStack.Pop()); 
    }

    [TestMethod]
    public void TestIsEmpty()
    {
        // Arrange
        var pseudoStack = new PseudoStack<int>(2);

        // Act & Assert
        Assert.IsTrue(pseudoStack.IsEmpty());

        pseudoStack.Push(1);
        Assert.IsFalse(pseudoStack.IsEmpty());

        pseudoStack.Pop();
        Assert.IsTrue(pseudoStack.IsEmpty());
    }

    [TestMethod]
    public void TestCount()
    {
        // Arrange
        var pseudoStack = new PseudoStack<int>(2);

        // Act
        pseudoStack.Push(1);
        pseudoStack.Push(2);
        pseudoStack.Push(3);

        // Assert
        Assert.AreEqual(3, pseudoStack.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPopOnEmptyStack()
    {
        // Arrange
        var pseudoStack = new PseudoStack<int>(2);

        // Act
        pseudoStack.Pop(); 
    }

    [TestMethod]
    public void TestRemoveEmptyStack()
    {
        // Arrange
        var pseudoStack = new PseudoStack<int>(2);

        // Act
        pseudoStack.Push(1);
        pseudoStack.Push(2);
        pseudoStack.Push(3);
        pseudoStack.Pop(); 

        // Assert
        Assert.AreEqual(2, pseudoStack.Count);
    }
}