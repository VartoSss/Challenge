using NUnit.Framework;
using ConsoleApp;
using Challenge.DataContracts;

namespace Tests;


[TestFixture]
public class StarterTests
{
    [TestCase("suiiiiii", "42")]
    public static void StarterTest(string task, string expectedResult)
    {
        Assert.AreEqual("42", Starter.SolveStarter(task));
    }
}