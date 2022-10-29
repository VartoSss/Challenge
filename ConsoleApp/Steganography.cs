using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Steganography
    {
        public static string SolveSteganography(string question)
        {
            var str = question;
            var buildingStr = new StringBuilder();
            var lines = str.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var num = RomanToArab(lines[0]);
            for (var i = 1; i < lines.Length; i++)
                buildingStr.Append(lines[i][num - 1]);

            return buildingStr.ToString();
        }
        private static short RomanToArab(string roman)
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
    }
}
