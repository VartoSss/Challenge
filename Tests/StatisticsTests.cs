using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class StatisticsTest
{
    [TestCase("firstmostfrequent|6 4 5 6 0 9 1", "6")]
    [TestCase("firstmostfrequent|55 4 55 6 55 3 17", "55")]
    public static void StatisticsTests(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Statistics.SolveStatistics(task));
    }
}
