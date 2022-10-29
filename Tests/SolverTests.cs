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

    public void Solve_Returns42_Everytime()
    {
        var expected = "42";
        TaskResponse task = null;

        var actual = Solver.Solve(task);

        Assert.AreEqual(expected, actual);
    }
    
    public class DeterminantTests
    {
        [TestCase(@"-13 & -20 & -19 \\ 18 & -1 & 17 \\ 5 & -16 & 21", "7974")]
        [TestCase(@"-12 & -5 & -9 \\ 10 & -9 & 9 \\ 8 & -12 & -1", "-1382")]
        [TestCase(@"0 & 3 & -1 \\ 1 & 4 & 2 \\ 2 & 5 & 3", "6")]
        //[TestCase(@"1 & 0 & 2 & -1 \\ 0 & 0 & 1 & 4 \\ -3 & 0 & 0 & 2 \\ 6 & -3 & -1 & 0", "78")]
        public void SolveDeterminant(string task, string actual)
        {
            Assert.AreEqual(actual, Solver.DeterminantSolver(task)); 
        }
    }

    [TearDown]
    public void Teardown()
    {
        // Разборка тестового окружения
        // Действия, которые будут выполнены после каждого теста
    }
}
