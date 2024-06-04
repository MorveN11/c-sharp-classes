namespace ClassJuneFourth
{
    static class MyExtensions
    {
        public delegate R Parse<T, R>(T item);
        public delegate bool Predicate<T>(T item);

        public static int GetCount<T>(this IEnumerable<T> source)
        {
            return source.Aggregate(0, (count, _) => ++count);
        }

        public static string GetString<T>(this IEnumerable<T> source)
        {
            return source.Aggregate(string.Empty, (text, item) => text + item?.ToString());
        }

        public static IEnumerable<T> GetReverse<T>(this IEnumerable<T> source)
        {
            T[] reversed = new T[source.GetCount()];

            source.Aggregate(
                source.GetCount(),
                (index, item) =>
                {
                    reversed[--index] = item;
                    return index;
                }
            );

            return reversed;
        }

        public static T? GetElementAt<T>(this IEnumerable<T> source, int index)
        {
            T? element = default(T);
            source.Aggregate(
                0,
                (count, i) =>
                {
                    if (count == index)
                    {
                        element = i;
                    }
                    return ++count;
                }
            );
            return element;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            int elements = source.Aggregate(
                0,
                (count, item) =>
                {
                    if (predicate(item))
                    {
                        ++count;
                    }
                    return count;
                }
            );

            T[] result = new T[elements];

            source.Aggregate(
                0,
                (index, item) =>
                {
                    if (predicate(item))
                    {
                        result[index++] = item;
                    }
                    return index;
                }
            );

            return result;
        }

        public static IEnumerable<R> GetNew<T, R>(this IEnumerable<T> source, Parse<T, R> parse)
        {
            R[] result = new R[source.GetCount()];

            source.Aggregate(
                0,
                (index, item) =>
                {
                    result[index++] = parse(item);
                    return index;
                }
            );

            return result;
        }

        public static IList<T> GetList<T>(this IEnumerable<T> source)
        {
            return source.Aggregate(
                new List<T>(),
                (list, item) =>
                {
                    list.Add(item);
                    return list;
                }
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hola Mundo";
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(text.GetCount() == 10);
            Console.WriteLine(numbers.GetCount() == 10);
            Console.WriteLine(text.GetString() == "Hola Mundo");
            Console.WriteLine(numbers.GetString() == "12345678910");
            Console.WriteLine(text.GetReverse().GetString() == "odnuM aloH");
            Console.WriteLine(numbers.GetReverse().GetString() == "10987654321");
            Console.WriteLine(numbers.GetReverse().GetElementAt(0) == 10);
            Console.WriteLine(numbers.Filter(n => n % 2 == 0).GetString() == "246810");

            string[] names = { "Juan", "Maria", "Pedro" };
            var result = names.GetNew(name => new { Value = name.GetCount() }).GetList();

            Console.WriteLine(result[0].Value == 4);
            Console.WriteLine(result[1].Value == 5);
            Console.WriteLine(result[2].Value == 5);
        }
    }
}
