using System.Runtime.Serialization.Formatters.Binary;

namespace Task2;

#pragma warning disable SYSLIB0011

public class Program
{
    public static void Main()
    {
        var student1 = new Student { StudentId = 1, FirstName = "Иван", LastName = "Иванов", Age = 20 };
        var student2 = new Student { StudentId = 2, FirstName = "Петр", LastName = "Петров", Age = 21 };

        var group = new Group
        {
            GroupId = 1,
            Name = "Группа 1",
            Students = new List<Student> { student1, student2 },
            StudentsCount = 2
        };

        student1.Group = group;
        student2.Group = group;

        SerializeGroup(group, "group.dat");

        var deserializedGroup = DeserializeGroup("group.dat");

        Console.WriteLine($"GroupId: {deserializedGroup.GroupId}, Name: {deserializedGroup.Name}");
        foreach (var student in deserializedGroup.Students)
        {
            Console.WriteLine($"StudentId: {student.StudentId}, FirstName: {student.FirstName}, LastName: {student.LastName}, Age: {student.Age}");
        }
    }

    public static void SerializeGroup(Group group, string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, group);
        }
    }

    public static Group DeserializeGroup(string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            var formatter = new BinaryFormatter();
            return (Group)formatter.Deserialize(stream);
        }
    }
}
