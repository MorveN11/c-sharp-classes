namespace Numbers
{
    struct ComplexNumber
    {
        private readonly int _real;
        private readonly int _i;

        public ComplexNumber(int real, int i)
        {
            _real = real;
            _i = i;
        }

        public static bool operator ==(ComplexNumber first, string second)
        {
            return first.ToString().Equals(second);
        }

        public static bool operator !=(ComplexNumber first, string second)
        {
            return !(first == second);
        }

        public static bool operator ==(ComplexNumber first, ComplexNumber second)
        {
            return first._real == second._real && first._i == second._i;
        }

        public static bool operator !=(ComplexNumber first, ComplexNumber second)
        {
            return !(first == second);
        }

        public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first._real + second._real, first._i + second._i);
        }

        public static ComplexNumber operator +(ComplexNumber first, int number)
        {
            return new ComplexNumber(first._real + number, first._i);
        }

        public static ComplexNumber operator +(int number, ComplexNumber second)
        {
            return second + number;
        }

        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first._real - second._real, first._i - second._i);
        }

        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
            int real = (first._real * second._real) - (first._i * second._i);
            int i = (first._real * second._i) + (first._i * second._real);

            return new ComplexNumber(real, i);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is ComplexNumber))
            {
                return false;
            }

            ComplexNumber other = (ComplexNumber)obj;

            return this == other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            if (_i == 0 || (_i == 0 && _real == 0))
            {
                return $"{_real}";
            }

            string sign = _i < 0 ? "-" : "";
            string number = _i == -1 || _i == 1 ? "i" : $"{Math.Abs(_i)}i";

            if (_real == 0)
            {
                return $"{sign}{number}";
            }

            sign = _i < 0 ? "-" : "+";

            return $"{_real} {sign} {number}";
        }
    }
}
