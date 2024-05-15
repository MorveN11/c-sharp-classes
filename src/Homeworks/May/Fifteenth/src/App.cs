namespace Fifteenth
{
    public static class MyExtensions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }

    public class App
    {
        static void Main(string[] args)
        {
            int number = 10;
            Console.WriteLine(number.IsEven());

            int anotherNumber = 5;
            Console.WriteLine(anotherNumber.IsEven());
        }
    }
}
