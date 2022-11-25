using System.Numerics;
using System.Text;

namespace ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;


public class InverseMatrix
{
    private static int matrixDim = 0;
    public static string CalculateInverseMatrix(string question)
    {
        if (Determinant.DeterminantSolver(question) == "0")
            return "unsolvable";
        var s = question;
        var separators = new string[] { "&", @"\\", " " };
        var strings = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var matrix = Array.ConvertAll(strings, s => double.Parse(s));
        matrixDim = (int)Math.Sqrt(matrix.Length);
        if (matrixDim == 0)
            throw new Exception();
        double[,] myMatrix = new double[matrixDim, matrixDim];
        for (int i = 0; i < matrixDim; i++)
            for (int j = 0; j < matrixDim; j++)
                myMatrix[i, j] = matrix[i * matrixDim + j];
        Random r = new Random();
        Matrix m = myMatrix;
        var result = m.Inverse();
        return MatrixToFormat(result);
    }

    private static string MatrixToFormat(Matrix result)
    {
        var helpString = string.Join(" ", result.ToString().Replace("\n", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries));
        var resultString = new StringBuilder();
        var spaceIndex = 0;
        for (var i = 0; i < helpString.Length; i++)
        {
            if (helpString[i] != ' ')
                resultString.Append(helpString[i]);
            if (helpString[i] == ' ')
            {
                spaceIndex++;
                if ((spaceIndex) % matrixDim == 0)
                    resultString.Append(@" \\ "); 
                else
                    resultString.Append(" & ");
            }
        }

        return resultString.ToString().Replace(",", ".");
    }
}
class Matrix: IEnumerable<double>
{
    double[,] data;
    public int N => data.GetLength(0);
    public int M => data.GetLength(1);
    public Matrix(int n, int m)
        => data = new double[n, m];
    public Matrix(int n, int m, Func<int, int, double> selector) : this(n, m)
        => ForEach((i, j, x) => data[i, j] = selector(i, j));
    public Matrix Row(int i)
        => new Matrix(1, M, (_, j) => data[i, j]);
    public Matrix Column(int j)
        => new Matrix(N, 1, (i, _) => data[i, j]);
    public Matrix Minor(int r, int c)
        => new Matrix(N - 1, M - 1, (i, j) => data[i < r ? i : i + 1, j < c ? j : j + 1]);
    public Matrix Transpose()
        => new Matrix(M, N, (i, j) => data[j, i]);
    public double Determinant()
        => N != M ? throw new Exception("Possible only for square matrices") :
            N == 1 ? data[0, 0] :
                    (Row(0) * new Matrix(N, 1, (i, j) => Minor(0, i).Determinant() * d(i))).Determinant();
    public override string ToString()
        => string.Concat(this.Select((x, i) => $"{x, 7 :F5}" + ((i + 1) % M == 0 ? '\n' : ' ')));
    public static Matrix operator *(Matrix a, Matrix b)
        => a.M != b.N ? throw new Exception("Wrong dimentions") : 
           a.N == 1   ? new Matrix(1, 1, (i, j) => Enumerable.Zip(a, b, (ai, bi) => ai * bi).Sum()) :
                        new Matrix(a.N, b.M, (i, j) => (a.Row(i) * b.Column(j)).Determinant());
    public Matrix Cofactor()
        => new Matrix(N, M, (i, j) => Minor(i, j).Determinant() * d(i + j));
    public Matrix Inverse()
        => N == M ? Cofactor().Transpose() / Determinant() :
            throw new Exception("Possible only for square matrices");
    public Matrix InverseLeft()
        => Transpose() * ((this * Transpose()).Inverse());
    public Matrix InverseRight()
        => (Transpose() * this).Inverse() * Transpose();
    public static Matrix operator *(double a, Matrix m)
        => new Matrix(m.N, m.M, (i, j) => a * m.data[i, j]);
    public static Matrix operator *(Matrix m, double a)
        => a * m;
    public static Matrix operator /(Matrix m, double a)
        => (1.0 / a) * m;
    public static implicit operator Matrix(double[,] a)
        => new Matrix(a.GetLength(0), a.GetLength(1), (i, j) => a[i, j]);
    public IEnumerator<double> GetEnumerator()
        => data.Cast<double>().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    private int d(int i) => i % 2 == 0 ? 1 : -1;
    public Matrix ForEach(Action<int, int, double> action)
    {
        for (int i = 0; i < N; i++)
            for (int j = 0; j < M; j++)
                action(i, j, data[i, j]);
        return this;
    }
}