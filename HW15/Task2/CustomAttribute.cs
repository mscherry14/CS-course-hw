namespace Task2;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class CustomAttribute : Attribute
{
    public string Author { get; }
    public int Revision { get; }
    public string Description { get; }
    public string[] Reviewers { get; }

    public CustomAttribute(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = reviewers;
    }
}