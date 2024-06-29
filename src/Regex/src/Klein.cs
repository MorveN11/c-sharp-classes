class Program
{
    static void Main()
    {
        HashSet<string> alphabet = new HashSet<string> { "ab", "c" };
        int maxLength = 3; // Define the maximum length of strings to generate

        HashSet<string> kleeneClosure = GenerateKleeneClosure(alphabet, maxLength);

        Console.WriteLine("Kleene Closure:");
        foreach (var s in kleeneClosure)
        {
            Console.WriteLine(s == "" ? "ε" : s);
        }
    }

    static HashSet<string> GenerateKleeneClosure(HashSet<string> alphabet, int maxLength)
    {
        HashSet<string> kleeneClosure = new HashSet<string>();
        kleeneClosure.Add(""); // Add the empty string (epsilon)

        for (int length = 1; length <= maxLength; length++)
        {
            HashSet<string> newStrings = new HashSet<string>();

            foreach (var str in kleeneClosure)
            {
                foreach (var symbol in alphabet)
                {
                    string newStr = str + symbol;
                    if (newStr.Length <= maxLength)
                    {
                        newStrings.Add(newStr);
                    }
                }
            }

            foreach (var newStr in newStrings)
            {
                kleeneClosure.Add(newStr);
            }
        }

        return kleeneClosure;
    }
}
