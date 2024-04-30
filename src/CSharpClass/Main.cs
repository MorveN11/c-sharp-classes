namespace CSharpClass
{
    public class App
    {
        static void Main(string[] args)
        {
            var minByte = byte.MinValue;
            var maxByte = byte.MaxValue;
            Console.WriteLine($"Min byte: {minByte}");
            Console.WriteLine($"Max byte: {maxByte}");
            Console.WriteLine((0.1 + 0.2));
            Console.WriteLine((0.1 + 0.2).GetType());
            Console.WriteLine(((decimal)0.1 + (decimal)0.2));
            Console.WriteLine(((decimal)0.1 + (decimal)0.2).GetType());
        }
    }
}
