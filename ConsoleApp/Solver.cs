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
            return DeterminantSolver(question);
        else if (taskResponse.TypeId == "moment")
            return SolveMoment(question);
        else if (taskResponse.TypeId == "math")
            return SolveMath(question);
        else if (taskResponse.TypeId == "steganography")
            return SolveSteganography(question);
        else if (taskResponse.TypeId == "polynomial-root")
            return SolvePolynom(question);
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

    //Determinant
    private static string DeterminantSolver(string question)
    {
        var s = question;
        var separators = new string[] { "&", @"\\", " " };
        var strings = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var matrix = Array.ConvertAll(strings, s => int.Parse(s));
        var n = (int)Math.Sqrt(matrix.Length);
        if (n > 0)
        {
            double[,] myMatrix = new double[n, n];
            //input the matrix elements
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    myMatrix[i, j] = matrix[i * 3 + j];
            return Determinant(myMatrix).ToString();
        }
        else
            throw new Exception();
    }

    //this method determines the sign of the elements
    static int SignOfElement(int i, int j)
    {
        if ((i + j) % 2 == 0)
            return 1;
        else
            return -1;
    }

    //this method determines the sub matrix corresponding to a given element
    static double[,] CreateSmallerMatrix(double[,] input, int i, int j)
    {
        int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
        double[,] output = new double[order - 1, order - 1];
        int x = 0, y = 0;
        for (int m = 0; m < order; m++, x++)
        {
            if (m != i)
            {
                y = 0;
                for (int n = 0; n < order; n++)
                {
                    if (n != j)
                    {
                        output[x, y] = input[m, n];
                        y++;
                    }
                }
            }
            else
                x--;
        }
        return output;
    }

    //this method determines the value of determinant using recursion
    static double Determinant(double[,] input)
    {
        int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
        if (order > 2)
        {
            double value = 0;
            for (int j = 0; j < order; j++)
            {
                double[,] Temp = CreateSmallerMatrix(input, 0, j);
                value = value + input[0, j] * (SignOfElement(0, j) * Determinant(Temp));
            }
            return value;
        }
        else if (order == 2)
            return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
        
        else
            return (input[0, 0]);
        
    }

    //Moment
    public static string SolveMoment(string question)
    {
        var task = question;
        var SplitTimeDate = task.Split();
        var time = SplitTimeDate[0].Split(":");
        var hour = time[0];
        var minutes = time[1];
        var date = SplitTimeDate[1].Split(".");
        var day = date[0];
        var month = date[1];
        var monthsName = new[] { "января", "февараля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
        var result = $"{day} {monthsName[int.Parse(month) - 1]} {hour}:{minutes}";
        return result;
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

    //Steganography
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

    //polynomial-root
    public static string SolvePolynom(string question)
    {
        var equation = question;
        var newEquation = "";
        for (var i = 0; i < equation.Length; i++)
        {
            if (equation[i] == '^')
                i += 1;
            else
                newEquation += equation[i];
        }
        newEquation = newEquation.Replace('.', ',');
        var separators = new string[] { "(", ")", "*", "^", "x", " ", "+" };
        var multipliers = newEquation.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        if (multipliers.Length > 3)
            throw new Exception();
        else if (multipliers.Length == 3)
        {
            var a = double.Parse(multipliers[0]);
            var b = double.Parse(multipliers[1]);
            var c = double.Parse(multipliers[2]);
            double D = Math.Pow(b, 2) - 4 * a * c;
            if (D > 0 || D == 0)
                return (((-b - Math.Sqrt(D)) / (2 * a)).ToString()).Replace(',', '.');
            else
                return "no roots";
        }
        else if (multipliers.Length == 2) // ax + b = 0
        {
            var a = double.Parse(multipliers[0]);
            var b = double.Parse(multipliers[1]);
            if (((a == 0) && (b == 0)) || (b == 0))
                return "0";
            else if (a == 0)
                return "no roots";
            else
                return (-b / a).ToString().Replace(',', '.');
        }
        else
            throw new Exception();
    }
}
