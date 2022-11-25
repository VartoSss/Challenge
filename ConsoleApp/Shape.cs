using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;

public class Shape
{
    public static string ShapeSolver(string task)
    {
        var taskParts = task.Split('|');
        var coordinatesToSplit = taskParts[1];
        var stringCoordinates = coordinatesToSplit.Split(new char[] { '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var cordsList = new List<int[]>();

        foreach (var pair in stringCoordinates)
        {
            var pairElements = pair.Split(',');
            var firstElement = int.Parse(pairElements[0]);
            var secondElement = int.Parse(pairElements[1]);
            var pairArray = new[] { firstElement, secondElement };
            cordsList.Add(pairArray);
        }

        var yDictionary = new Dictionary<int, List<int>>(); // y -> <x1, x2, x3, ..., xn>
        var xDictionary = new Dictionary<int, List<int>>();

        foreach (var pair in cordsList)
        {
            var x = pair[0];
            var y = pair[1];
            if (!yDictionary.ContainsKey(y))
                yDictionary.Add(y, new List<int>());
            yDictionary[y].Add(x);
            if (!xDictionary.ContainsKey(x))
                xDictionary.Add(x, new List<int>());
            xDictionary[x].Add(y);
        }

        var yValues = yDictionary.Keys.ToArray();
        Array.Sort(yValues);

        var xValues = xDictionary.Keys.ToArray();
        Array.Sort(xValues);

        var figureSquare = cordsList.Count;
        var figurePerimeter = 0;

        foreach (var pair in cordsList)
        {
            var x = pair[0];
            var y = pair[1];
            if (yDictionary[y].Contains(x + 1) && yDictionary[y].Contains(x - 1) && xDictionary[x].Contains(y + 1) && xDictionary[x].Contains(y - 1))
                continue;
            else
                figurePerimeter++;
        }

        if (Math.Pow(figurePerimeter / 4 + 1, 2) == figureSquare)
            return "square";
        else if (Math.Ceiling(Math.Pow(figurePerimeter / 3 + 1, 2) * Math.Sqrt(3) / 4) == figureSquare)
            return "equilateraltriangle";
        else if (Math.Pow(Math.Floor(figurePerimeter / (2 * Math.PI)), 2) == Math.Floor(figureSquare / Math.PI))
            return "circle";
        else
            throw new Exception("new figure type in shape");
    }
}
