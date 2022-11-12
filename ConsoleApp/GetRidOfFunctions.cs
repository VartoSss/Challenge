using System;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ConsoleApp
{
    public class GetRidOfFunctions
    {
        public static string CalculateFunctions(string question)
        {
            var result = new StringBuilder();
            var possibleFunctionsStarts = new char[] { 'm', 'l', 'r', 's' };
            for (var i = 0; i < question.Length; i++)
            {
                if (possibleFunctionsStarts.Contains(question[i]))
                {
                    var function = GetFunction(question, i)[0];
                    var indexAdd = GetFunction(question, i)[1];
                    var calculatedFunction = CalculateFunction(function);
                    result.Append(calculatedFunction);
                    i = int.Parse(indexAdd) - 1;
                }
                else
                    result.Append(question[i]);
            }
            return result.ToString();
        }

        public static string[] GetFunction(string question, int startIndex)
        {
            var function = new StringBuilder();
            var closeBracketsCounter = 0;
            var i = startIndex;
            while(closeBracketsCounter != 2)
            {
                function.Append(question[i]);
                if (question[i] == ')')
                    closeBracketsCounter++;
                i++;
            }
            return new[] { function.ToString(), i.ToString() };
        }

        public static string CalculateFunction(string function)
        {
            var brackets = new[] { ')', '(' };
            var splitted = function.Split(brackets, StringSplitOptions.RemoveEmptyEntries);
            var functionName = splitted[0];
            var argument1 = splitted[1];
            var argument2 = splitted[2];

            argument1 = MathSolver.Solve(argument1);
            argument2 = MathSolver.Solve(argument2);

            var a = BigInteger.Parse(argument1);
            var b = BigInteger.Parse(argument2);
            var res = (BigInteger)0;

            if (functionName == "min")
                res = a < b ? a : b;
            else if (functionName == "max")
                res = a > b ? a : b;
            else if (functionName == "left")
                res = a;
            else if (functionName == "right")
                res = b;
            else if (functionName == "sum")
                res = a + b;
            else if (functionName == "mul")
                res = a * b;

            return res.ToString();


        }
    }
}