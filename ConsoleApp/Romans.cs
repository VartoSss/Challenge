using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;

public class Romans
{
    public static short RomanToArab(string roman)
    {
        short result = 0;
        var RomToArab = new Dictionary<char, short>
            {{ 'I', 1 },{ 'V', 5 },{ 'X', 10 },{ 'L', 50 },{ 'C', 100 },{ 'D', 500 },{ 'M', 1000 } };
        for (short i = 0; i < roman.Length - 1; ++i)
        {
            if (RomToArab[roman[i]] < RomToArab[roman[i + 1]])
                result -= RomToArab[roman[i]];
            else if (RomToArab[roman[i]] >= RomToArab[roman[i + 1]])
                result += RomToArab[roman[i]];
        }
        return result += RomToArab[roman[^1]];
    }

    public static bool IsRoman(string number)
        {
            var possibleChars = new[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            foreach (var symbol in number)
                if (!possibleChars.Contains(symbol))
                    return false;
            return true;
        }
}
