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
    [TestCase("10%8*6*6/4", "18")]
    [TestCase("2*(2+2)", "8")]
    [TestCase("((7+5+3*9)-(7%3))/3", "12")]
    public static void MathTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Maths.SolveWithBrackets(task));
    }
}

[TestFixture]
public class CypherTests
{
    [TestCase("#reversed#enigne eht dekcik dna#", "and kicked the engine")]
    [TestCase("#reversed#yag ma i#", "i am gay")]
    [TestCase("#reversed#kcid s'elddir mot#", "tom riddle's dick")]
    [TestCase("#reversed#uuuis uuuis uuuis  uuuis#", "siuuu  siuuu siuuu siuuu")]
    [TestCase("#Caesar's code=-22#3u u7pwu9p43up9xu8upau7up9xupr4408ps439qy3y3wp54au7v'1#", "never get one these were the books containing powerful")]
    [TestCase("#Caesar's code=-9#j7ej723j28fi2pfl2di2gfkk7i2 2k'fl9'k29ip88 e6fi2d73ek#", "sense as for you mr potter i thought gryffindor meant")]
    [TestCase("#Caesar's code=1#hpjohaupaljmmazpvaupojhiuarvjssfmmatobqqfeaijtagjohfst#", "")]
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
    [TestCase(@"6 & 3 & 8 & -4 \\ 5 & 6 & 4 & 2 \\ 0 & 3 & 4 & 2 \\ 4 & 1 & -4 & 6", "800")]
    [TestCase(@"2 & 3 & 0 & 5 \\ 4 & -3 & -1 & 1 \\ 2 & 5 & 1 & 3 \\ 2 & 7 & 2 & -2", "42")]
    [TestCase(@"4 & 1 & 1 & 2 & 1 \\ 1 & 2 & -1 & 1 & 1\\ 3 & 1 & 1 & 1 & 1 \\ 2 & 1 & 1 & 4 & 1 \\ 2 & -1 & 1 & 1 & 5", "64")]
    [TestCase(@"-15 & 4 \\ 3 & -2", "18")]
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
    [TestCase("XXII\r\noverheard parvati patil malfoy had been trying find how could\r\nunbroken earsplitting note ron hermione had been trying find how\r\nfinch fletchley justin hufflepuff said harry had been trying find\r\nnosebleed harry had been trying find how could see you\r\nteaching harry had been trying find how could see you\r\nsmarten yourselves i don't know who was going be able\r\nexciting about it was going be able get past fluffy\r\nring trapdoor it's not going be able get past fluffy\r\nheeled buckled boots his head boy who was going be\r\nwilling let me said harry had been trying find how\r\ncanary yellow circus tent still there was going be able", "i need that")]
    [TestCase("XV\r\nprune said harry had been trying find how could see\r\nsleeping bag bertie bott's every flavor beans drooble's best he\r\nfabulous jewels very good bye norbert had been trying find\r\nshuddered don't know who was going be able get past\r\nmodern magical herbs fungi by his head boy who was\r\nelastic band no said harry had been trying find how\r\nasleep almost forgotten all right said harry had been trying\r\nboarded cracks around his head boy who was going be\r\npages muttering herself before he was going be able get\r\ncauldrons all right said harry had been trying find how\r\nkitchens dudley's gang had been trying find how could see\r\nexchange mystified looks like this is it was going be\r\n'n my dear professor mcgonagall was going be able get\r\nfletchley justin hufflepuff said harry had been trying find how\r\nscurrying around his head boy who was going be able\r\nserpent covered blood his head boy who was going be\r\nshutting door open door open door open door open door\r\ncomforting harry had been trying find how could see you", "rest of gryffindor")]
    public static void SteganographyTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Steganography.SolveSteganography(task));
    }
}
