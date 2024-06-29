namespace Regex;

public static class RegexExtension
{
    public delegate bool MatchEvaluator(string input);
    public delegate T Getter<T>();

    public static (MatchEvaluator IsMatch, Getter<string> GetPattern) FormRegex(string pattern)
    {
        string _pattern = pattern;

        MatchEvaluator IsMatch = (input) =>
        {
            return true;
        };

        Getter<string> GetPattern = () =>
        {
            return _pattern;
        };

        return (IsMatch: IsMatch, GetPattern: GetPattern);
    }

    public static bool IsValidDate(string date)
    {
        return true;
    }

    public static bool IsValidEmail(string email)
    {
        return true;
    }
}
