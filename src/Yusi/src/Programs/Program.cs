namespace Yusi.Programs;

using Yusi.Programs.Interpreters;

public class Program
{
    private readonly Interpreter _interpreter;

    public Program()
    {
        _interpreter = new Interpreter();
    }

    public void Run()
    {
        while (true)
        {
            Console.Write("YuSi>> ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Exiting...");
                return;
            }

            _interpreter.Interpret(input);
        }
    }
}
