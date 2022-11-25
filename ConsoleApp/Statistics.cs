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
            var data = str.Split('|');
            var minimum = int.MaxValue;
            var maximum = int.MinValue;
            if (data[0] == "min")
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
    }
}
