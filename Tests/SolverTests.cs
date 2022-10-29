using NUnit.Framework;
using ConsoleApp;
using Challenge.DataContracts;

namespace Tests;

public class SolverTests
{
    [SetUp]
    public void Setup()
    {
        // Подготовка тестового окружения
        // Действия, которые будут выполнены перед каждым тестом
    }

    [Test]
    public void Solve_Returns42_Everytime()
    {
        var expected = "42";
        TaskResponse task = null;

        var actual = Solver.Solve(task);

        Assert.AreEqual(expected, actual);
    }

    [TearDown]
    public void Teardown()
    {
        // Разборка тестового окружения
        // Действия, которые будут выполнены после каждого теста
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
            Assert.AreEqual(expectedResult, Solver.SolveCypher(task));
        }
    }
}
