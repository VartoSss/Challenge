using System;
using Challenge.DataContracts;

namespace ConsoleApp;

public class Solver
{
    public static string Solve(TaskResponse taskResponse)
    {
        if (taskResponse.TypeId == "determinant")
        {
            return DeterminantSolver(taskResponse);
        }
        else
        {
            Environment.Exit(0);
            return null;
        }
    }

    private static string DeterminantSolver(TaskResponse taskResponse)
    {
        var s = taskResponse.Question;
        var separators = new string[] { "&", @"\\", " " };
        var strings = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var matrix = Array.ConvertAll(strings, s => int.Parse(s));
        var n = (int)Math.Sqrt(matrix.Length);
        if (n > 0)
        {
            double[,] myMatrix = new double[n, n];
            //input the matrix elements
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //Console.WriteLine("Enter element [" + (i + 1) + "]" + "[" + (j + 1) + "]: ");
                    //myMatrix[i, j] = double.Parse(Console.ReadLine().ToString());
                    myMatrix[i, j] = matrix[i * 3 + j];
                }
            }

            //Console.WriteLine("Value of the determinant is: " + Determinant(myMatrix));
            return Determinant(myMatrix).ToString();
        }
        else
            throw new Exception();
    }

    //this method determines the sign of the elements
    static int SignOfElement(int i, int j)
    {
        if ((i + j) % 2 == 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
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
            {
                x--;
            }
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
        {
            return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
        }
        else
        {
            return (input[0, 0]);
        }
    }
}
