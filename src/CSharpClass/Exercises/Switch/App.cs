public class App
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");

        string? input = Console.ReadLine();

        if (input == null)
        {
            throw new ArgumentNullException("Only numbers are allowed");
        }

        int number = int.Parse(input);

        if (number % 7 == 0)
        {
            Console.WriteLine("Monday");
            goto end;
        }

        if (number % 3 == 0)
        {
            Console.WriteLine("Tuesday");
            goto end;
        }

        if (number % 5 == 0)
        {
            Console.WriteLine("Wednesday");
            goto end;
        }

        if (number % 8 == 0)
        {
            Console.WriteLine("Thursday");
            goto end;
        }

        if (number % 13 == 0)
        {
            Console.WriteLine("Friday");
            goto end;
        }

        if (number % 21 == 0)
        {
            Console.WriteLine("Saturday");
            goto end;
        }

        if (number % 34 == 0)
        {
            Console.WriteLine("Sunday");
            goto end;
        }

        Console.WriteLine("Default");

        end:
        Console.WriteLine("Finish Execution");
    }
}
