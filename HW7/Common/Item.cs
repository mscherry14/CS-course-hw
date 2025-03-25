namespace Common;

public class Item : IObjectWithName
{
    public string Name { get; set; }

    public Item(string name)
    {
        Name = name;
    }
}
