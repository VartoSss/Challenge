using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class json
    {
        public static string SolveCommonJSON(string question)
        {
            var counter = 0;
            var nums = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var buildingStr = new StringBuilder();
            for (var i = 0; i < question.Length; i++)
            {
                if (question[i] == '-' || nums.Contains(question[i]))
                    buildingStr.Append(question[i]);
                else
                {
                    if (!string.IsNullOrEmpty(buildingStr.ToString()))
                        counter += int.Parse(buildingStr.ToString());
                    buildingStr = new StringBuilder();
                }
            }
            return counter.ToString();
        }
    }
}
