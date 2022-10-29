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


    [TestFixture]
    public class PolynomialTests
    {
        [TestCase("7.3999999999999995*x + (-11.1)", "1.5")]
        [TestCase("10.5*x^2 + (-0.9)*x + 9.2", "no roots")]
        [TestCase("6.3*x^2 + 5.3999999999999995*x + (-8)", "-1.6341894191592536")]
        [TestCase("0*x + 1", "no roots")]
        public void SolvePolynomial(string task, string actual)
        {
            Assert.AreEqual(actual, Solver.SolvePolynom(task));
        }
    }

    


    [TearDown]
    public void Teardown()
    {
        // Разборка тестового окружения
        // Действия, которые будут выполнены после каждого теста
    }
}