public class App
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");

        string? input = Console.ReadLine();

        if (input == null)
        {
            throw new ArgumentNullException("Only numbers greater than 0 are allowed");
        }

        int number = int.Parse(input);

        if (number < 0)
        {
            throw new ArgumentException("Only numbers greater than 0 are allowed");
        }

        int answer = 1;

        condition:

        if (number == 0 || number == 1)
        {
            goto end;
        }

        answer *= number;
        number--;
        goto condition;

        end:

        Console.WriteLine($"The factorial of the number is: {answer}");
    }
}
