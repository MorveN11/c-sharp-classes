namespace Regex;

public static class RegexExtensions
{
    public static (Func<string> getString, Action change) CloseClousureSet(HashSet<string> set)
    {
        int index = 0;
        string key = set.First();
        int counter = 0;

        Func<string> getString = () =>
        {
            string aux = string.Empty;

            for (int i = 0; i < counter; i++)
            {
                aux = aux + key;
            }

            counter++;

            return aux;
        };

        Action change = () =>
        {
            ++index;
            if (index == set.Count)
            {
                index = 0;
            }
            else { }
            key = set.ElementAt(index);

            counter = 0;
        };
        return (getString, change);
    }
}

public class App
{
    public static void Main(string[] args)
    {
        var setChar = new HashSet<string> { "a", "b", "c" };
        var funcs = RegexExtensions.CloseClousureSet(setChar);
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        funcs.change();
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        funcs.change();
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());

        funcs.change();

        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
        Console.WriteLine(funcs.getString());
    }
}
