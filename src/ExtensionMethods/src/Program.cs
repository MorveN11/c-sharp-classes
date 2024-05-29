class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        var evenNumbers = numbers.Filter(n => n % 2 == 0);
        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

        var squares = numbers.Map(n => n * n);
        Console.WriteLine("Squares: " + string.Join(", ", squares));

        var sum = numbers.Reduce((a, b) => a + b, 0);
        Console.WriteLine("Sum: " + sum);
    }
}
