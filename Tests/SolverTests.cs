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
