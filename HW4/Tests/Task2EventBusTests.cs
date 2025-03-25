using Task2EventBus;

namespace Tests;

[TestClass]
public class Task2EventBusTests
{
    [TestMethod]
    public void TestSubscribeAndNotify()
    {
        // Arrange
        var eventBus = EventBus.Instance;
        var publisher = new Publisher();
        var subscriber = new Subscriber("Тестовый подписчик");

        eventBus.Subscribe(publisher, subscriber);

        // Act
        eventBus.Notify(publisher, EventArgs.Empty);

        // Assert
        Assert.AreEqual(1, subscriber.NotificationCount);
    }

    [TestMethod]
    public void TestUnsubscribe()
    {
        // Arrange
        var eventBus = EventBus.Instance;
        var publisher = new Publisher();
        var subscriber = new Subscriber("Тестовый подписчик");

        eventBus.Subscribe(publisher, subscriber);
        eventBus.Unsubscribe(publisher, subscriber);

        // Act
        eventBus.Notify(publisher, EventArgs.Empty);

        // Assert
        Assert.AreEqual(0, subscriber.NotificationCount);
    }

    // Тест для проверки уведомления нескольких подписчиков
    [TestMethod]
    public void TestMultipleSubscribers()
    {
        // Arrange
        var eventBus = EventBus.Instance;
        var publisher = new Publisher();
        var subscriber1 = new Subscriber("Подписчик 1");
        var subscriber2 = new Subscriber("Подписчик 2");

        eventBus.Subscribe(publisher, subscriber1);
        eventBus.Subscribe(publisher, subscriber2);

        // Act
        eventBus.Notify(publisher, EventArgs.Empty);

        // Assert
        Assert.AreEqual(1, subscriber1.NotificationCount);
        Assert.AreEqual(1, subscriber2.NotificationCount);
    }

    // Тест для проверки уведомления от нескольких издателей
    [TestMethod]
    public void TestMultiplePublishers()
    {
        // Arrange
        var eventBus = EventBus.Instance;
        var publisher1 = new Publisher();
        var publisher2 = new Publisher();
        var subscriber = new Subscriber("Тестовый подписчик");

        eventBus.Subscribe(publisher1, subscriber);
        eventBus.Subscribe(publisher2, subscriber);

        // Act
        eventBus.Notify(publisher1, EventArgs.Empty);
        eventBus.Notify(publisher2, EventArgs.Empty);

        // Assert
        Assert.AreEqual(2, subscriber.NotificationCount);
    }
}
