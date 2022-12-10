using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IronPython.Modules.ArrayModule;

namespace ConsoleApp
{
    public class Statistics
    {
        public static string SolveStatistics(string question)
        {
            var str = question;
            if (question.Contains("#Caesar's code"))
            {
                str = Cypher.SolveCypher(question);
            }
            var data = str.Split('|');
            var minimum = int.MaxValue;
            var maximum = int.MinValue;
            if (question.Contains("increment") || question.Contains("decrement"))
            {
                if (data[1] == "")
                    return "0";
                var buildingStr = new StringBuilder();
                var splittedIncsAndDecs = data[0].Split('.');
                var values = new List<int>();
                var splittedArray = data[1].Split(' ');
                for (var i = 0; i < splittedArray.Length; i++)
                    values.Add(int.Parse(MathSolver.Solve(splittedArray[i])));
                for (var i = splittedIncsAndDecs.Length - 1; i >= 0; i--)
                {
                    if (splittedIncsAndDecs[i] == "increment")
                        Increment(values);
                    else if (splittedIncsAndDecs[i] == "decrement")
                        Decrement(values);
                    else if (splittedIncsAndDecs[i] == "double")
                        Double(values);
                    else if (splittedIncsAndDecs[i].Contains("take"))
                    {
                        var splittedTake = splittedIncsAndDecs[i].Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        var takeValue = int.Parse(splittedTake[1]);
                        if (takeValue > values.Count)
                            continue;
                        values = values.GetRange(0, takeValue);
                    }
                    else if (splittedIncsAndDecs[i].Contains("skip"))
                    {
                        var splittedSkip = splittedIncsAndDecs[i].Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        var skipValue = int.Parse(splittedSkip[1]);
                        if (skipValue > values.Count)
                            return "";
                        values.RemoveRange(0, skipValue);
                    }
                }
                for (var i = 0; i < values.Count; i++)
                {
                    buildingStr.Append(values[i]);
                    if (i != values.Count - 1)
                        buildingStr.Append(' ');
                }
                if (splittedIncsAndDecs[0] != "sum" && splittedIncsAndDecs[0] != "max" && splittedIncsAndDecs[0] != "min")
                    return buildingStr.ToString();
                else if (splittedIncsAndDecs[0] == "min")
                {
                    var numbers = buildingStr.ToString().Split(' ');
                    foreach (var el in numbers)
                    {
                        var num = int.Parse(el);
                        if (num < minimum)
                            minimum = num;
                    }
                    return minimum.ToString();
                }
                else if (splittedIncsAndDecs[0] == "max")
                {
                    var numbers = buildingStr.ToString().Split(' ');
                    foreach (var el in numbers)
                    {
                        var num = int.Parse(el);
                        if (num > maximum)
                            maximum = num;
                    }
                    return maximum.ToString();
                }
                else if (splittedIncsAndDecs[0] == "sum")
                {
                    var sumValue = 0;
                    var numbers = buildingStr.ToString().Split(' ');
                    foreach (var el in numbers)
                    {
                        var num = int.Parse(el);
                        sumValue += num;
                    }
                    return sumValue.ToString();
                }
                else
                    throw new Exception("something is wrong");
            }
            else if (data[0] == "min")
            {
                var numbers = data[1].Split(' ');
                foreach (var el in numbers)
                {
                    var num = int.Parse(el);
                    if (num < minimum)
                        minimum = num;
                }
                return minimum.ToString();
            }
            else if (data[0] == "max")
            {
                var numbers = data[1].Split(' ');
                foreach (var el in numbers)
                {
                    var num = int.Parse(el);
                    if (num > maximum)
                        maximum = num;
                }
                return maximum.ToString();
            }
            else if (data[0] == "sum")
            {
                var sumValue = 0;
                var numbers = data[1].Split(' ');
                foreach (var el in numbers)
                {
                    var num = int.Parse(el);
                    sumValue += num;
                }
                return sumValue.ToString();
            }
            else if (data[0] == "firstmostfrequent")
            {
                var mostFreq = 0;
                var mostFreqNum = "";
                var numbers = data[1].Split(' ');
                var intNums = new int[numbers.Length];
                for (var i = 0; i < numbers.Length; i++)
                {
                    var num = int.Parse(numbers[i]);
                    intNums[i] = num;
                }
                for (var i = 0; i < intNums.Length; i++)
                {
                    var counter = intNums.Count(v => v == intNums[i]);
                    if (counter > mostFreq)
                    {
                        mostFreq = counter;
                        mostFreqNum = intNums[i].ToString();
                    }
                }
                return mostFreqNum;
            }
            else
            {
                throw new Exception("new statistics");
            }
        }

        public static void Increment(List<int> values)
        {
            for (var i = 0; i < values.Count; i++)
                values[i] = values[i] + 1;
        }
        public static void Decrement(List<int> values)
        {
            for (var i = 0; i < values.Count; i++)
                values[i] = values[i] - 1;
        }

        public static void Double(List<int> values)
        {
            for (var i = 0; i < values.Count; i++)
                values[i] = values[i] * 2;
        }
    }
}
