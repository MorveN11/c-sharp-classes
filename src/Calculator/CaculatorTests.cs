using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    [Test]
    public void ShouldGetOperands()
    {
        var CalculatorParser = new CalculatorParser();
        string expression;
        int[] actual;

        expression = "1+2";
        actual = CalculatorParser.GetOperands(expression);
        Assert.That(actual, Is.EqualTo(new int[] { 1, 2 }));

        expression = "1-2-4/2-4";
        actual = CalculatorParser.GetOperands(expression);
        Assert.That(actual, Is.EqualTo(new int[] { 1, 2, 4, 2, 4 }));
    }

    [Test]
    public void ShouldGetOperators()
    {
        var CalculatorParser = new CalculatorParser();
        string expression;
        OperationType[] actual;

        expression = "1+2";
        actual = CalculatorParser.GetOperators(expression);
        Assert.That(actual, Is.EqualTo(new OperationType[] { OperationType.Add }));

        expression = "1-2-4/2-4";
        actual = CalculatorParser.GetOperators(expression);
        Assert.That(
            actual,
            Is.EqualTo(
                new OperationType[]
                {
                    OperationType.Subtract,
                    OperationType.Subtract,
                    OperationType.Divide,
                    OperationType.Subtract
                }
            )
        );
    }

    [Test]
    public void ShouldAddTwoNumbers()
    {
        int actual;
        IOperation Sum;

        Sum = new Add(5, 13);
        actual = Sum.Execute();
        Assert.That(actual, Is.EqualTo(18));

        Sum = new Add(1, 2);
        actual = Sum.Execute();
        Assert.That(actual, Is.EqualTo(3));
    }

    [Test]
    public void ShouldSubtractTwoNumbers()
    {
        int actual;
        IOperation Subtract;

        Subtract = new Subtract(5, 13);
        actual = Subtract.Execute();
        Assert.That(actual, Is.EqualTo(-8));

        Subtract = new Subtract(1, 2);
        actual = Subtract.Execute();
        Assert.That(actual, Is.EqualTo(-1));
    }

    [Test]
    public void ShouldMultiplyTwoNumbers()
    {
        int actual;
        IOperation Multiply;

        Multiply = new Multiply(5, 13);
        actual = Multiply.Execute();
        Assert.That(actual, Is.EqualTo(65));

        Multiply = new Multiply(1, 2);
        actual = Multiply.Execute();
        Assert.That(actual, Is.EqualTo(2));
    }

    [Test]
    public void ShouldDivideTwoNumbers()
    {
        int actual;
        IOperation Divide;

        Divide = new Divide(8, 4);
        actual = Divide.Execute();
        Assert.That(actual, Is.EqualTo(2));

        Divide = new Divide(20, 5);
        actual = Divide.Execute();
        Assert.That(actual, Is.EqualTo(4));
    }

    [Test]
    public void ShouldCalculateExpression()
    {
        int actual;
        var calculator = new Calculator();

        actual = calculator.Calculate("1+2*5/2-10");
        Assert.That(actual, Is.EqualTo(-3));

        actual = calculator.Calculate("10-5+2*3");
        Assert.That(actual, Is.EqualTo(21));

        actual = calculator.Calculate("25/5-2*3");
        Assert.That(actual, Is.EqualTo(9));

        actual = calculator.Calculate("100/5-2*3");
        Assert.That(actual, Is.EqualTo(54));
    }
}
