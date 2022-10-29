using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;

public class Cypher
{
    public static string SolveCypher(string question)
    {
        var task = question;
        var splittedTask = task.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
        if (splittedTask[0] == "reversed" && splittedTask.Length == 2)
        {
            var result = new StringBuilder();
            for (int i = splittedTask[1].Length - 1; i >= 0; i--)
                result.Append(splittedTask[1][i]);
            return result.ToString();
        }
        else
            throw new Exception("AAAAAA TASK GOT HARDER");
    }
}
