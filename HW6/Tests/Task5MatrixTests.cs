using Task5Matrix;

namespace Tests;

[TestClass]
public class Task5MatrixTests
{
    [TestMethod]
    public void TestAddAndAccess()
    {
        // Arrange
        var matrix = new SparseMatrix2D<string>();

        // Act
        matrix[0, 0] = "A";
        matrix[1, 1] = "B";

        // Assert
        Assert.AreEqual("A", matrix[0, 0]);
        Assert.AreEqual("B", matrix[1, 1]);
        Assert.AreEqual(null, matrix[2, 2]);
    }

    [TestMethod]
    public void TestRemove()
    {
        // Arrange
        var matrix = new SparseMatrix2D<string>();
        matrix[0, 0] = "A";

        // Act
        matrix[0, 0] = null;

        // Assert
        Assert.AreEqual(null, matrix[0, 0]);
        Assert.AreEqual(0, matrix.Count);
    }

    [TestMethod]
    public void TestEnumerate()
    {
        // Arrange
        var matrix = new SparseMatrix2D<string>();
        matrix[0, 0] = "A";
        matrix[1, 1] = "B";

        // Act
        var values = matrix.ToList();

        // Assert
        CollectionAssert.AreEqual(new[] { "A", "B" }, values);
    }
}
