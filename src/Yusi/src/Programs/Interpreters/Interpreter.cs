namespace Yusi.Programs.Interpreters;

using Yusi.Programs.Interpreters.Executors;
using Yusi.Programs.Interpreters.Parsers;
using Yusi.Programs.Interpreters.Tokenizers;

public class Interpreter
{
    private readonly Tokenizer _tokenizer;
    private readonly Parser _parser;
    private readonly Executor _executor;

    public Interpreter()
    {
        _tokenizer = new Tokenizer();
        _parser = new Parser();
        _executor = new Executor();
    }

    public void Interpret(string input)
    {
        _tokenizer.Input = input;
        _tokenizer.Tokenize();

        _parser.ListTokens = _tokenizer.ListTokens;
        _parser.Parse();

        _executor.Statement = _parser.Statement;
        _executor.Execute();
    }
}
