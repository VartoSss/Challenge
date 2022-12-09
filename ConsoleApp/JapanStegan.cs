using Japan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;

public class JapanStegan
{
    static Dictionary<char, int> Symbols = new Dictionary<char, int>
    {
        { '#', 1 },
        { '.', 0 }
    };

    public static string JapanSteganSolver(string task)
    {
        var result = Japanese.SolveJapanese(task);
        var answer = new StringBuilder();

        foreach (var symbol in result)
        {
            answer.Append(symbol);
        }

        throw new Exception("aaaa");
    }
}
