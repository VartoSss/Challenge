using Challenge.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data;
using System.Text;

namespace ConsoleApp;

/*
 * This Solution was created by:
 * @o_0bebrik
 *   gh: @balbesi4
 * @Ghost_flick 
 *   gh: @ghost-flick
 * @snkrtree 
 *   gh: @localhoster23
 * @VartoSss 
 *   gh: @VartoSss
*/


public class Solver
{
    public static string Solve(TaskResponse taskResponse)
    {
        var question = taskResponse.Question;
        if (taskResponse.TypeId == "starter")
            return SolveStarter(question);
        else if (taskResponse.TypeId == "cypher")
            return SolveCypher(question);
        else if (taskResponse.TypeId == "determinant")
            return Determinant.DeterminantSolver(question);
        else if (taskResponse.TypeId == "moment")
            return Moment.SolveMoment(question);
        else if (taskResponse.TypeId == "math")
            return SolveMath(question);
        else if (taskResponse.TypeId == "steganography")
            return Steganography.SolveSteganography(question);
        else if (taskResponse.TypeId == "polynomial-root")
            return PolynomialRoot.SolvePolynom(question);
        else
            throw new Exception("I don't know how to solve this task type yet");
    }

    //Starter
    public static string SolveStarter(string question)
    {
        var taskFormulation = question;
        return "42";
    }

    //Cypher
    public static string SolveCypher(string question)
    {
        var task = question;
        var splittedTask = task.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
        if (splittedTask[0] == "reversed" && splittedTask.Length == 2)
        {
            var result = new StringBuilder();
            for (int i = splittedTask[1].Length - 1; i >= 0; i--)
                result.Append(splittedTask[1][i]);
            return result.ToString();
        }
        else
            throw new Exception("AAAAAA TASK GOT HARDER");
    }


    //Math
    public static string SolveMath(string question)
    {
        var resultFormula = GetValue(question);
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
