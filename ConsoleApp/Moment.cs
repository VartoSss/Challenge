using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Moment
    {
        public static string SolveMoment(string question)
        {
            var task = question;
            var SplitTimeDate = task.Split();
            var time = SplitTimeDate[0].Split(":");
            var hour = time[0];
            var minutes = time[1];
            var date = SplitTimeDate[1].Split(".");
            var day = date[0];
            var month = date[1];
            var monthsName = new[] { "января", "февараля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            var result = $"{day} {monthsName[int.Parse(month) - 1]} {hour}:{minutes}";
            return result;
        }
    }
}
