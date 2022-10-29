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
        Assert.AreEqual(expectedResult, Moment.SolveMoment(task));
    }
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
        Assert.AreEqual(actual, PolynomialRoot.SolvePolynom(task));
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
        Assert.AreEqual(expectedResult, Maths.SolveMath(task));
    }
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
        Assert.AreEqual(Cypher.SolveCypher(task), expectedResult);
    }
}

[TestFixture]
public class DeterminantTests
{
    [TestCase(@"-13 & -20 & -19 \\ 18 & -1 & 17 \\ 5 & -16 & 21", "7974")]
    [TestCase(@"-12 & -5 & -9 \\ 10 & -9 & 9 \\ 8 & -12 & -1", "-1382")]
    [TestCase(@"0 & 3 & -1 \\ 1 & 4 & 2 \\ 2 & 5 & 3", "6")]
    //[TestCase(@"1 & 0 & 2 & -1 \\ 0 & 0 & 1 & 4 \\ -3 & 0 & 0 & 2 \\ 6 & -3 & -1 & 0", "78")]
    public void SolveDeterminant(string task, string actual)
    {
        Assert.AreEqual(actual, Determinant.DeterminantSolver(task)); 
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
        Assert.AreEqual(expectedResult, Steganography.SolveSteganography(task));
    }
}
