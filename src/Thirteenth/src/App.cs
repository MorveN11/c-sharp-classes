public class App
{
    static void Main(string[] args)
    {
        int result;
        var division = (quotient: 0, remainder: 0);

        Console.WriteLine("----- Sum -----");
        Console.WriteLine(Sum(7, 21) == 28);
        Console.WriteLine(Sum(7, 5, 4) == 16);
        Console.WriteLine(Sum(4, 2, 0, 5, 8) == 19);
        Console.WriteLine(Sum(1, 2, 3, 4, 1, 1, 1, 1, 1, 1) == 16);

        Console.WriteLine("\n----- Substract -----");
        Substract(out result, 5, 2);
        Console.WriteLine(result == 3);
        Substract(out result, -1, 4, 2, -1, -10);
        Console.WriteLine(result == 4);

        Console.WriteLine("\n----- Multiply -----");
        Multiply(out result, 2, 4);
        Console.WriteLine(result == 8);
        Multiply(out result, -2, 5);
        Console.WriteLine(result == -10);
        Multiply(out result, 2, -5);
        Console.WriteLine(result == -10);
        Multiply(out result, -2, -5);
        Console.WriteLine(result == 10);

        Console.WriteLine("\n----- Divide -----");
        Divide(out division, 7, 3);
        Console.WriteLine(division.quotient == 2 && division.remainder == 1);

        Console.WriteLine("\n----- IsMultiple -----");
        Console.WriteLine(IsMultiple(21, 7) == true);
        Console.WriteLine(IsMultiple(7, 21) == false);
    }

    static int Sum(int a, int b, params int[] numbers)
    {
        int sum = a + b;

        for (int i = 0; i < numbers.Length; i = Sum(i, 1))
        {
            sum += numbers[i];
        }

        return sum;
    }

    static void Substract(out int result, int a, int b, params int[] number)
    {
        result = Sum(a, -b);

        for (int i = 0; i < number.Length; i = Sum(i, 1))
        {
            result = Sum(result, -number[i]);
        }
    }

    static void Multiply(out int product, int factorX, int factorY)
    {
        bool sign = false;

        if (!(factorX < 0 && factorY < 0) && (factorX < 0 || factorY < 0))
        {
            sign = true;
        }

        product = 0;
        factorX = Math.Abs(factorX);
        factorY = Math.Abs(factorY);

        for (int i = 0; i < factorY; i = Sum(i, 1))
        {
            product = Sum(product, factorX);
        }

        if (sign)
        {
            product = -product;
        }
    }

    static void Divide(out (int quotient, int remainder) result, int dividend, int divisor)
    {
        int quotient = 0;
        int remainder = dividend;

        while (remainder >= divisor)
        {
            remainder = Sum(remainder, -divisor);
            quotient = Sum(quotient, 1);
        }

        result = (quotient, remainder);
    }

    static bool IsMultiple(int dividend, int divisor)
    {
        int remainder = dividend;

        while (remainder >= divisor)
        {
            remainder = Sum(remainder, -divisor);
        }

        return remainder == 0;
    }
}
