using Japan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        var taskParts = task.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var japaneseTask = taskParts[0];
        var taskText = taskParts[1];

        var japaneseResult = Japanese.SolveJapanese(japaneseTask);
        var japaneseRows = japaneseResult.Split(';');
        var answerInRows = new StringBuilder();
        var answerInColumns = new StringBuilder();

        for (var i = 0; i < japaneseRows[0].Length; i++)
        {
            var currentColumn = new StringBuilder();

        }

        foreach (var symbol in japaneseResult)
            if (Symbols.ContainsKey(symbol))
                answerInRows.Append(Symbols[symbol]);

        var binaryString = answerInRows.ToString();
        var reversedBinary = new StringBuilder();
        for (var i = binaryString.Length - 1; i >= 0; i--)
            reversedBinary.Append(binaryString[i]);

        var reversedString = reversedBinary.ToString();
        var binaryList = new List<string>();

        while (!string.IsNullOrEmpty(reversedString))
        {
            var currentBinary = reversedString.Substring(0, Math.Min(8, reversedString.Length));
            binaryList.Add(currentBinary);
            reversedString = reversedString.Substring(8);
        }

        var indexes = new List<int>();
        foreach (var binaryNumber in binaryList)
            indexes.Add(BinaryToDecimal(binaryNumber));

        var resultString = new StringBuilder();
        foreach (var index in indexes)
            resultString.Append(taskText[index % taskText.Length]);

        return resultString.ToString();
    }

    public static int BinaryToDecimal(string binaryNumber)
    {
        var result = 0.0;
        var power = 0;

        for (var i = binaryNumber.Length - 1; i >= 0; i--)
        {
            var digit = binaryNumber[i].ToString();
            result += int.Parse(digit) * Math.Pow(2, power);
            power++;
        }

        return (int)result;
    }
}
