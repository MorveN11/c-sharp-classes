namespace NeverDoThis
{
    using UglyCode;

    public class Program
    {
        public static bool wasUsed = false;

        public static void Main(string[] args)
        {
            var spaghettiDish = new SpaghettiDish(new SpaghettiDish.Spaghetti(9));
            spaghettiDish.UseIndexerEvent += UseIndexer;

            string ittehgaps = "";

            for (
                byte index = (byte)(spaghettiDish.Noodle.GetNoodleQuantity() - 1);
                index < 255;
                index--
            )
            {
                ittehgaps += spaghettiDish[index];
            }

            spaghettiDish.isReady = !spaghettiDish.isReady;

            bool[] answers =
            {
                !spaghettiDish.isReady,
                ittehgaps == "ittehgaps",
                spaghettiDish.Noodle.GetNoodleName() == "spaghetti",
                spaghettiDish.Noodle.GetNoodleQuantity() == 9,
                spaghettiDish.GetDishQuantity() == 10,
                spaghettiDish.Mix(ittehgaps) == "spaghetti",
                (spaghettiDish + 3) == "spaghettiiii",
                (spaghettiDish - 5) == "spa",
                (2 + spaghettiDish) == "ssspaghetti",
                wasUsed
            };

            byte correct = 0;
            for (byte index = 0; index < answers.Length; index++)
            {
                if (answers[index])
                {
                    Console.WriteLine($"Answer {index + 1} is correct");
                    correct++;
                }
                else
                {
                    Console.WriteLine($"Answer {index + 1} is incorrect");
                }
            }

            Console.WriteLine($"Result: {correct}/{answers.Length}");
        }

        static void UseIndexer(object? sender, EventArgs e)
        {
            wasUsed = true;
        }
    }
}
