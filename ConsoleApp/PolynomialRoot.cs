using System;
using System.Collections.Generic;
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
            var multipliers = newEquation.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (multipliers.Length > 3)
                throw new Exception();
            else if (multipliers.Length == 3)
            {
                var a = double.Parse(multipliers[0]);
                var b = double.Parse(multipliers[1]);
                var c = double.Parse(multipliers[2]);
                double D = Math.Pow(b, 2) - 4 * a * c;
                if (D > 0 || D == 0)
                    return (((-b - Math.Sqrt(D)) / (2 * a)).ToString()).Replace(',', '.');
                else
                    return "no roots";
            }
            else if (multipliers.Length == 2) // ax + b = 0
            {
                var a = double.Parse(multipliers[0]);
                var b = double.Parse(multipliers[1]);
                if (((a == 0) && (b == 0)) || (b == 0))
                    return "0";
                else if (a == 0)
                    return "no roots";
                else
                    return (-b / a).ToString().Replace(',', '.');
            }
            else
                throw new Exception();
        }
    }
}
