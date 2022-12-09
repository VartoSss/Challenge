using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RandomMathSolver
    {
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
                string solvedExpresson;
                if (expressionType == "string-number")
                    solvedExpresson = StringNumber.StringNumberSolver(expressionValue);

                else if (expressionType == "math")
                    solvedExpresson = MathSolver.Solve(expressionValue);
                else if (expressionType == "determinant")
                    solvedExpresson = Determinant.DeterminantSolver(expressionValue);
                else
                    throw new Exception("Shit, bro");

                res.Append(solvedExpresson);
                res.Append("\" ");
            }
            res.Length--;
            return res.ToString();
        }
    }
}
