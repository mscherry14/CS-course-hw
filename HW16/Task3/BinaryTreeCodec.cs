namespace Task3;

public class BinaryTreeCodec
{
    public string Serialize(TreeNode root)
    {
        List<string> list = new List<string>();
        SerializeHelper(root, list);

        return string.Join(",", list);
    }

    private void SerializeHelper(TreeNode node, List<string> list)
    {
        if (node == null) 
            return;

        list.Add(node.Value.ToString());

        SerializeHelper(node.Left, list); 
        SerializeHelper(node.Right, list);
    }

    public TreeNode Deserialize(string data)
    {
        if (string.IsNullOrEmpty(data)) 
            return null;

        Queue<int> queue = new Queue<int>();
        foreach (var val in data.Split(','))
        {
            queue.Enqueue(int.Parse(val));
        }

        return DeserializeHelper(queue, int.MinValue, int.MaxValue);
    }

    private TreeNode DeserializeHelper(Queue<int> queue, int lower, int upper)
    {
        if (queue.Count == 0) return null;
        int val = queue.Peek();
        if (val < lower || val > upper) return null;

        queue.Dequeue();

        TreeNode node = new TreeNode(val);
        node.Left = DeserializeHelper(queue, lower, val);
        node.Right = DeserializeHelper(queue, val, upper);

        return node;
    }
}