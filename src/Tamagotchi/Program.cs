using System.Timers;

namespace Tamagotchi
{
    /**
     * En C#, String.IsNullOrEmpty(string) y String.IsNullOrWhiteSpace(string) son dos métodos que se utilizan
     * para comprobar si una cadena de texto es nula o está vacía. Sin embargo, tienen una diferencia importante:
     *
     * String.IsNullOrEmpty(string): Este método devuelve true si la cadena de texto es null o si su longitud es 0
     * (es decir, si está vacía). No considera los espacios en blanco como un valor vacío, por lo que si la cadena de
     * texto contiene solo espacios en blanco, este método devolverá false.
     *
     * String.IsNullOrEmpty(null); // true
     * String.IsNullOrEmpty(""); // true
     * String.IsNullOrEmpty(" "); // false
     *
     * String.IsNullOrWhiteSpace(string): Este método devuelve true si la cadena de texto es null, si su longitud es 0
     * o si contiene solo espacios en blanco. A diferencia de String.IsNullOrEmpty(string), este método considera los
     * espacios en blanco como un valor vacío.
     *
     * String.IsNullOrWhiteSpace(null); // true
     * String.IsNullOrWhiteSpace(""); // true
     * String.IsNullOrWhiteSpace(" "); // true
     */
    public class Program
    {
        static (Action Feed, Action Care, Action Play) Tamagotchi()
        {
            sbyte _life = 10;
            string? _previousAction = null;

            var _random = new Random();
            var _timer = new System.Timers.Timer(2000);

            Action feed = () =>
            {
                Console.WriteLine("Feeding Tamagotchi");
                _life += 1;
            };
            Action care = () =>
            {
                Console.WriteLine("Care for Tamagotchi");
                _life += 2;
            };
            Action play = () =>
            {
                Console.WriteLine("Playing with Tamagotchi");
                _life += 1;
            };

            Dictionary<string, Action> actions = new Dictionary<string, Action>
            {
                { "Feed", feed },
                { "Care", care },
                { "Play", play }
            };

            Dictionary<string, sbyte> restLife = new Dictionary<string, sbyte>
            {
                { "Feed", 2 },
                { "Care", 0 },
                { "Play", 1 }
            };

            List<string> keys = new List<string>(actions.Keys);

            ElapsedEventHandler OnTimedEvent = (source, e) =>
            {
                string randomAction = keys[_random.Next(keys.Count)];

                actions[randomAction]();

                if (_previousAction != null && _previousAction == randomAction)
                {
                    _life -= restLife[randomAction];
                }

                _previousAction = randomAction;

                Console.WriteLine($"Life: {_life}");

                if (_life <= 0 || _life >= 30)
                {
                    _timer.Stop();
                    Console.WriteLine("Game Over - The Tamagotchi has died. :(");
                    Environment.Exit(0);
                }
            };

            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            return (feed, care, play);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Your Tamagotchi is alive!");
            var (Feed, Care, Play) = Tamagotchi();
            Console.ReadKey();
        }
    }
}
