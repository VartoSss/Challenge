using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class json
    {
        public static string SolveCommonJSON(string question)
        {
            var counter = (BigInteger)0;
            var splittedTask = question.Split('\"');
            var nums = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            
            for (var i = 0; i < splittedTask.Length; i++)
            {
                if (CheckNums(splittedTask[i], nums) || CheckMath(splittedTask[i]) || CheckDeterminant(splittedTask[i]) || CheckSN(splittedTask[i]) || CheckCypher(splittedTask[i]))
                {

                    var mathSentence = splittedTask[i];
                    if (CheckCypher(splittedTask[i]))
                    {
                        var splittedCypher = splittedTask[i].Split("|");
                        mathSentence = StringNumber.StringNumberSolver(Cypher.SolveCypher(splittedCypher[1]));
                    }
                    else if (CheckMath(splittedTask[i]))
                    {
                        var splittedMath = splittedTask[i].Split("|");
                        mathSentence = MathSolver.Solve(splittedMath[1]);
                    }
                    else if (CheckDeterminant(splittedTask[i]))
                    {
                        var splittedDet = splittedTask[i].Split("|");
                        mathSentence = Determinant.DeterminantSolver(splittedDet[1]);
                    }
                    else if (CheckSN(splittedTask[i]))
                    {
                        var splittedSN = splittedTask[i].Split("|");
                        mathSentence = StringNumber.StringNumberSolver(splittedSN[1]);
                    }
                    counter += BigInteger.Parse(mathSentence);
                }
            }
            return counter.ToString();
        }

        public static bool CheckNums(string str, char[] nums)
        {
            foreach (var el in str)
            {
                if (nums.Contains(el))
                    return true;
            }
            return false;
        }

        public static bool CheckMath(string str)
        {
            return str.Contains("math|");
        }

        public static bool CheckDeterminant(string str)
        {
            return str.Contains("determinant|");
        }

        public static bool CheckSN(string str)
        {
            return str.Contains("string-number|");
        }

        public static bool CheckCypher(string str)
        {
            return str.Contains("cypher|");
        }
    }
}
