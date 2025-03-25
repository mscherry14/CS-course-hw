using Common;

namespace Task2;

public static class Task2Solution
{
    public static IEnumerable<IObjectWithName> FindItemsWithLongName(IEnumerable<IObjectWithName> items)
    {
        // Используем LINQ для фильтрации элементов
        return items.Where((item, index) => item.Name.Length > index);
    }
}
