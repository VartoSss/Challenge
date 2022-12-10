using Japan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
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

        var japaneseMatrix = new List<string>();

        foreach (var row in japaneseRows)
        {
            var currentRow = new StringBuilder();
            foreach (var symbol in row)
                currentRow.Append(Symbols[symbol]);
            japaneseMatrix.Add(currentRow.ToString());
        }

        var matrixRows = new List<int>();
        var matrixRowsReversed = new List<int>();

        var matrixColumns = new List<int>();
        var matrixColumnsReversed = new List<int>();

        for (var i = 0; i < japaneseMatrix.Count; i++)
        {
            matrixRows.Add(BinaryToDecimal(japaneseMatrix[i]) - 1);
            matrixRowsReversed.Add(BinaryToDecimalReversed(japaneseMatrix[i]) - 1);
        }

        for (var i = 0; i < japaneseMatrix[0].Length; i++)
        {
            var currentColumn = new StringBuilder();
            foreach (var row in japaneseMatrix)
                currentColumn.Append(row[i]);
            matrixColumns.Add(BinaryToDecimal(currentColumn.ToString()) - 1);
            matrixColumnsReversed.Add(BinaryToDecimalReversed(currentColumn.ToString()) - 1);
        }

        var possibleIndexArrays = new[]
        {
            matrixColumns.ToArray(),
            matrixColumnsReversed.ToArray(),
            matrixRows.ToArray(),
            matrixRowsReversed.ToArray()
        };

        var rightArray = new int[0];

        foreach (var possibleArray in possibleIndexArrays)
        {
            var isLowerThanLenght = true;
            foreach (var index in possibleArray)
            {
                if (index < 0 || index >= taskText.Length)
                {
                    isLowerThanLenght = false;
                    break;
                }
            }

            if (isLowerThanLenght)
                rightArray = possibleArray;
        }

        var resultString = new StringBuilder();

        foreach (var index in rightArray)
            resultString.Append(taskText[index]);

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

    public static int BinaryToDecimalReversed(string binaryNumber)
    {
        var result = 0.0;
        var power = 0;

        for (var i = 0; i < binaryNumber.Length; i++)
        {
            var digit = binaryNumber[i].ToString();
            result += int.Parse(digit) * Math.Pow(2, power);
            power++;
        }

        return (int)result;
    }
}
