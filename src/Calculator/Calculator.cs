public enum OperationType
{
    Add = '+',
    Subtract = '-',
    Multiply = '*',
    Divide = '/'
}

public static class OperationMapper
{
    public static readonly Dictionary<char, OperationType> OperationMap = new Dictionary<
        char,
        OperationType
    >
    {
        { '+', OperationType.Add },
        { '-', OperationType.Subtract },
        { '*', OperationType.Multiply },
        { '/', OperationType.Divide }
    };
}

public interface IOperation
{
    int Execute();
}

public abstract class UnaryOperation : IOperation
{
    protected readonly int Num;

    protected UnaryOperation(int num)
    {
        Num = num;
    }

    public abstract int Execute();
}

public abstract class BinaryOperation : UnaryOperation
{
    protected readonly int Num2;

    protected BinaryOperation(int num, int num2)
        : base(num)
    {
        Num2 = num2;
    }
}

public class Add : BinaryOperation
{
    public Add(int num1, int num2)
        : base(num1, num2) { }

    public override int Execute()
    {
        return Num + Num2;
    }
}

public class Subtract : BinaryOperation
{
    public Subtract(int num1, int num2)
        : base(num1, num2) { }

    public override int Execute()
    {
        return Num - Num2;
    }
}

public class Multiply : BinaryOperation
{
    public Multiply(int num1, int num2)
        : base(num1, num2) { }

    public override int Execute()
    {
        return Num * Num2;
    }
}

public class Divide : BinaryOperation
{
    public Divide(int num1, int num2)
        : base(num1, num2) { }

    public override int Execute()
    {
        return Num / Num2;
    }
}

public class OperationFactory
{
    public IOperation CreateOperation(OperationType op, int num1, int num2)
    {
        return op switch
        {
            OperationType.Add => new Add(num1, num2),
            OperationType.Subtract => new Subtract(num1, num2),
            OperationType.Multiply => new Multiply(num1, num2),
            OperationType.Divide => new Divide(num1, num2),
            _ => throw new ArgumentException("Invalid operation type")
        };
    }
}

public class CalculatorParser
{
    public OperationType[] GetOperators(string expression)
    {
        return expression
            .Where(c => OperationMapper.OperationMap.ContainsKey(c))
            .Select(c => OperationMapper.OperationMap[c])
            .ToArray();
    }

    public int[] GetOperands(string expression)
    {
        return expression
            .Split(OperationMapper.OperationMap.Keys.ToArray())
            .Select(int.Parse)
            .ToArray();
    }
}

public class Calculator
{
    private readonly CalculatorParser _parser;
    private readonly OperationFactory _operationFactory;

    public Calculator()
    {
        _parser = new CalculatorParser();
        _operationFactory = new OperationFactory();
    }

    public int Calculate(string expression)
    {
        var operators = _parser.GetOperators(expression);
        var operands = _parser.GetOperands(expression);

        var result = operands[0];

        for (var i = 0; i < operators.Length; i++)
        {
            var operation = _operationFactory.CreateOperation(
                operators[i],
                result,
                operands[i + 1]
            );

            result = operation.Execute();
        }

        return result;
    }
}
