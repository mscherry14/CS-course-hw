namespace Task2CollectionSort;

public class NameLengthComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException("Объект Person не может быть null.");
        }

        int lengthComparison = x.Name.Length.CompareTo(y.Name.Length);
        if (lengthComparison != 0)
        {
            return lengthComparison;
        }

        return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }
}