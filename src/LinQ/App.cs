namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int sum = integers.Aggregate((a, b) => a + b);
            int maxValue = integers.Aggregate((a, b) => a > b ? a : b);
            int minValue = integers.Aggregate((a, b) => a < b ? a : b);
            int average = integers.Aggregate(0, (a, b) => a + b, value => value / integers.Count);

            Console.WriteLine($"Sum: {sum}"); // 55
            Console.WriteLine($"Max: {maxValue}"); // 10
            Console.WriteLine($"Min: {minValue}"); // 1
            Console.WriteLine($"Average: {average}"); // 5
        }
    }
}
