using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp
{
    public class PolynomialRoot
    {
        public static string SolvePolynom(string question)
        {

            var multipliers = GetDoubleMultipliers(question);
            if (multipliers[multipliers.Length - 1] == 0)
                return "0.0";
            if (multipliers.Length == 3)
            {
                var a = multipliers[0];
                var b = multipliers[1];
                var c = multipliers[2];
                double D = Math.Pow(b, 2) - 4 * a * c;
                if (D > 0 || D == 0)
                    return (((-b - Math.Sqrt(D)) / (2 * a)).ToString()).Replace(',', '.');
                else
                    return "no roots";
            }
            else if (multipliers.Length == 2) // ax + b = 0
            {
                var a = multipliers[0];
                var b = multipliers[1];
                if (((a == 0) && (b == 0)) || (b == 0))
                    return "0";
                else if (a == 0)
                    return "no roots";
                else
                    return (-b / a).ToString().Replace(',', '.');
            }
            else if (multipliers.Length > 3)
            {
                var polynomialRoot = BinaryFindRoot(multipliers);
                if (double.IsNaN(polynomialRoot))
                {
                    return "no roots";
                }
                return polynomialRoot.ToString().Replace(',', '.');
            }
            else
                throw new Exception("unexpected polynom situation");
        }

        public static double[] GetDoubleMultipliers(string polynom)
        {
            var newEquation = new StringBuilder();
            for (var i = 0; i < polynom.Length; i++)
            {
                if (polynom[i] == '^') i++;
                else if (polynom[i] == '.') newEquation.Append(',');
                else newEquation.Append(polynom[i]);
            }
            var separators = new string[] { "(", ")", "*", "^", "x", " ", "+" };
            var stringMultipliers = newEquation.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var multipliers = new double[stringMultipliers.Length];
            for (var i = 0; i < multipliers.Length; i++)
                multipliers[i] = double.Parse(stringMultipliers[i]);
            return multipliers;
        }

        private static double BinaryFindRoot(double[] multipliers)
        {
            var lolo = CalculatePolynom(29.40753872320056, multipliers);
            var root = 0.0;
            var found = 0;
            var eps = 1.0e-5;
            for (double a = -100; a < 100; a += 0.5)
            {
                var b = a + 0.5;
                var fa = CalculatePolynom(a, multipliers);
                var fb = CalculatePolynom(b, multipliers);
                if (fa * fb > 0)
                    continue;
                while (true)
                {
                    var c = a + (b - a) * 0.5;
                    var fc = CalculatePolynom(c, multipliers);
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
            {
                var res = CalculatePolynom(root, multipliers);
                if (Math.Abs(res) > 1e-3)
                    throw new Exception("Not enough precision");
                return root;
            }
            else
                return double.NaN; //throw new Exception("didn't find the roots"); // double.NaN; //
        }


        public static double CalculatePolynom(double x, double[] multipliers)
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
