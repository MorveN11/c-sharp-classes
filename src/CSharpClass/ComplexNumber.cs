namespace CSharpClass
{
    public struct ComplexNumber
    {
        private readonly int _real;
        private readonly int _i;

        public ComplexNumber(int real, int imaginary)
        {
            _real = real;
            _i = imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a._real + b._real, a._i + b._i);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a._real - b._real, a._i - b._i);
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return a._real == b._real && a._i == b._i;
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is ComplexNumber))
            {
                return false;
            }

            ComplexNumber other = (ComplexNumber)obj;

            return _real == other._real && _i == other._i;
        }

        public override int GetHashCode()
        {
            return _real.GetHashCode() ^ _i.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_real} + {_i}i";
        }
    }
}
