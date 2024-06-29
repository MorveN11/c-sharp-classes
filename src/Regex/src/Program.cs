namespace Regex;

public class Program
{
    public static void main(string[] args)
    {
        Console.WriteLine("---- (1+0)*.10 ----");
        var formRegex = RegexExtension.FormRegex("(1+0)*.10");
        Console.WriteLine(formRegex.IsMatch("1010"));
        Console.WriteLine(formRegex.IsMatch("01") == false);
        Console.WriteLine(formRegex.IsMatch("2") == false);

        Console.WriteLine("---- (H+o+l+a)*.mundo ----");
        formRegex = RegexExtension.FormRegex("(H+o+l+a)*.mundo");
        Console.WriteLine(formRegex.IsMatch("mundo"));
        Console.WriteLine(formRegex.IsMatch("Hmundo"));

        Console.WriteLine("---- x* ----");
        formRegex = RegexExtension.FormRegex("x*");
        Console.WriteLine(formRegex.IsMatch(String.Empty));
        Console.WriteLine(formRegex.IsMatch("xxxxx"));

        Console.WriteLine("---- Dates ----");
        Console.WriteLine(RegexExtension.IsValidDate("01/Mayo/1955"));
        Console.WriteLine(RegexExtension.IsValidDate("29/Febrero/2024"));
        Console.WriteLine(RegexExtension.IsValidDate("29/Febrero/2021") == false);
        Console.WriteLine(RegexExtension.IsValidDate("31/Diciembre/2020"));
        Console.WriteLine(RegexExtension.IsValidDate("35/Enero/2000") == false);
        Console.WriteLine(RegexExtension.IsValidDate("01/Enero/200") == false);

        Console.WriteLine("---- Emails ----");
        Console.WriteLine(RegexExtension.IsValidEmail("usuario@gmail.com"));
        Console.WriteLine(RegexExtension.IsValidEmail("usuario_1@yahoo.org"));
        Console.WriteLine(RegexExtension.IsValidEmail("usuario.apellido@outlook.bo"));
        Console.WriteLine(RegexExtension.IsValidEmail("@gmail.com"));
        Console.WriteLine(RegexExtension.IsValidEmail("usuario@hotmail.com"));
    }
}
