public class App
{
    static void Main(string[] args)
    {
        uint limit = 70;

        showOdd(limit);
    }

    static void showOdd(uint limit)
    {
        showOdd(limit, 0);
    }

    static void showOdd(uint limit, uint counter)
    {
        if (counter % 2 == 1)
        {
            Console.WriteLine(counter);
        }

        if (counter < limit)
        {
            showOdd(limit, ++counter);
        }
    }
}
