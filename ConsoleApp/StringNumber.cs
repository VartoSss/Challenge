using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;

public class StringNumber
{
    public static string StringNumberSolver(string task)
    {
        var answerString = new StringBuilder();

        var wordsToSplit = new Dictionary<string, BigInteger[]>()
        { 
            { "quadrillion", new[] { 0, (BigInteger)Math.Pow(10, 15) } },
            { "trillion", new[] { 0, (BigInteger)Math.Pow(10, 12) } },
            { "billion", new[] { 0, (BigInteger)Math.Pow(10, 9) } },
            { "million", new[] { 0, (BigInteger)Math.Pow(10, 6) } },
            { "thousand", new[] { 0, (BigInteger)1000 } }
        };

        var powersOfTen = wordsToSplit.Keys.ToArray();
        foreach (var power in powersOfTen)
        {
            if (task.Contains(power))
                wordsToSplit[power][0] = 1;
        }

        var numberParts = task.Split(powersOfTen, StringSplitOptions.RemoveEmptyEntries);
        var number = new List<string>();

        foreach (var part in numberParts)
            number.Add(ConvertNumber(part));

        for (var i = 0; i < powersOfTen.Length; i++)
        {
            var power = powersOfTen[i];
            if (wordsToSplit[power][0] == 1)
            {
                var convertedNumber = number.First();
                number.RemoveAt(0);
                var calculatedNumber = (BigInteger.Parse(convertedNumber) * wordsToSplit[power][1]).ToString();
                answerString.Append(calculatedNumber);
            }
            else
                answerString.Append("000");
        }
        return answerString.ToString();
    }

    public static string ConvertNumber(string number)
    {
        var answer = new StringBuilder();

        var digits = number.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (digits.Length == 1)
            answer.Append(ParseDoubleDigitNumber(number));

        else if (digits.Length == 2)
        {
            var hundreds = ParseDoubleDigitNumber(digits[0]);
            var result = int.Parse(hundreds) * 100;
            answer.Append(result.ToString());
        }

        else
        {
            var hundreds = ParseDoubleDigitNumber(digits[0]);
            var preResult = int.Parse(hundreds) * 100;
            var numberDD = int.Parse(ParseDoubleDigitNumber(digits[2]));
            var result = (preResult + numberDD).ToString();
            answer.Append(result);
        }

        return answer.ToString();
    }

    public static string ParseDoubleDigitNumber(string numberDD)
    {
        var answer = new StringBuilder();

        var values = new Dictionary<string, int>()
        {
            { "one", 1 }, { "two", 2 }, { "three", 3 },
            { "four", 4 }, { "five", 5 }, { "six", 6 },
            { "seven", 7 }, { "eight", 8 }, { "nine", 9 },
            { "ten", 10 }, { "eleven", 11 }, { "twelve", 12 },
            { "thirteen", 13 }, { "fourteen", 14 }, { "fifteen", 15 },
            { "sixteen", 16 }, { "seventeen", 17 }, { "eighteen", 18 },
            { "nineteen", 19 }, { "twenty", 20 }, { "thirty", 30 },
            { "fourty", 40 }, { "forty", 40 }, { "fifty", 50 },
            { "sixty", 60 }, { "seventy", 70 }, { "eighty", 80 },
            { "ninety", 90 }
        };

        var digits = numberDD.Split('-', StringSplitOptions.RemoveEmptyEntries);
        if (digits.Length == 1)
        {
            var result = values[digits[0]].ToString();
            answer.Append(result);
        }
        else
        {
            var result = (values[digits[0]] + values[digits[1]]).ToString();
            answer.Append(result);
        }

        return answer.ToString();
    }
}
