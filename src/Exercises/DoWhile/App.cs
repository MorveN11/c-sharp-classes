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

        if (number < 0)
        {
            number = 1;
        }

        int count = 0;

        Console.WriteLine("The next 10 prime numbers are:");

        verifyPrime:

        if (number == 1)
        {
            goto condition;
        }

        int i = 2;

        loop:

        if (number == i)
        {
            goto isPrime;
        }

        if (number % i == 0)
        {
            goto condition;
        }

        i++;
        goto loop;

        isPrime:

        Console.WriteLine(number);

        count++;
        goto condition;

        condition:

        if (count == 10)
        {
            goto end;
        }

        number++;
        goto verifyPrime;

        end:
        Console.WriteLine("Finish Execution");
    }
}
