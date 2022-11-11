using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class PolynomialRoot
    {
        public static string SolvePolynom(string question)
        {
            var equation = question;
            var newEquation = "";
            for (var i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '^')
                    i += 1;
                else
                    newEquation += equation[i];
            }
            newEquation = newEquation.Replace('.', ',');
            var separators = new string[] { "(", ")", "*", "^", "x", " ", "+" };
            var stringMultipliers = newEquation.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (double.Parse(stringMultipliers[stringMultipliers.Length - 1]) == 0)
                return "0.0";
            if (stringMultipliers.Length == 3)
            {
                var a = double.Parse(stringMultipliers[0]);
                var b = double.Parse(stringMultipliers[1]);
                var c = double.Parse(stringMultipliers[2]);
                double D = Math.Pow(b, 2) - 4 * a * c;
                if (D > 0 || D == 0)
                    return (((-b - Math.Sqrt(D)) / (2 * a)).ToString()).Replace(',', '.');
                else
                    return "no roots";
            }
            else if (stringMultipliers.Length == 2) // ax + b = 0
            {
                var a = double.Parse(stringMultipliers[0]);
                var b = double.Parse(stringMultipliers[1]);
                if (((a == 0) && (b == 0)) || (b == 0))
                    return "0";
                else if (a == 0)
                    return "no roots";
                else
                    return (-b / a).ToString().Replace(',', '.');
            }
            else if (stringMultipliers.Length > 3)
            {
                var multipliers = new double [stringMultipliers.Length];
                for (var i = 0; i < stringMultipliers.Length; i++)
                {
                    multipliers[i] = double.Parse(stringMultipliers[i]);
                }

                var polynomialRoot = double.MaxValue;
                polynomialRoot = BinaryFindRoot(multipliers);
                return polynomialRoot.ToString().Replace(',', '.');
            }
            else
                throw new Exception("unexpected polynom situation");
        }

        private static double BinaryFindRoot(double[] multipliers)
        {
            var root = 0.0;
            var found = 0;
            var eps = 1.0e-8;
            for (double a = -100; a < 100; a+=0.5)
            {
                var b = a + 0.5;
                var fa = f(a, multipliers);
                var fb = f(b, multipliers);
                if (fa * fb > 0)
                    continue;
                while (true)
                {
                    var c = (a + b) * 0.5;
                    if (Math.Abs(a - b) < eps)
                    {
                        root = c;
                        found = 1;
                        break;
                    }

                    var fc = f(c, multipliers);
                    if (Math.Abs(fc) < eps)
                    {
                        root = c;
                        found = 1;
                        break;
                    }

                    if (fc * fa < 0)
                    {
                        b = c;
                        fb = fc;
                    }
                    else
                    {
                        a = c;
                        fa = fc;
                    }
                }
            }

            if (found == 1)
                return Math.Round(root, 3);
            else
                throw new Exception("Didn't find the roots");
        }


        public static double f(double x, double[] multipliers)
        {
            var result = 0.0;
            var mulCount = multipliers.Length;
            for (var i = 0; i < mulCount; i++)
            {
                result += multipliers[i] * Math.Pow(x, mulCount - i - 1);
            }

            return result;
        }
    }
}
