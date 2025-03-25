using System.Collections;
using Task2CollectionSort;

namespace Tests;

[TestClass]
public class Task2CollectionSortTests
{
[TestMethod]
    public void TestNameLengthComparer()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person("Alice", 25),
            new Person("Bob", 30),
            new Person("Charlie", 20),
            new Person("David", 35),
            new Person("Eve", 25),
            new Person("Frank", 30)
        };

        var expected = new List<Person>
        {
            new Person("Bob", 30),
            new Person("Eve", 25),
            new Person("Alice", 25),
            new Person("David", 35),
            new Person("Frank", 30),
            new Person("Charlie", 20)
        };

        // Act
        people.Sort(new NameLengthComparer());

        // Assert
        CollectionAssert.AreEqual(expected, people, new PersonComparer());
    }

    [TestMethod]
    public void TestAgeComparer()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person("Alice", 25),
            new Person("Bob", 30),
            new Person("Charlie", 20),
            new Person("David", 35),
            new Person("Eve", 25),
            new Person("Frank", 30)
        };

        var expected = new List<Person>
        {
            new Person("Charlie", 20),
            new Person("Alice", 25),
            new Person("Eve", 25),
            new Person("Bob", 30),
            new Person("Frank", 30),
            new Person("David", 35)
        };

        // Act
        people.Sort(new AgeComparer());

        // Assert
        CollectionAssert.AreEqual(expected, people, new PersonComparer());
    }

    public class PersonComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var personX = x as Person;
            var personY = y as Person;

            if (personX == null || personY == null)
            {
                throw new ArgumentException("Объекты должны быть типа Person.");
            }

            if (personX.Name == personY.Name && personX.Age == personY.Age)
            {
                return 0;
            }

            return -1;
        }
    }
}
