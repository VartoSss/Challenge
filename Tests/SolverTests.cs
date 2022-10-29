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
public class SteganographyTests
{
    [TestCase("V\r\nhello world\r\nno one's here\r\noh hell", "one")]
    [TestCase("IX\r\nand one more test for this peace of\r\ni don't even know what to right\r\noh i'll shape one word\r\ni think siiuuuuu won't be said by anyone because\r\nits messiiiuuuuuuu", "messi")]
    [TestCase("VIII\r\nlol lolly\r\nand again\r\nokay i pull up\r\nuuuuuiis\r\nsiiiiiiiiiuuuuuuuu\r\nwhat is it going to be\r\nahahahahahah\r\nhahahahahaha", "lipsi ha")]
    [TestCase("XIV\r\nprivet no ti prohodish mimo\r\nya spryatala ulibku\r\nmne vazhno chtobi ti uznal\r\nsecret lovimii kazhdiy ritm\r\nti mne ne beznazlichen", "putin")]
    public static void SteganographyTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Solver.SolveSteganography(task));
    }
}
