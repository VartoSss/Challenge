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

        var dictionaryY = new Dictionary<int, List<int>>(); // y -> <x1, x2, x3, ..., xn>
        var dictionaryX = new Dictionary<int, List<int>>(); // x -> <y1, y2, y3, ..., yn>

        foreach (var pair in cordsList)
        {
            var x = pair[0];
            var y = pair[1];
            if (!dictionaryY.ContainsKey(y))
                dictionaryY.Add(y, new List<int>());
            dictionaryY[y].Add(x);
            if (!dictionaryX.ContainsKey(x))
                dictionaryX.Add(x, new List<int>());
            dictionaryX[x].Add(y);
        }

        var yValues = dictionaryY.Keys.ToArray();
        var xValues = dictionaryX.Keys.ToArray();
        Array.Sort(yValues);
        Array.Sort(xValues);

        var minY = yValues[0];
        var maxY = yValues.Last();
        var medianY = yValues[yValues.Length / 2];

        var minX = xValues[0];
        var maxX = xValues.Last();
        var medianX = xValues[xValues.Length / 2];

        var isLikeCircle = dictionaryY[minY].Count == dictionaryY[maxY].Count && dictionaryY[medianY].Count > dictionaryY[maxY].Count;

        var isLikeSquare = dictionaryY[maxY].Count == dictionaryY[minY].Count && dictionaryY[minY].Count == dictionaryY[maxY].Count;

        var isTriangle = (dictionaryY[minY].Count < dictionaryY[medianY].Count && dictionaryY[medianY].Count < dictionaryY[maxY].Count) ||
            (dictionaryY[minY].Count > dictionaryY[medianY].Count && dictionaryY[medianY].Count > dictionaryY[maxY].Count) ||
            (dictionaryX[minX].Count < dictionaryX[medianX].Count && dictionaryX[medianX].Count < dictionaryX[maxX].Count) ||
            (dictionaryX[minX].Count > dictionaryX[medianX].Count && dictionaryX[medianX].Count > dictionaryX[maxX].Count);

        if (isLikeCircle)
        {
            var isCircle = isLikeCircle && dictionaryY[medianY].Count == dictionaryX[medianX].Count;
            if (isCircle)
                return "circle";
            else
                throw new Exception("Shape got harder");
        }
        else if (isLikeSquare)
        {
            var isSquare = isLikeSquare && dictionaryY[minY].Count == dictionaryX[minX].Count;
            if (isSquare)
                return "square";
            else
                throw new Exception("Shape got harder");
        }
        else if (isTriangle)
            return "equilateraltriangle";
        else
            throw new Exception("Shape got harder");
    }
}
