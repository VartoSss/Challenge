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
            var openBracketsCounter = 0;
            var closeBracketsCounter = 0;
            var openClosedBracketsCounter = 0;
            var i = startIndex;
            while(openClosedBracketsCounter != 2)
            {
                function.Append(question[i]);
                if (!char.IsLetter(question[i]))
                {
                    if (question[i] == ')')
                        closeBracketsCounter++;
                    else if (question[i] == '(')
                        openBracketsCounter++;
                    if (openBracketsCounter == closeBracketsCounter)
                        openClosedBracketsCounter++;
                }
                i++;
            }
            return new[] { function.ToString(), i.ToString() };
        }

        public static string CalculateFunction(string function)
        {
            string functionName, argument1, argument2;
            GetFunctionAndArguments(function, out functionName, out argument1, out argument2);

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

        private static void GetFunctionAndArguments(string function, out string functionName, out string argument1, out string argument2)
        {
            var currentIndex = 0;
            var openBracketsCounter = 0;
            var closedBracketsCounter = 0;
            var functionNameSB = new StringBuilder();
            while (char.IsLetter(function[currentIndex]))
            {
                functionNameSB.Append(function[currentIndex]);
                currentIndex++;
            }
            functionName = functionNameSB.ToString();

            currentIndex++;
            openBracketsCounter++;
            argument1 = GetArgument(function, ref currentIndex, ref openBracketsCounter, ref closedBracketsCounter);

            currentIndex++;
            openBracketsCounter++;

            argument2 = GetArgument(function, ref currentIndex, ref openBracketsCounter, ref closedBracketsCounter);
        }

        private static string GetArgument(string function, ref int currentIndex, ref int openBracketsCounter, ref int closedBracketsCounter)
        {
            string argument1;
            var argument1SB = new StringBuilder();
            while (openBracketsCounter != closedBracketsCounter)
            {   argument1SB.Append(function[currentIndex]);
                if (function[currentIndex] == '(')
                    openBracketsCounter++;
                else if (function[currentIndex] == ')')
                    closedBracketsCounter++;  
                currentIndex++;
            }
            argument1SB.Remove(argument1SB.Length - 1, 1);
            argument1 = argument1SB.ToString();
            return argument1;
        }
    }
}