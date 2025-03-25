using Task4;

namespace Tests;

[TestClass]
public class Task4Tests
{
    private string _testDirectory;

    [TestInitialize]
    public void Setup()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testDirectory);

        File.WriteAllText(Path.Combine(_testDirectory, "MyFile.csv"), "Test content");
        Directory.CreateDirectory(Path.Combine(_testDirectory, "SubDir"));
        File.WriteAllText(Path.Combine(_testDirectory, "SubDir", "MyFile.csv"), "Test content");
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
    }

    [TestMethod]
    public void FindFile_FileExists_ReturnsCorrectPath()
    {
        string fileName = "MyFile.csv";

        string result = FileFinder.FindFile(fileName, _testDirectory);

        Assert.IsNotNull(result);
        Assert.IsTrue(File.Exists(result));
        Assert.AreEqual(Path.GetFileName(result), fileName);
    }

    [TestMethod]
    public void FindFile_FileDoesNotExist_ReturnsNull()
    {
        string fileName = "NonExistentFile.csv";

        string result = FileFinder.FindFile(fileName, _testDirectory);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void FindFile_FileInSubDirectory_ReturnsCorrectPath()
    {
        string fileName = "MyFile.csv";

        string result = FileFinder.FindFile(fileName, _testDirectory);

        Assert.IsNotNull(result);
        Assert.IsTrue(File.Exists(result));
        Assert.AreEqual(Path.GetFileName(result), fileName);
    }

    [TestMethod]
    [ExpectedException(typeof(DirectoryNotFoundException))]
    public void FindFile_InvalidDirectory_ThrowsException()
    {
        string fileName = "MyFile.csv";
        string invalidDirectory = Path.Combine(_testDirectory, "InvalidDir");

        FileFinder.FindFile(fileName, invalidDirectory);
    }
}
