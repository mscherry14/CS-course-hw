using Task1;

namespace Homework14.Tests;

[TestClass]
public class Task1Tests
{
    [TestMethod]
    public void TestSerializeDeserialize_Russian()
    {
        string input = "Привет, мир!";
        byte[] bytes = StringSerializer.Serialize(input);
        string output = StringSerializer.Deserialize(bytes);
        Assert.AreEqual(input, output);
    }

    [TestMethod]
    public void TestSerializeDeserialize_German()
    {
        string input = "Hallo, Welt!";
        byte[] bytes = StringSerializer.Serialize(input);
        string output = StringSerializer.Deserialize(bytes);
        Assert.AreEqual(input, output);
    }

    [TestMethod]
    public void TestSerializeDeserialize_Japanese()
    {
        string input = "こんにちは、世界！";
        byte[] bytes = StringSerializer.Serialize(input);
        string output = StringSerializer.Deserialize(bytes);
        Assert.AreEqual(input, output);
    }

    [TestMethod]
    public void TestSerializeDeserialize_EmptyString()
    {
        string input = "";
        byte[] bytes = StringSerializer.Serialize(input);
        string output = StringSerializer.Deserialize(bytes);
        Assert.AreEqual(input, output);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestSerialize_NullInput()
    {
        string input = null;
        byte[] bytes = StringSerializer.Serialize(input);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestDeserialize_NullInput()
    {
        byte[] data = null;
        string output = StringSerializer.Deserialize(data);
    }
}