using NUnit.Framework;
using ConsoleApp;
using Challenge.DataContracts;

namespace Tests;

[TestFixture]
public class MomentTests
{
    [TestCase("17:08:10 28.10.2022", "28 октября 17:08")]
    [TestCase("21:00:59 31.12.2022", "31 декабря 21:00")]
    [TestCase("14:35:25 28.10.2022", "28 октября 14:35")]
    [TestCase("11:00:03 17.12.1998", "17 декабря 11:00")]
    [TestCase("15:35:50 28.10.2022", "28 октября 15:35")]
    public void MomentTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Solver.SolveMoment(task));
    }


    [TestFixture]
    public class CypherTests
    {
        [TestCase("#reversed#enigne eht dekcik dna#", "and kicked the engine")]
        [TestCase("#reversed#yag ma i#", "i am gay")]
        [TestCase("#reversed#kcid s'elddir mot#", "tom riddle's dick")]
        [TestCase("#reversed#uuuis uuuis uuuis  uuuis#", "siuuu  siuuu siuuu siuuu")]
        public static void CypherTest(string task, string expectedResult)
        {
            Assert.AreEqual(Solver.SolveCypher(task), expectedResult);
        }
    }
}

[TestFixture]
public class MathTests
{
    [TestCase("2+2-1", "3")]
    [TestCase("18%5*2", "6")]
    [TestCase("23-7*3+11*2", "24")]
    [TestCase("1000-80/10*3%17", "993")]
    public static void MathTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Solver.SolveMath(task));
    }
}
