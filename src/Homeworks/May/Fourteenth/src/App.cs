public class App
{
    static void Main(string[] args)
    {
        Tuple<int, int> result = new Tuple<int, int>(0, 0);
        int product = 0;

        Console.WriteLine(Sum(2, 3) == 5);
        Console.WriteLine(Sum(2, 3, 7) == 12);
        Console.WriteLine(Sum(1, 2, 3, 4, 7) == 17);
        Console.WriteLine(Sum(-5, 6) == 1);
        Console.WriteLine(Sum(1, -7) == -6);
        Console.WriteLine(Sum(-2, -6) == -8);
        Console.WriteLine(Sum(5, -3, 8, -10) == 0);

        Console.WriteLine(Substract(1, -3) == 4);
        Console.WriteLine(Substract(1, -3) != Substract(-3, 1));
        Console.WriteLine(Substract(5, -9, 3, -5) == 16);

        Multiply(ref product, 7, 3);
        Console.WriteLine(product == 21);
        Multiply(ref product, 5, 2, 3, 4);
        Console.WriteLine(product == 120);
        Multiply(ref product, 5, 0);
        Console.WriteLine(product == 0);
        Multiply(ref product, 0, 5);
        Console.WriteLine(product == 0);
        Multiply(ref product, 1, 2, 3, 7, 0);
        Console.WriteLine(product == 0);
        Multiply(ref product, -1, 2);
        Console.WriteLine(product == -2);
        Multiply(ref product, -2, 1);
        Console.WriteLine(product == -2);
        Multiply(ref product, -2, -1);
        Console.WriteLine(product == 2);
        Multiply(ref product, -2, -1, -3);
        Console.WriteLine(product == -6);

        Divide(out result, 4, 2);
        Console.WriteLine(result.Item1 == 2 && result.Item2 == 0);
        Divide(out result, 7, 2);
        Console.WriteLine(result.Item1 == 3 && result.Item2 == 1);
        Divide(out result, 7, 5);
        Console.WriteLine(result.Item1 == 1 && result.Item2 == 2);
        Divide(out result, 100, 5);
        Console.WriteLine(result.Item1 == 20 && result.Item2 == 0);
        Divide(out result, -8, 4);
        Console.WriteLine(result.Item1 == -2 && result.Item2 == 0);

        Divide(out result, 25, 3);
        Console.WriteLine($"{result.Item1} {result.Item2}");
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

    static int Substract(int a, int b, params int[] numbers)
    {
        int substract = Sum(a, -b);

        for (int i = 0; i < numbers.Length; i = Sum(i, 1))
        {
            substract = Sum(substract, -numbers[i]);
        }

        return substract;
    }

    static void Multiply(ref int product, int a, int b, params int[] numbers)
    {
        product = 0;

        if (a == 0 || b == 0)
        {
            return;
        }

        bool sign = !(a < 0 && b < 0) && (a < 0 || b < 0);

        for (int i = 0; i < Math.Abs(b); i = Sum(i, 1))
        {
            product = Sum(product, Math.Abs(a));
        }

        if (sign)
        {
            product = -product;
        }

        for (int i = 0; i < numbers.Length; i = Sum(i, 1))
        {
            Multiply(ref product, product, numbers[i]);
        }
    }

    static void Divide(out Tuple<int, int> result, int dividend, int divisor)
    {
        bool sign = !(dividend < 0 && divisor < 0) && (dividend < 0 || divisor < 0);
        int quotient = 0;
        int remainder = Math.Abs(dividend);

        while (remainder >= divisor)
        {
            remainder = Substract(remainder, divisor);
            quotient = Sum(quotient, 1);
        }

        if (sign)
        {
            quotient = -quotient;
        }

        result = new Tuple<int, int>(quotient, remainder);
    }
}
