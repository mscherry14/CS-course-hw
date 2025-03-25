namespace Task2CollectionSort;

public class AgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException("Объект Person не может быть null.");
        }

        // Сравниваем по возрасту
        return x.Age.CompareTo(y.Age);
    }
}