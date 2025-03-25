using Common;

namespace Task1;

public class TaskSolution
{
    public static string ConcatenateNames(IEnumerable<IObjectWithName> items, char delimeter)
    {
        var names = items.Skip(3).Select(item => item.Name);

        return string.Join(delimeter, names);
    }
}
