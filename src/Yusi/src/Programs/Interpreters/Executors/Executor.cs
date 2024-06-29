namespace Yusi.Programs.Interpreters.Executors;

using Yusi.Programs.Interpreters.Executors.Strategies;
using Yusi.Programs.Interpreters.Statements;

public class Executor
{
    private readonly Dictionary<string, int> _variables;
    public Statement? Statement { private get; set; }

    public Executor()
    {
        _variables = new Dictionary<string, int>();
    }

    public void Execute()
    {
        if (Statement == null)
        {
            throw new Exception("No statement to execute");
        }

        if (Statement is Declaration declaration)
        {
            ExecuteStrategy<Declaration> strategy = new DeclarationStrategy();
            strategy.Execute(declaration, _variables);
        }
        else if (Statement is Assignment assignment)
        {
            ExecuteStrategy<Assignment> strategy = new AssignmentStrategy();
            strategy.Execute(assignment, _variables);
        }
        else if (Statement is Operation operation)
        {
            ExecuteStrategy<Operation> strategy = new OperationStrategy();
            strategy.Execute(operation, _variables);
        }
    }
}
