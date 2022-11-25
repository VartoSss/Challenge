using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class InverseMatrixTests
{
    [TestCase(@"-6 & 0 & 1 \\ -1 & -6 & -6 \\ -2 & -7 & -8", "0")]
    [TestCase(@"-1716 & -1788 & 1100 \\ 1248 & 1416 & -920 \\ 2088 & 2312 & -1480", "unsolvable")]
    public void InverseMatrixTest(string matrix, string expectedInverseMatrix)
    {
        var inversedMatrix = InverseMatrix.CalculateInverseMatrix(matrix);
        Assert.AreEqual(expectedInverseMatrix, inversedMatrix);
    }
}
