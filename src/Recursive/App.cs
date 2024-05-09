public class App
{
    static void Main(string[] args)
    {
        uint number = 72;

        printNextFivePrimeNumbers(number);
    }

    static bool isPrime(uint number)
    {
        if (number < 2)
            return false;

        return isPrime(number, 2);
    }

    static bool isPrime(uint number, uint div)
    {
        if (number == div)
        {
            Console.WriteLine(number);
            return true;
        }

        if (number % div == 0)
            return false;

        return isPrime(number, ++div);
    }

    static void printNextFivePrimeNumbers(uint number)
    {
        printNextFivePrimeNumbers(number, 5);
    }

    static void printNextFivePrimeNumbers(uint number, uint counter)
    {
        if (counter == 0)
            return;

        if (isPrime(number))
            counter--;

        printNextFivePrimeNumbers(++number, counter);
    }
}
