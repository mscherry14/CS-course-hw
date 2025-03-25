using Task2;

namespace Tests;

[TestClass]
public class Task2Tests
{
    [TestMethod]
    public void Test_MaleEntersAndExits()
    {
        // Arrange
        var showerRoom = new ShowerRoom();

        // Act
        showerRoom.MaleEnters();
        bool isMaleInShower = true;

        showerRoom.MaleExits();
        bool isMaleInShowerAfterExit = false;

        // Assert
        Assert.IsTrue(isMaleInShower);
        Assert.IsFalse(isMaleInShowerAfterExit);
    }

    [TestMethod]
    public void Test_FemaleEntersAndExits()
    {
        // Arrange
        var showerRoom = new ShowerRoom();

        // Act
        showerRoom.FemaleEnters(); 
        bool isFemaleInShower = true;

        showerRoom.FemaleExits();
        bool isFemaleInShowerAfterExit = false;

        // Assert
        Assert.IsTrue(isFemaleInShower);
        Assert.IsFalse(isFemaleInShowerAfterExit);
    }

    [TestMethod]
    public void Test_MaleAndFemaleCannotBeInShowerTogether()
    {
        // Arrange
        var showerRoom = new ShowerRoom();
        bool isFemaleInShower = false;
        bool isMaleInShower = false;

        // Act
        var maleThread = new Thread(() =>
        {
            showerRoom.MaleEnters();
            isMaleInShower = true;
            Thread.Sleep(1000); 
            isMaleInShower = false;
            showerRoom.MaleExits();
        });

        var femaleThread = new Thread(() =>
        {
            showerRoom.FemaleEnters();
            isFemaleInShower = true;
            Thread.Sleep(1000);
            isFemaleInShower = false;
            showerRoom.FemaleExits();
        });

        maleThread.Start();
        femaleThread.Start();

        maleThread.Join();
        femaleThread.Join();

        Assert.IsFalse(isMaleInShower && isFemaleInShower);
    }

    [TestMethod]
    public void Test_MultipleMalesCanEnter()
    {
        // Arrange
        var showerRoom = new ShowerRoom();
        int maleCount = 0;

        // Act
        var maleThread1 = new Thread(() =>
        {
            showerRoom.MaleEnters();
            Interlocked.Increment(ref maleCount);
            Thread.Sleep(500);
            Interlocked.Decrement(ref maleCount);
            showerRoom.MaleExits();
        });

        var maleThread2 = new Thread(() =>
        {
            showerRoom.MaleEnters();
            Interlocked.Increment(ref maleCount);
            Thread.Sleep(500);
            Interlocked.Decrement(ref maleCount);
            showerRoom.MaleExits();
        });

        maleThread1.Start();
        maleThread2.Start();

        maleThread1.Join();
        maleThread2.Join();

        // Assert
        Assert.AreEqual(0, maleCount);
    }

    [TestMethod]
    public void Test_MultipleFemalesCanEnter()
    {
        // Arrange
        var showerRoom = new ShowerRoom();
        int femaleCount = 0;

        // Act
        var femaleThread1 = new Thread(() =>
        {
            showerRoom.FemaleEnters();
            Interlocked.Increment(ref femaleCount);
            Thread.Sleep(500); 
            Interlocked.Decrement(ref femaleCount);
            showerRoom.FemaleExits();
        });

        var femaleThread2 = new Thread(() =>
        {
            showerRoom.FemaleEnters();
            Interlocked.Increment(ref femaleCount);
            Thread.Sleep(500);
            Interlocked.Decrement(ref femaleCount);
            showerRoom.FemaleExits();
        });

        femaleThread1.Start();
        femaleThread2.Start();

        femaleThread1.Join();
        femaleThread2.Join();

        // Assert
        Assert.AreEqual(0, femaleCount);
    }
}
