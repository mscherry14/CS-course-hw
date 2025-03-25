using System.Reflection;

namespace Task1;

public class Program
{
    public static void Main()
    {
        Type blackBoxType = typeof(BlackBox);
        object blackBoxInstance = Activator.CreateInstance(blackBoxType, nonPublic: true);

        FieldInfo innerValueField = blackBoxType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

        while (true)
        {
            Console.Write("Введите команду (например, Add(100)): ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                break;

            string methodName = input.Split('(')[0];
            int argument = int.Parse(input.Split('(', ')')[1]);

            MethodInfo method = blackBoxType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (method != null)
            {
                method.Invoke(blackBoxInstance, new object[] { argument });

                int currentValue = (int)innerValueField.GetValue(blackBoxInstance);
                Console.WriteLine($"Текущее значение: {currentValue}");
            }
            else
            {
                Console.WriteLine("Метод не найден.");
            }
        }
    }
}