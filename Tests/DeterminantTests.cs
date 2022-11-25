using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class DeterminantTests
{
    [TestCase(@"-13 & -20 & -19 \\ 18 & -1 & 17 \\ 5 & -16 & 21", "7974")]
    [TestCase(@"-12 & -5 & -9 \\ 10 & -9 & 9 \\ 8 & -12 & -1", "-1382")]
    [TestCase(@"0 & 3 & -1 \\ 1 & 4 & 2 \\ 2 & 5 & 3", "6")]
    [TestCase(@"6 & 3 & 8 & -4 \\ 5 & 6 & 4 & 2 \\ 0 & 3 & 4 & 2 \\ 4 & 1 & -4 & 6", "800")]
    [TestCase(@"2 & 3 & 0 & 5 \\ 4 & -3 & -1 & 1 \\ 2 & 5 & 1 & 3 \\ 2 & 7 & 2 & -2", "42")]
    [TestCase(@"4 & 1 & 1 & 2 & 1 \\ 1 & 2 & -1 & 1 & 1\\ 3 & 1 & 1 & 1 & 1 \\ 2 & 1 & 1 & 4 & 1 \\ 2 & -1 & 1 & 1 & 5", "64")]
    [TestCase(@"-15 & 4 \\ 3 & -2", "18")]
    [TestCase(@"-992 & 6 & 8 & -6 & 2 & -6 & -2 & 9 \\ 0 & 9002 & -5 & -5 & 5 & -7 & -3 & -9 \\ 7 & -6 & -6999 & -7 & 8 & -5 & -3 & -3 \\ -9 & 9 & -5 & -8008 & 5 & 0 & -1 & -9 \\ 8 & 5 & 8 & 7 & -1003 & 9 & 0 & 9 \\ -6 & 1 & 7 & -9 & -8 & 4000 & 7 & 7 \\ 9 & 1 & -6 & -2 & 0 & -2 & 3995 & 9 \\ -9 & 5 & -2 & -8 & -1 & -1 & 6 & 7", "55444043382113982471923394")]
    public void SolveDeterminant(string task, string actual)
    {
        Assert.AreEqual(actual, Determinant.DeterminantSolver(task));
    }
}