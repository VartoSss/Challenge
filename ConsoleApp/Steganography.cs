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
            var lines = str.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var firstline = lines[0];
            var splittedFirstLine = firstline.Split(' ');
            if (splittedFirstLine.Length == 1 && CheckIfRoman(splittedFirstLine) && !CheckIfSpecialSymbols(splittedFirstLine))
            {
                return SolveRomanSteganography(lines);
            }
            else if (firstline.Contains('(') && firstline.Contains(')'))
            {
                return SolveChainSteganography(lines);
            }
            else if (splittedFirstLine.Length > 1 && CheckIfRoman(splittedFirstLine) && !CheckIfSpecialSymbols(splittedFirstLine))
            {
                return SolveRowRomanSteganography(lines);
            }
            else if (splittedFirstLine.Length > 1 && !CheckIfRoman(splittedFirstLine) && !CheckIfSpecialSymbols(splittedFirstLine))
            {
                return SolveRowSteganography(lines);
            }
            else if (splittedFirstLine.Length > 1 && CheckIfSpecialSymbols(splittedFirstLine))
            {
                return SolveChemSteganography(lines);
            }
            else
                throw new Exception("Something new in stegan");
        }
        public static bool CheckIfSpecialSymbols(string[] splittedFirstLine)
        {
            foreach (var el in splittedFirstLine)
            {
                if (el.Contains('[') || el.Contains(']'))
                    return true;
            }
            return false;
        }
        public static bool CheckIfRoman(string[] splittedFirstLine)
        {
            char[] nums = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var checkifroman = true;
            foreach (var el in splittedFirstLine)
            {
                foreach (var num in nums)
                {
                    if (el.Contains(num))
                    {
                        checkifroman = false;
                        break;
                    }
                }
                if (!checkifroman)
                    break;
            }
            if (!checkifroman)
                return false;
            return true;
        }
        public static string SolveChemSteganography(string[] lines)
        {
            var buildingStr = new StringBuilder();
            var chemElements = new string[] { "H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne", "Na", "Mg", "Al", "Si", "P", "S", "Cl", "Ar", "K", "Ca", "Sc", "Ti", "V", "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn", "Ga", "Ge", "As", "Se", "Br", "Kr", "Rb", "Sr", "Y", "Zr", "Nb", "Mo", "Tc", "Ru", "Rh", "Pd", "Ag", "Cd", "In", "Sn", "Sb", "Te", "I", "Xe", "Cs", "Ba", "La", "Ce", "Pr", "Nd", "Pm", "Sm", "Eu", "Gd", "Tb", "Dy", "Ho", "Er", "Tm", "Yb", "Lu", "Hf", "Ta", "W", "Re", "Os", "Ir", "Pt", "Au", "Hg", "Tl", "Pb", "Bi", "Po", "At", "Rn", "Fr", "Ra", "Ac", "Th", "Pa", "U", "Np", "Pu", "Am", "Cm", "Bk", "Cf", "Es", "Fm", "Md", "No", "Lr", "Rf", "Db", "Sg", "Bh", "Hs", "Mt", "Ds", "Rg", "Cn", "Nh", "Fl", "Mc", "Lv", "Ts", "Og", "Uue", "Ubn", "Ubu", "Ubb", "Ubt", "Ubq", "Ubp", "Ubh", "Ubs" };
            var chems = lines[0].Split(new[] { '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var el in chems)
            {
                var index = Array.IndexOf(chemElements, el);
                buildingStr.Append(lines[1][index]);
            }
            return buildingStr.ToString();
        }
        public static string SolveRowRomanSteganography(string[] lines)
        {
            var buildingStr = new StringBuilder();
            foreach (var el in lines[0].Split(' '))
            {
                var number = RomanToArab(el);
                buildingStr.Append(lines[1][number - 1]);
            }
            return buildingStr.ToString();
        }
        public static string SolveRomanSteganography(string[] lines)
        {
            var buildingStr = new StringBuilder();
            var num = RomanToArab(lines[0]);
            for (var i = 1; i < lines.Length; i++)
                buildingStr.Append(lines[i][num - 1]);
            return buildingStr.ToString();
        }
        public static string SolveRowSteganography(string[] lines)
        {
            var buildingStr = new StringBuilder();
            var nums = lines[0].Split(' ');
            for (var i = 0; i < nums.Length; i++)
            {
                var num = int.Parse(nums[i]) - 1;
                buildingStr.Append(lines[1][num]);
            }
            return buildingStr.ToString();
        }
        public static string SolveChainSteganography(string[] lines)
        {
            var firstline = lines[0].Split(new[] { '(', ')',' ' }, StringSplitOptions.RemoveEmptyEntries);
            var allcombs = new List<int[]>();
            var rightnums = new List<int>();
            var allnums = new List<int>();
            foreach (var el in firstline)
            {
                var mas = el.Split(',');
                var k1 = int.Parse(mas[0]);
                var k2 = int.Parse(mas[1]);
                allcombs.Add(new int[] { k2, k1 });
                if (k2 == 0)
                {
                    rightnums.Add(k2);
                    rightnums.Add(k1);
                }
                if (k1 == 0)
                    throw new Exception("new zero variant");
                if (!allnums.Contains(k1))
                    allnums.Add(k1);
                if (!allnums.Contains(k2))
                    allnums.Add(k2);
            }
            allnums.Sort();
            var k = 1;
            for (var i = 0; i < allnums.Count - 2; i++)
            {
                foreach (var list in allcombs)
                {
                    if (list[0] == rightnums[k] && !rightnums.Contains(list[1]))
                        rightnums.Add(list[1]);
                }
                k++;
            }
            var buidingStr = new StringBuilder();
            for (var i = 1; i < rightnums.Count; i++)
                buidingStr.Append(lines[1][rightnums[i] - 1]);
            return buidingStr.ToString();
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
