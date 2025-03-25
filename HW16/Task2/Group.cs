namespace Task2;

[Serializable]
public class Group
{
    public decimal GroupId { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; }

    [NonSerialized]
    private int _studentsCount;

    public int StudentsCount
    {
        get => _studentsCount;
        set => _studentsCount = value;
    }
}
