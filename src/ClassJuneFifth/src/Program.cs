namespace ClassJuneFourth
{
    public static class Test
    {
        public static IEnumerable<int> GetN()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
            yield return 10;
        }

        public static IEnumerable<string> GetStrings()
        {
            yield return "Hello";
            yield return "World";
            yield return string.Empty;
        }

        public static IEnumerable<int> GetEven()
        {
            foreach (int number in GetNumbers())
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        public static IEnumerable<int> GetEvenLessThanSeven()
        {
            foreach (int number in GetEven())
            {
                if (number < 7)
                {
                    yield return number;
                }
                else
                {
                    yield break;
                }
            }
        }
    }

    public static class ExtensionMethods
    {
        public static IEnumerable<T> Filter<T>(
            this IEnumerable<T> collection,
            Func<T, bool> predicate
        )
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Test.GetEvenLessThanSeven();

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            IEnumerable<string> strings = Test.GetStrings()
                .Filter(str => !string.IsNullOrEmpty(str));

            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            foreach (var number in Test.GetN())
            {
                Console.WriteLine(number);
            }
        }
    }
}
