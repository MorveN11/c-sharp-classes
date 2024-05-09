namespace Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool[] results =
            {
                Test1(),
                Test2(),
                Test3(),
                Test4(),
                Test5(),
                Test6(),
                Test7(),
                Test8()
            };

            byte points = 0;

            for (byte index = 0; index < results.Length; index++)
            {
                if (results[index])
                {
                    points++;
                }
            }

            Console.WriteLine($"Result: {points}/{results.Length}");
        }

        static bool Test1()
        {
            ComplexNumber complexNumberA = new ComplexNumber();

            ComplexNumber complexNumberB = new ComplexNumber(0, 0);

            ComplexNumber complexNumberC = new ComplexNumber(1, 0);

            ComplexNumber complexNumberD = new ComplexNumber(-2, 0);

            ComplexNumber complexNumberE = new ComplexNumber(0, 8);

            ComplexNumber complexNumberF = new ComplexNumber(0, -9);

            ComplexNumber complexNumberG = new ComplexNumber(1, 2);

            ComplexNumber complexNumberH = new ComplexNumber(5, -10);

            ComplexNumber complexNumberI = new ComplexNumber(0, 1);

            ComplexNumber complexNumberJ = new ComplexNumber(0, -1);

            ComplexNumber complexNumberK = new ComplexNumber(2, 1);

            ComplexNumber complexNumberL = new ComplexNumber(8, -1);

            return complexNumberA.ToString() == "0"
                && complexNumberB.ToString() == "0"
                && complexNumberC.ToString() == "1"
                && complexNumberD.ToString() == "-2"
                && complexNumberE.ToString() == "8i"
                && complexNumberF.ToString() == "-9i"
                && complexNumberG.ToString() == "1 + 2i"
                && complexNumberH.ToString() == "5 - 10i"
                && complexNumberI.ToString() == "i"
                && complexNumberJ.ToString() == "-i"
                && complexNumberK.ToString() == "2 + i"
                && complexNumberL.ToString() == "8 - i";
        }

        static bool Test2()
        {
            ComplexNumber complexNumber = new ComplexNumber(8, 3);

            return complexNumber == "8 + 3i" && complexNumber != "3 + 8i";
        }

        static bool Test3()
        {
            ComplexNumber complexNumberA = new ComplexNumber(5, -6);

            ComplexNumber complexNumberB = new ComplexNumber(-8, -3);

            return complexNumberA == "5 - 6i"
                && complexNumberA != "6 - 5i"
                && complexNumberB == "-8 - 3i";
        }

        static bool Test4()
        {
            ComplexNumber complexNumberA = new ComplexNumber(2, 7);

            ComplexNumber complexNumberB = new ComplexNumber(7, 5);

            ComplexNumber complexNumberC = new ComplexNumber(1, 6);

            ComplexNumber complexNumberD = new ComplexNumber(-8, -1);

            return complexNumberA + complexNumberB == "9 + 12i"
                && complexNumberC + complexNumberD == "-7 + 5i";
        }

        static bool Test5()
        {
            ComplexNumber complexNumber = new ComplexNumber(3, 2);

            return complexNumber + 1 == "4 + 2i"
                && 8 + complexNumber == "11 + 2i"
                && complexNumber + (-7) == "-4 + 2i"
                && -14 + complexNumber == "-11 + 2i";
        }

        static bool Test6()
        {
            ComplexNumber complexNumberA = new ComplexNumber(1, 2);

            ComplexNumber complexNumberB = new ComplexNumber(1, 2);

            ComplexNumber complexNumberC = new ComplexNumber(8, 2);

            return complexNumberA == complexNumberB && complexNumberA != complexNumberC;
        }

        static bool Test7()
        {
            ComplexNumber complexNumberA = new ComplexNumber(2, 6);

            ComplexNumber complexNumberB = new ComplexNumber(3, 11);

            ComplexNumber complexNumberC = new ComplexNumber(-5, 6);

            ComplexNumber complexNumberD = new ComplexNumber(9, -4);

            ComplexNumber complexNumberE = new ComplexNumber(-8, -10);

            return complexNumberA - complexNumberB == "-1 - 5i"
                && complexNumberB - complexNumberA == "1 + 5i"
                && complexNumberB - complexNumberC == "8 + 5i"
                && complexNumberC - complexNumberD == "-14 + 10i"
                && complexNumberD - complexNumberE == "17 + 6i";
        }

        static bool Test8()
        {
            ComplexNumber complexNumberA = new ComplexNumber(1, -3);

            ComplexNumber complexNumberB = new ComplexNumber(2, 5);

            ComplexNumber complexNumberC = new ComplexNumber(5, 5);

            ComplexNumber complexNumberD = new ComplexNumber(8, 9);

            ComplexNumber complexNumberE = new ComplexNumber(-1, -1);

            return complexNumberA * complexNumberB == "17 - i"
                && complexNumberC * complexNumberD == "-5 + 85i"
                && complexNumberE * complexNumberD == "1 - 17i";
        }
    }
}
