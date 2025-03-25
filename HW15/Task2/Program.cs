using System.Reflection;

namespace Task2;

public class Program
{
    public static void Main(string[] args)
    {
        Type healthScoreType = typeof(HealthScore);

        var classAttributes = healthScoreType.GetCustomAttributes(typeof(CustomAttribute), false)
            .Cast<CustomAttribute>();

        foreach (var attr in classAttributes)
        {
            Console.WriteLine("Class: HealthScore");
            Console.WriteLine($"Author: {attr.Author}");
            Console.WriteLine($"Revision: {attr.Revision}");
            Console.WriteLine($"Description: {attr.Description}");
            Console.WriteLine("Reviewers: " + string.Join(", ", attr.Reviewers));
            Console.WriteLine();
        }

        MethodInfo[] methods = healthScoreType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (var method in methods)
        {
            var methodAttributes = method.GetCustomAttributes(typeof(CustomAttribute), false)
                .Cast<CustomAttribute>();

            if (methodAttributes.Any())
            {
                Console.WriteLine($"\tMethod: {method.Name}");
                foreach (var attr in methodAttributes)
                {
                    Console.WriteLine($"\tAuthor: {attr.Author}");
                    Console.WriteLine($"\tRevision: {attr.Revision}");
                    Console.WriteLine($"\tDescription: {attr.Description}");
                    Console.WriteLine("\tReviewers: " + string.Join(", ", attr.Reviewers));
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Method: {method.Name} (No custom attribute)");
                Console.WriteLine();
            }
        }
    }
}