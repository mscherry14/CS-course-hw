using System.Text.RegularExpressions;

namespace Task3;

public static class GroupWords
{
    public static void GroupWordsByLength(string sentence)
    {
        var words = Regex.Replace(sentence, "[^a-zA-Zа-яА-Я ]", "")
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var groups = words.GroupBy(word => word.Length)
            .OrderByDescending(group => group.Count())
            .ThenByDescending(group => group.Key);

        int groupNumber = 1;
        foreach (var group in groups)
        {
            Console.WriteLine($"Группа {groupNumber}. Длина {group.Key}. Количество {group.Count()}");
            foreach (var word in group)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();
            groupNumber++;
        }
    }
}
