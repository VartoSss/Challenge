using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp
{
    public class Determinant
    {
        public static string DeterminantSolver(string question)
        {
            var s = question;
            var separators = new string[] { "&", @"\\", " " };
            var strings = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var matrix = Array.ConvertAll(strings, s => BigInteger.Parse(s));
            var n = (int)Math.Sqrt(matrix.Length);
            if (n > 0)
            {
                BigInteger[,] myMatrix = new BigInteger[n, n];
                //input the matrix elements
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        myMatrix[i, j] = matrix[i * n + j];
                return CalculateDeterminant(myMatrix).ToString();
            }
            else
                throw new Exception();
        }

        //this method determines the sign of the elements
        public static int SignOfElement(BigInteger i, BigInteger j)
        {
            if ((i + j) % 2 == 0)
                return 1;
            else
                return -1;
        }

        //this method determines the sub matrix corresponding to a given element
        public static BigInteger[,] CreateSmallerMatrix(BigInteger[,] input, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            BigInteger[,] output = new BigInteger[order - 1, order - 1];
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
        public static BigInteger CalculateDeterminant(BigInteger[,] input)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            if (order > 2)
            {
                BigInteger value = 0;
                for (int j = 0; j < order; j++)
                {
                    BigInteger[,] Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j) * CalculateDeterminant(Temp));
                }
                return value;
            }
            else if (order == 2)
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));

            else
                return (input[0, 0]);

        }

    }
}
