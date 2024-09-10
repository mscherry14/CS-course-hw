namespace PasswordHW1;

/*
 * Сгенерируйте пароль для пользователя. Требования: длина от 6 до 20 символов,
 * должен быть ровно один символ подчеркивания, хотя бы две заглавных буквы,
 * не более 5 цифр, любые две цифры подряд недопустимы.
 */

public class PasswordGenerator
{
    private readonly Random _rnd;
    public PasswordGenerator()
    {
        _rnd = new Random();
    }
    public PasswordGenerator(int seed)
    {
        _rnd = new Random(seed);
    }
    
    private List<char> GetLetters(int max)
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        List<char> output = new List<char>();
        int letters = _rnd.Next(2, max);
        int upperLetters = _rnd.Next(2, letters);
        for (int i = 0; i < letters; i++)
        {
            output.Add(i < upperLetters ? 
                Char.ToUpper(alphabet[_rnd.Next(alphabet.Length)]) : 
                alphabet[_rnd.Next(alphabet.Length)]);
        }

        return output;
    }

    private List<char> AddNumbers(int length, ref char[] otherPassword)
    {
        if (length == 0)
        {
            return new List<char>(otherPassword);
        }

        //индексы для вставки чисел между символами
        int[] positions = Enumerable.Range(0, otherPassword.Length + 1).ToArray();
        string numbers = "0123456789";
        _rnd.Shuffle(positions);
        Array.Resize(ref positions, length);
        Array.Sort(positions);
        
        List<char> output = new List<char>();
        int curIndex = 0;
        if (positions[curIndex] == 0)
        {
            output.Add(numbers[_rnd.Next(numbers.Length)]);
            curIndex++;
        }
        for (int i = 0; i < otherPassword.Length; i++)
        {
            output.Add(otherPassword[i]);
            if (curIndex < length)
            {
                if (i + 1 == positions[curIndex])
                {
                    output.Add(numbers[_rnd.Next(numbers.Length)]);
                    curIndex++;
                }
            }
        }

        return output;
    }

    public String GetPassword()
    {        
        int numbers = _rnd.Next(0, 6); //number <= 5
        List<Char> password = GetLetters(20 - numbers);
        password.Add('_');
        char[] passwordArray = password.ToArray();
        _rnd.Shuffle(passwordArray);
        password = AddNumbers(numbers, ref passwordArray);
        string answer = new String(password.ToArray());
        return answer;
    }
}