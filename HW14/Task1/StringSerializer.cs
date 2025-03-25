using System.Text;

namespace Task1;

public static class StringSerializer
{
    public static byte[] Serialize(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        return Encoding.UTF8.GetBytes(input);
    }

    public static string Deserialize(byte[] data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        return Encoding.UTF8.GetString(data);
    }
}