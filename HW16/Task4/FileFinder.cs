namespace Task4;

public class FileFinder
{
    public static string? FindFile(string fileName, string searchDirectory = ".")
    {
        if (!Directory.Exists(searchDirectory))
        {
            throw new DirectoryNotFoundException($"Директория не найдена: {searchDirectory}");
        }

        string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        string extension = Path.GetExtension(fileName);

        // Ищем файлы в текущей директории
        foreach (var file in Directory.GetFiles(searchDirectory, "*" + extension))
        {
            if (Path.GetFileNameWithoutExtension(file).Equals(nameWithoutExtension, StringComparison.OrdinalIgnoreCase))
            {
                return Path.GetFullPath(file); 
            }
        }

        foreach (var directory in Directory.GetDirectories(searchDirectory))
        {
            string result = FindFile(fileName, directory);
            if (result != null)
            {
                return result; 
            }
        }

        return null;
    }
}