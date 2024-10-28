using Task5LinkedListsIntersection;

namespace Test;

[TestClass]
public class Task5LinkedListsIntersectionTest
{
    [TestMethod]
    public void NoIntersectionTest()
    {
        ListNode<int> node1 = new(1);
        ListNode<int> node2 = new(node1, 2);
        ListNode<int> node3 = new(node2, 3);
        ListNode<int> node4 = new(4);
        ListNode<int> node5 = new(node4, 5);
        ListNode<int> node6 = new(node5, 6);
        ListNode<int>? res = SingleLinkedListsIntersection<int>.FindIntersection(node3, node6);
        Assert.IsNull(res);
    }
    
    [TestMethod]
    public void NullFirstNodeTest()
    {
        ListNode<int> node1 = new(1);
        ListNode<int> node2 = new(node1, 2);
        ListNode<int> node3 = new(node2, 3);
        ListNode<int> node4 = new(node3, 4);
        ListNode<int> node5 = new(node4, 5);
        ListNode<int> node6 = new(node5, 6);
        ListNode<int>? res = SingleLinkedListsIntersection<int>.FindIntersection(null, node6);
        Assert.IsNull(res);
    }
    
    [TestMethod]
    public void NullSecondNodeTest()
    {
        ListNode<int> node1 = new(1);
        ListNode<int> node2 = new(node1, 2);
        ListNode<int> node3 = new(node2, 3);
        ListNode<int> node4 = new(node3, 4);
        ListNode<int> node5 = new(node4, 5);
        ListNode<int> node6 = new(node5, 6);
        ListNode<int>? res = SingleLinkedListsIntersection<int>.FindIntersection(node6, null);
        Assert.IsNull(res);
    }
    
    [TestMethod]
    public void NullAllNodeTest()
    {
        ListNode<int>? res = SingleLinkedListsIntersection<int>.FindIntersection(null, null);
        Assert.IsNull(res);
    }
    
    [TestMethod]
    public void CoincidenceTest()
    {
        ListNode<int> node1 = new(1);
        ListNode<int> node2 = new(node1, 2);
        ListNode<int> node3 = new(node2, 3);
        ListNode<int>? res = SingleLinkedListsIntersection<int>.FindIntersection(node3, node3);
        Assert.AreEqual(res, node3);
    }
    
    [TestMethod]
    public void SubsetTest()
    {
        ListNode<int> node1 = new(1);
        ListNode<int> node2 = new(node1, 2);
        ListNode<int> node3 = new(node2, 3);
        ListNode<int> node4 = new(node3, 4);
        ListNode<int> node5 = new(node4, 5);
        ListNode<int> node6 = new(node5, 6);
        ListNode<int>? res = SingleLinkedListsIntersection<int>.FindIntersection(node3, node6);
        Assert.AreEqual(res, node3);
    }
    
    [TestMethod]
    public void IntersectionTest()
    {
        ListNode<int> node1 = new(1);
        ListNode<int> node2 = new(node1, 2);
        ListNode<int> node3 = new(node2, 3);
        ListNode<int> node4 = new(node3, 4);
        ListNode<int> node5 = new(node4, 5);
        ListNode<int> node6 = new(node5, 6);
        ListNode<int> node7 = new(node3, 7);
        ListNode<int> node8 = new(node7, 8);
        ListNode<int> node9 = new(node8, 9);
        ListNode<int>? res = SingleLinkedListsIntersection<int>.FindIntersection(node9, node6);
        Assert.AreEqual(res, node3);
    }
}