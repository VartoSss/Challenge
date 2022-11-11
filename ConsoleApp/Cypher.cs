using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        else if (splittedTask.Length == 2 && splittedTask[0].Substring(0, 14) == "Caesar's code=")
        {
            var chars = new char[]
            {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3',
            '4', '5', '6', '7', '8', '9', '\'', ' '
            };

            //поменяй тут пж чтобы принимало с сайта
            var str = splittedTask[1];
            var shift = int.Parse(splittedTask[0].Substring(14));

            var result = new StringBuilder();

            for (var i = 0; i < str.Length; i++)
            {
                var index = (Array.IndexOf(chars, str[i]) - shift) % chars.Length;
                if (index < 0)
                    index = chars.Length + index;
                var newSymbol = chars[index];
                result.Append(newSymbol.ToString());
            }
            //и тут на return)
            return result.ToString();
        }

        else if (splittedTask[0].Substring(0, 20) == "prime multiplicator=")
        {
            var chars = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3',
                '4', '5', '6', '7', '8', '9', '\'', ' '
            };

            var result = new StringBuilder();

            var taskParts = splittedTask[0].Split(": ");
            var formula = taskParts[1];
            var multiplicator = new StringBuilder();
            for (var i = 20; i < taskParts[0].Length; i++)
            {
                if (char.IsDigit(taskParts[0][i]))
                    multiplicator.Append(taskParts[0][i]);
                else
                    break;
            }

            var intMultiplicator = int.Parse(multiplicator.ToString());

            if (formula == "(multiplicator * (charIndex + 1)) % (|ABC| + 1) - 1")
            {
                var alphabetPower = chars.Length;
                for (var i = 0; i < splittedTask[1].Length; i++)
                {
                    var currentIndex = Array.IndexOf(chars, splittedTask[1][i]);
                    for (var j = 0; j < chars.Length; j++)
                    {
                        if ((intMultiplicator * (j + 1) % (chars.Length + 1) - 1) == currentIndex)
                        {
                            result.Append(chars[j].ToString());
                            break;
                        }
                    }
                }
                return result.ToString();
            }
            else
                throw new Exception("new formula in cypher task");
        }
        else
            throw new Exception("AAAAAA TASK GOT HARDER");
    }
}
