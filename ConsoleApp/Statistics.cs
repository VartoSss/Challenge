using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else
            {
                throw new Exception("damn aarne goin crazy anymore");
            }
        }
    }
}
