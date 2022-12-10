using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Xml.Linq;

namespace ConsoleApp
{
    public class RandomMathSolver
    {
        static string[] Operations = new[]
        {
            "twice", "thrice", "squared", "cubed",
            "plus", "minus", "times"
        };

        static string[] PostfixOperations = new[]
        {
            "twice", "thrice", "squared", "cubed"
        };

        static string[] InfixOperations = new[]
        {
            "plus", "minus", "times"
        };
 
        public static string SolveRandomMath(string question)
        {
            var separators = new[] { '\"' };
            var allExpressions = question.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var res = new StringBuilder();
            foreach (var expression in allExpressions)
            {
                if (expression == " ")
                    continue;
                var splittedExpression = expression.Split('|');
                var expressionType = splittedExpression[0];
                var expressionValue = splittedExpression[1];
                res.Append('\"');
                string solvedExpression;
                if (expressionType == "string-number")
                    solvedExpression = ConvertStringNumWithOperationsToNum(expressionValue);

                else if (expressionType == "math")
                    solvedExpression = MathSolver.Solve(expressionValue);
                else if (expressionType == "determinant")
                    solvedExpression = Determinant.DeterminantSolver(expressionValue);
                else if (expressionType == "polynomial-root")
                    solvedExpression = PolynomialRoot.SolvePolynom(expressionValue);
                else if (expressionType == "cypher")
                    solvedExpression = SolveRandomMath(Cypher.SolveCypher(expression.Substring(7)));
                else
                    throw new Exception("Shit, bro");

                res.Append(solvedExpression);
                res.Append("\" ");
            }
            res.Length--;
            res = res.Replace("\"\"", "\"");
            return res.ToString();
        }

        public static string ConvertStringNumWithOperationsToNum(string expressionValue)
        {
            var expressionParts = expressionValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var currentNumber = new StringBuilder();
            var formula = new StringBuilder();

            foreach (var part in expressionParts)
            {
                if (Operations.Contains(part))
                {
                    var number = "";
                    if (currentNumber.Length != 0)
                        number = StringNumber.StringNumberSolver(currentNumber.ToString());
                    currentNumber.Clear();

                    formula.Append(number + ' ');
                    formula.Append(part + ' ');
                }
                else
                    currentNumber.Append(part + ' ');
            }
            if (currentNumber.Length > 0)
            {
                formula.Append(StringNumber.StringNumberSolver(currentNumber.ToString()));
                currentNumber.Clear();
            }
            else
                formula.Length--;

            return ConvertFormulaToNumber(formula.ToString());
        }

        public static string ConvertFormulaToNumber(string formula)
        {
            formula = formula.Replace("plus", "+").Replace("minus", "-").Replace("times", "*");


            var answer = new StringBuilder();
            var elements = formula.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < elements.Length; i++)
            {
                var element = elements[i];

                if (PostfixOperations.Contains(element))
                {
                    var numberToOperate = BigInteger.Parse(elements[i - 1]);

                    if (element == "twice")
                        answer.Append(numberToOperate * 2);
                    else if (element == "thrice")
                        answer.Append(numberToOperate * 3);
                    else if (element == "squared")
                        answer.Append(numberToOperate * numberToOperate);
                    else if (element == "cubed")
                        answer.Append(numberToOperate * numberToOperate * numberToOperate);
                }

                else if ((i < elements.Length - 1 && !PostfixOperations.Contains(elements[i + 1])) || i == elements.Length - 1)
                    answer.Append(element); 
            }
            var result = MathSolver.Solve(answer.ToString());

            return result;
        }
    }
}
