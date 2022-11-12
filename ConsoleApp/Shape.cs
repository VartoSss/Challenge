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

        var dictionary = new Dictionary<int, List<int>>(); // y -> <x1, x2, x3, ..., xn>

        foreach (var pair in cordsList)
        {
            var x = pair[0];
            var y = pair[1];
            if (!dictionary.ContainsKey(y))
                dictionary.Add(y, new List<int>());
            dictionary[y].Add(x);
        }

        var yValues = dictionary.Keys.ToArray();
        Array.Sort(yValues);

        var minY = yValues[0];
        var maxY = yValues.Last();
        var medianY = yValues[yValues.Length / 2];

        if (dictionary[minY].Count == dictionary[maxY].Count) // либо круг, либо квадрат
        {
            if (dictionary[medianY].Count > dictionary[maxY].Count)
                return "circle";
            return "square";
        }
        else
            return "equilateraltriangle";
    }
}
