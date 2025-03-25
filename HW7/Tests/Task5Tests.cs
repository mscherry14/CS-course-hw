using Task5;

namespace Tests;

[TestClass]
public class Task5Tests
{
[TestMethod]
    public void TestBucketize_Example1()
    {
        // Arrange
        string phrase = "она продает морские раковины у моря";
        int n = 16;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string> { "она продает", "морские раковины", "у моря" };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_Example2()
    {
        // Arrange
        string phrase = "мышь прыгнула через сыр";
        int n = 8;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string> { "мышь", "прыгнула", "через", "сыр" };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_Example3()
    {
        // Arrange
        string phrase = "волшебная пыль покрыла воздух";
        int n = 15;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string> { "волшебная пыль", "покрыла воздух" };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_Example4()
    {
        // Arrange
        string phrase = "a b c d e ";
        int n = 2;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string> { "a", "b", "c", "d", "e" };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_TooSmallSegments()
    {
        // Arrange
        string phrase = "оченьдлинноеслово";
        int n = 5;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string>();
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_EmptyPhrase()
    {
        // Arrange
        string phrase = "";
        int n = 10;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string>();
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_SingleWord()
    {
        // Arrange
        string phrase = "один";
        int n = 10;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string> { "один" };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_SingleWordTooLong()
    {
        // Arrange
        string phrase = "оченьдлинноеслово";
        int n = 5;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string>();
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestBucketize_MultipleSpaces()
    {
        // Arrange
        string phrase = "  много   пробелов  между  словами  ";
        int n = 10;

        // Act
        var result = Task5Solution.Bucketize(phrase, n);

        // Assert
        var expected = new List<string> { "много", "пробелов", "между", "словами" };
        CollectionAssert.AreEqual(expected, result);
    }
}
