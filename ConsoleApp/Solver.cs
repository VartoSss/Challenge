using Challenge.DataContracts;
using System;
using Challenge;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data;
using System.Text;

namespace ConsoleApp;

public class Solver
{
    public static string Solve(TaskResponse taskResponse)
    {
        if (taskResponse.TypeId == "math")
            return SolveMath(taskResponse);
        else
            throw new NotImplementedException();
    }

    public static string SolveMath(TaskResponse taskResponse)
    {
        var resultFormula = GetValue(taskResponse.Question);
        var result = Convert.ToDouble(new DataTable().Compute(resultFormula, ""));

        return result.ToString();
    }
    public static string GetValue(string formula)
    {
        var signs = new List<string>(); // + и -
        foreach (var symbol in formula)
            if (symbol == '+' || symbol == '-')
                signs.Add(symbol.ToString());

        var fields = formula.Split(new[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
        var currentFormula = new StringBuilder();

        var signCounter = 0;
        foreach (var field in fields)
        {
            var isSimpleField = true;
            foreach (var symbol in field)
            {
                if (char.IsDigit(symbol)) continue;
                else
                {
                    isSimpleField = false;
                    break;
                }
            }

            if (isSimpleField) currentFormula.Append(field.ToString());
            else currentFormula.Append(CalculateHardField(field));

            if (signCounter < signs.Count)
                currentFormula.Append(signs[signCounter]);
            if (signCounter < signs.Count - 1)
                signCounter++;
        }

        if (!char.IsDigit(currentFormula[currentFormula.Length - 1]))
            return currentFormula.ToString().Substring(0, currentFormula.Length - 1);
        return currentFormula.ToString();
    }

    public static string CalculateHardField(string field)
    {
        var number1 = "";
        var number2 = "";
        var currentOperation = "";
        for (var i = 0; i < field.Length; i++)
        {
            var symbol = field[i];
            if (char.IsDigit(symbol) && string.IsNullOrEmpty(currentOperation))
                number1 += symbol;
            else if (!char.IsDigit(symbol) && string.IsNullOrEmpty(number2))
                currentOperation = symbol.ToString();
            else
            {
                while (i < field.Length && char.IsDigit(field[i]))
                {
                    number2 += field[i];
                    i++;
                }

                if (currentOperation == "%")
                {
                    var result = (int.Parse(number1) % int.Parse(number2)).ToString();
                    number1 = result;
                    number2 = "";
                }

                else if (currentOperation == "*")
                {
                    var result = (int.Parse(number1) * int.Parse(number2)).ToString();
                    number1 = result;
                    number2 = "";
                }

                else if (currentOperation == "/")
                {
                    var result = (int.Parse(number1) / int.Parse(number2)).ToString();
                    number1 = result;
                    number2 = "";
                }

                if (i < field.Length)
                    currentOperation = field[i].ToString();
            }
        }
        return number1;
    }
}