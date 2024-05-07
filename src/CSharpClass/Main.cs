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

            sbyte number = -1;
            Console.WriteLine(false && (++number == 0));
            Console.WriteLine(number);
            Console.WriteLine(true & (++number == 0));
            Console.WriteLine(number);
            Console.WriteLine((2 ^ 3));
            Console.WriteLine((~2));

            Dictionary<int, int> list = new Dictionary<int, int>();
            list.Add(0, 80);
            Console.WriteLine(list[0]);
        }

        public static void Recursive()
        {
            Recursive();
        }
    }
}
