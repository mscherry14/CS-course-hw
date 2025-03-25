using Task3;

namespace Tests;

[TestClass]
public class Task3Tests
{
    [TestMethod]
    public void Serialize_EmptyTree_ReturnsEmptyString()
    {
        var codec = new BinaryTreeCodec();
        TreeNode root = null;

        var result = codec.Serialize(root);

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void Deserialize_EmptyString_ReturnsNull()
    {
        var codec = new BinaryTreeCodec();
        string data = "";

        var result = codec.Deserialize(data);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void Serialize_SingleNodeTree_ReturnsCorrectString()
    {
        var codec = new BinaryTreeCodec();
        var root = new TreeNode(1);

        var result = codec.Serialize(root);

        Assert.AreEqual("1", result);
    }

    [TestMethod]
    public void Deserialize_SingleNodeTree_ReturnsCorrectTree()
    {
        var codec = new BinaryTreeCodec();
        string data = "1";

        var result = codec.Deserialize(data);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Value);
        Assert.IsNull(result.Left);
        Assert.IsNull(result.Right);
    }

    [TestMethod]
    public void Serialize_ComplexTree_ReturnsCorrectString()
    {
        var codec = new BinaryTreeCodec();
        var root = new TreeNode(2)
        {
            Left = new TreeNode(1),
            Right = new TreeNode(4)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(5)
            }
        };

        var result = codec.Serialize(root);

        Assert.AreEqual("2,1,4,3,5", result);
    }

    [TestMethod]
    public void Deserialize_ComplexTree_ReturnsCorrectTree()
    {
        var codec = new BinaryTreeCodec();
        string data = "2,1,4,3,5";

        var result = codec.Deserialize(data);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Value);

        Assert.IsNotNull(result.Left);
        Assert.AreEqual(1, result.Left.Value);
        Assert.IsNull(result.Left.Left);
        Assert.IsNull(result.Left.Right);

        Assert.IsNotNull(result.Right);
        Assert.AreEqual(4, result.Right.Value);

        Assert.IsNotNull(result.Right.Left);
        Assert.AreEqual(3, result.Right.Left.Value);
        Assert.IsNull(result.Right.Left.Left);
        Assert.IsNull(result.Right.Left.Right);

        Assert.IsNotNull(result.Right.Right);
        Assert.AreEqual(5, result.Right.Right.Value);
        Assert.IsNull(result.Right.Right.Left);
        Assert.IsNull(result.Right.Right.Right);
    }

    [TestMethod]
    public void SerializeAndDeserialize_RoundTrip_ReturnsOriginalTree()
    {
        var codec = new BinaryTreeCodec();
        var root = new TreeNode(2)
        {
            Left = new TreeNode(1),
            Right = new TreeNode(4)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(5)
            }
        };

        var serialized = codec.Serialize(root);
        var deserialized = codec.Deserialize(serialized);

        Assert.AreEqual(root.Value, deserialized.Value);
        Assert.AreEqual(root.Left.Value, deserialized.Left.Value);
        Assert.AreEqual(root.Right.Value, deserialized.Right.Value);
        Assert.AreEqual(root.Right.Left.Value, deserialized.Right.Left.Value);
        Assert.AreEqual(root.Right.Right.Value, deserialized.Right.Right.Value);
    }
}