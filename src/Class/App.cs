namespace MyApp
{
    public interface IMyInterface
    {
        int GetValue();
        string Value { get; set; }
    }

    public interface IMyInterface2
    {
        string Value { get; set; }
    }

    public abstract class ClassN : IMyInterface, IMyInterface2
    {
        public string Value { get; set; } = string.Empty;

        public abstract int GetValue();
    }

    public class Classy : ClassN
    {
        public override int GetValue()
        {
            return 100;
        }
    }

    public class ClassA
    {
        private int _value;

        public ClassA(int value)
        {
            _value = value;
        }

        public virtual int GetValue()
        {
            return _value;
        }
    }

    public class ClassB : ClassA
    {
        public ClassB(int value)
            : base(value) { }

        public override int GetValue()
        {
            return base.GetValue() * 2;
        }
    }

    public class ClassC : ClassB
    {
        public ClassC(int value)
            : base(value) { }

        public override int GetValue()
        {
            return base.GetValue();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ClassN classy = new Classy();
            Console.WriteLine(classy.GetValue());
            Console.WriteLine(classy.Value);
        }
    }
}
