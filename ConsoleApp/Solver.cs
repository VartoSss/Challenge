using Challenge.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp;

public class Solver
{
    public static string Solve(TaskResponse taskResponse)
    {
        if (taskResponse.TypeId == "steganography")
        {
            return SolveSteganography(taskResponse);
        }
        else
        {
            throw new Exception("AAAA TASK GO HARDER");
        }
    }

    public static string SolveSteganography(TaskResponse taskResponse)
    {
        var str = taskResponse.Question;
        var buildingStr = new StringBuilder();
        var lines = str.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var num = RomanToArab(lines[0]);
        for (var i = 1; i < lines.Length; i++)
        {
            buildingStr.Append(lines[i][num - 1]);
        }
        return buildingStr.ToString();
    }
    private static short RomanToArab(string roman)
    {
        short result = 0;
        var RomToArab = new Dictionary<char, short>
            {{ 'I', 1 },{ 'V', 5 },{ 'X', 10 },{ 'L', 50 },{ 'C', 100 },{ 'D', 500 },{ 'M', 1000 } };
        for (short i = 0; i < roman.Length - 1; ++i)
        {
            if (RomToArab[roman[i]] < RomToArab[roman[i + 1]]) result -= RomToArab[roman[i]];
            else if (RomToArab[roman[i]] >= RomToArab[roman[i + 1]]) result += RomToArab[roman[i]];
        }
        return result += RomToArab[roman[^1]];
    }
}