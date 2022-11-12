using System;
using System.Numerics;



namespace ConsoleApp
{
    public struct LongComplex
    {
        public BigInteger Real { get; }
        public BigInteger Imaginary { get; }

        public LongComplex(BigInteger real, BigInteger imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static LongComplex Add(LongComplex a, LongComplex b)
        {
            return new LongComplex((BigInteger)a.Real + (BigInteger)b.Real, (BigInteger)a.Imaginary + (BigInteger)b.Imaginary);
        }

        public static LongComplex Subtract(LongComplex a, LongComplex b)
        {
            return new LongComplex((BigInteger)a.Real - (BigInteger)b.Real, (BigInteger)a.Imaginary - (BigInteger)b.Imaginary);
        }

        public static LongComplex Multiply(LongComplex a, LongComplex b)
        {
            var real = (BigInteger)a.Real * (BigInteger)b.Real - (BigInteger)a.Imaginary * (BigInteger)b.Imaginary;
            var imaginary = (BigInteger)a.Real * (BigInteger)b.Imaginary + (BigInteger)a.Imaginary * (BigInteger)b.Real;
            return new LongComplex((BigInteger)real, (BigInteger)imaginary);
        }

        public static LongComplex DivideInteger(LongComplex a, LongComplex b)
        {
            var real = (BigInteger)a.Real / (BigInteger)b.Real;
            return new LongComplex((BigInteger)real, 0);
        }

        public static LongComplex DivideWithRemind(LongComplex a, LongComplex b)
        {
            var real = (BigInteger)a.Real % (BigInteger)b.Real;
            return new LongComplex((BigInteger)real, 0);
        }


        public static LongComplex Zero = new LongComplex(0, 0);

        public override string ToString()
        {
            if (Imaginary == 0)
                return $"{Real}";

            var imaginaryAbs = Math.Abs((decimal)Imaginary);
            var imaginaryString = imaginaryAbs == 1 ? "i" : $"{imaginaryAbs}i";

            if (Real == 0)
                return Imaginary >= 0 ? imaginaryString : $"-{imaginaryString}";

            return Imaginary >= 0 ? $"{Real}+{imaginaryString}" : $"{Real}-{imaginaryString}";
        }

        public static LongComplex Parse(string str)
        {
            if (str.EndsWith("i"))
            {
                var strWithoutI = str.Substring(0, str.Length - 1);
                if (strWithoutI.Contains("+"))
                {
                    var parts = strWithoutI.Split("+");
                    return new LongComplex(
                        BigInteger.Parse(parts[0].Trim()),
                        ParseImaginary(parts[1]));
                }
                if (strWithoutI.Length > 0 && strWithoutI.IndexOf("-", 1) >= 0)
                {
                    var parts = strWithoutI.Split("-");
                    var real = BigInteger.Parse(parts[parts.Length - 2].Trim());
                    if (parts.Length == 3)
                        real *= -1;
                    return new LongComplex(real,
                        -ParseImaginary(parts[parts.Length - 1]));
                }
                return new LongComplex(0, ParseImaginary(strWithoutI));
            }
            else
            {
                var real = BigInteger.Parse(str);
                return new LongComplex(real, 0);
            }
        }

        private static BigInteger ParseImaginary(string str)
        {
            str = str.Trim();
            if (str == "-")
                return -1L;
            if (str == string.Empty)
                return 1L;
            return BigInteger.Parse(str);
        }
    }
}
