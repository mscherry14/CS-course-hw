using Task4;

namespace Tests;

[TestClass]
public class Task4Tests
{
 [TestMethod]
    public void TestCreateBook()
    {
        // Arrange
        string text = "This dog eats too much vegetables after lunch";
        int wordsPerPage = 3;
        var dictionary = new Dictionary<string, string>
        {
            { "this", "эта" },
            { "dog", "собака" },
            { "eats", "ест" },
            { "too", "слишком" },
            { "much", "много" },
            { "vegetables", "овощей" },
            { "after", "после" },
            { "lunch", "обеда" }
        };

        // Act
        var pages = Task4Solution.CreateBook(text, wordsPerPage, dictionary).ToList();

        // Assert
        Assert.AreEqual(3, pages.Count);
        Assert.AreEqual("ЭТА СОБАКА ЕСТ", pages[0]);
        Assert.AreEqual("СЛИШКОМ МНОГО ОВОЩЕЙ", pages[1]);
        Assert.AreEqual("ПОСЛЕ ОБЕДА", pages[2]);
    }

    [TestMethod]
    public void TestCreateBook_SinglePage()
    {
        // Arrange
        string text = "This dog eats";
        int wordsPerPage = 5;
        var dictionary = new Dictionary<string, string>
        {
            { "this", "эта" },
            { "dog", "собака" },
            { "eats", "ест" }
        };

        // Act
        var pages = Task4Solution.CreateBook(text, wordsPerPage, dictionary).ToList();

        // Assert
        Assert.AreEqual(1, pages.Count);
        Assert.AreEqual("ЭТА СОБАКА ЕСТ", pages[0]);
    }

    [TestMethod]
    public void TestCreateBook_EmptyText()
    {
        // Arrange
        string text = "";
        int wordsPerPage = 3;
        var dictionary = new Dictionary<string, string>();

        // Act
        var pages = Task4Solution.CreateBook(text, wordsPerPage, dictionary).ToList();

        // Assert
        Assert.AreEqual(0, pages.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void TestCreateBook_MissingTranslation()
    {
        // Arrange
        string text = "This dog eats";
        int wordsPerPage = 3;
        var dictionary = new Dictionary<string, string>
        {
            { "this", "эта" },
            { "dog", "собака" }
            // Слово "eats" отсутствует в словаре
        };

        // Act
        var pages = Task4Solution.CreateBook(text, wordsPerPage, dictionary).ToList();
    }
}
