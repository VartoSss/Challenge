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
        BigInteger answer = 0;

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
        var number = new List<BigInteger>();
        
        //считаем запарсенные части
        foreach (var part in numberParts)
            number.Add(ConvertNumber(part));

        //используемые степени
        var necessaryPowers = new List<string>();
        var index = 0;
        while (index != powersOfTen.Length && wordsToSplit[powersOfTen[index]][0] != 1)
            index++;

        for (var i = index; i < powersOfTen.Length; i++)
            necessaryPowers.Add(powersOfTen[i]);
        
        //собираем число
        for (var i = 0; i < necessaryPowers.Count; i++)
        {
            var power = necessaryPowers[i];
            if (wordsToSplit[power][0] == 0)
                continue;
                //stringAnswer.Append("000");
            else
            {
                var result = wordsToSplit[power][1] * number.First();
                answer += result;
                number.RemoveAt(0);
            }
        }

        if (number.Count > 0)
            answer += number[0];

        return answer.ToString();
    }

    public static BigInteger ConvertNumber(string number)
    {
        var answer = new StringBuilder();

        var digits = number.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (digits.Length == 1)
            answer.Append(ParseDoubleDigitNumber(number));

        else if (digits.Length == 2)
        {
            var hundreds = ParseDoubleDigitNumber(digits[0]);
            var result = hundreds * 100;
            answer.Append(result.ToString());
        }

        else
        {
            var hundreds = ParseDoubleDigitNumber(digits[0]);
            var preResult = hundreds * 100;
            var numberDD = ParseDoubleDigitNumber(digits[2]);
            var result = (preResult + numberDD).ToString();
            answer.Append(result);
        }

        var returnable = BigInteger.Parse(answer.ToString());
        return returnable;
    }

    public static BigInteger ParseDoubleDigitNumber(string numberDD)
    {
        BigInteger answer = 0;

        var values = new Dictionary<string, int>()
        {
            { "zero", 0 }, { "one", 1 }, { "two", 2 }, { "three", 3 },
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

        var digits = numberDD.Split(new[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (digits.Length == 1)
        {
            var result = values[digits[0]];
            answer += result;
        }
        else
        {
            var result = values[digits[0]] + values[digits[1]];
            answer += result;
        }

        return answer;
    }
}
