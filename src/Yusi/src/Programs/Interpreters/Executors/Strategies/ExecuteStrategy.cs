namespace Yusi.Programs.Interpreters.Executors.Strategies;

using Yusi.Programs.Interpreters.Statements;

public interface ExecuteStrategy<T>
    where T : Statement, new()
{
    public void Execute(T statement, Dictionary<string, int> variables);
}
