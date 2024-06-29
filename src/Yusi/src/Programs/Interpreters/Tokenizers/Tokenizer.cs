namespace Yusi.Programs.Interpreters.Tokenizers;

using Yusi.Programs.Interpreters.Tokenizers.Strategies;

public class Tokenizer
{
    public List<string>? ListTokens { get; private set; }
    public string? Input { private get; set; }

    public Tokenizer() { }

    public void Tokenize()
    {
        if (string.IsNullOrWhiteSpace(Input))
        {
            throw new Exception("No input to tokenize");
        }

        ListTokens = new List<string>();
        int pos = 0;

        while (pos < Input.Length)
        {
            char currentChar = Input[pos];
            TokenizeStrategy? strategy = null;

            if (char.IsWhiteSpace(currentChar))
            {
                strategy = new WhiteSpaceStrategy();
            }

            if (char.IsLetterOrDigit(currentChar))
            {
                strategy = new LetterDigitStrategy();
            }

            if (Tokens.EspecialCharacters.Contains(currentChar))
            {
                strategy = new EspecialCharacterStrategy();
            }

            if (strategy == null)
            {
                throw new Exception($"Invalid character {currentChar} at position {pos}");
            }

            Tuple<int, string> result = strategy.Tokenize(pos, Input);
            pos = result.Item1;
            string token = result.Item2;

            if (!string.IsNullOrEmpty(token))
            {
                ListTokens.Add(token);
            }
        }
    }
}
