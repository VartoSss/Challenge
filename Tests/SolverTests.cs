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
    [TestCase("7.3999999999999995*x + (-11.1)", false)]
    [TestCase("10.5*x^2 + (-0.9)*x + 9.2", true)]
    [TestCase("6.3*x^2 + 5.3999999999999995*x + (-8)", false)]
    [TestCase("0*x + 1", true)]
    [TestCase("(-27.3)*x^3 + 4.3999999999999995*x^2 + 26.900000000000002*x + 2.8000000000000003", false)]
    [TestCase("20.5*x^5 + (-5.3)*x^4 + 32.300000000000004*x^3 + (-11.5)*x^2 + 5.6*x + 1.1", false)]
    [TestCase("2.7*x^5 + (-77)*x^4 + (-72.69999999999999)*x^3 + 60.9*x^2 + 34.6*x + 14.6", false)]
    [TestCase("0.4*x^4 + (-0.82)*x^3 + 1.53*x^2 + (-0.86)*x + 0.8", true)]
    [TestCase("(-1.3)*x^3 + 2.1*x^2 + 1.6*x + 0.9", false)]
    public void SolvePolynomial(string task, bool noRoots)
    {
        var answer = PolynomialRoot.SolvePolynom(task);
        if ((answer == "no roots") || (noRoots))
        {
            Assert.AreEqual(noRoots, (answer == "no roots"));
            return;
        }
        var doubleAnswer = double.Parse(answer.Replace('.', ','));
        var polynomResult = PolynomialRoot.CalculatePolynom(doubleAnswer, PolynomialRoot.GetDoubleMultipliers(task));
        Assert.Less(polynomResult, 1e-8);
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
    [TestCase("((10-1)*(7%13-14))+((0+14/13)-(9+3)+(3/7))*((6+2+8-3)/9+(8+12))%12", "-66")]
    [TestCase("((4*8-2)*(11+11+1))*((7/9+1+6)-(12/11-2%6)-(4/5))/10", "552")]
    [TestCase("((CXVII*LIV-DCCLXVI-XLV)/DCCCLXXXIV)+((DXXIX+CMXXXIX/CXVIII)-(CCCLI+DCXXXI*CXCI-DCLV))", "-119675")]
    [TestCase("((117*54-776-45)/884)+((529+939/118)-(351+631*191-655))", "-119675")]
    [TestCase("((CMXII+CCCX)*(CXCVII+CMXVI+DCXXVII-DLXXII)/CDXXXVII)*((DCLXXXVIII*CLXXXIII*CCLXXXI+CXCIX)*(CCLXXVIII*DCCCXCI*DCXI)+(DCVIII*DLXV%DLXXVIII)/CCXLV)+((XLIII-CMXLIII/MXVI)+(MCL-DCLIII)+(MCCXXX+DCLXXIII))*((MCXVIII+DCCLXII*CMXVI)/XX*(DCXI+CCXIX))", "17487518343114205954")]
    [TestCase("((60+0)%6+(16*sum(27)(49)-15))+((max(8)(27)*65/38-4)-(22-20*32-21)-(20+right(28)(30))-(min(18)(62)-28))", "11")]
    public static void MathTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, MathSolver.Solve(task));
    }
}

public class MathPostfixTest
{
    [TestCase("((60+0)%6+(16*sum(27)(49)-15))", "XD")]
    public static void PostfixTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, PostfixBuilder.BuildPostfixExpression(task));
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
    [TestCase("#Caesar's code=1#hpjohaupaljmmazpvaupojhiuarvjssfmmatobqqfeaijtagjohfst#", "going to kill you tonight quirrell snapped his fingers")]
    [TestCase("#prime multiplicator=8419 formula: (multiplicator * (charIndex + 1)) % (|ABC| + 1) - 1#dc4rnedc4rnernqeclqe7e c0062rne4nrrevx722n0veq ne07q#", "goyle goyle let out a horrible yell scabbers the rat")]
    [TestCase("#Vigenere's code=6fa85rlrtike#6sd7i 4qapodmyoj9qmrvsjmheiplq05vsox5fn 4r3q11jhci#", "and put the stone back in its pocket and as it did")]
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
    [TestCase(@"-992 & 6 & 8 & -6 & 2 & -6 & -2 & 9 \\ 0 & 9002 & -5 & -5 & 5 & -7 & -3 & -9 \\ 7 & -6 & -6999 & -7 & 8 & -5 & -3 & -3 \\ -9 & 9 & -5 & -8008 & 5 & 0 & -1 & -9 \\ 8 & 5 & 8 & 7 & -1003 & 9 & 0 & 9 \\ -6 & 1 & 7 & -9 & -8 & 4000 & 7 & 7 \\ 9 & 1 & -6 & -2 & 0 & -2 & 3995 & 9 \\ -9 & 5 & -2 & -8 & -1 & -1 & 6 & 7", "55444043382113982471923394")]
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
    [TestCase("[H] [He] [B] [C] [N]\r\nhekhllo", "hello")]
    [TestCase("[He] [Li] [O] [F] [Ne]\r\nktilfdamon", "timon")]
    [TestCase("(21,20) (20,107) (83,21) (107,60) (60,97) (97,16) (49,0) (8,49) (16,15) (15,8)\r\nthe school must already be here but professor mcgonagall showed the first years into a small empty chamber off the", "got to eat")]
    [TestCase("(65,32) (36,99) (21,56) (99,63) (11,30) (30,28) (32,21) (63,65) (56,11) (28,0)\r\nscreamed for he had seen not only himself in the mirror but a whole crowd of people standing right behind him but the", "too slow i")]
    [TestCase("XV\r\nprune said harry had been trying find how could see\r\nsleeping bag bertie bott's every flavor beans drooble's best he\r\nfabulous jewels very good bye norbert had been trying find\r\nshuddered don't know who was going be able get past\r\nmodern magical herbs fungi by his head boy who was\r\nelastic band no said harry had been trying find how\r\nasleep almost forgotten all right said harry had been trying\r\nboarded cracks around his head boy who was going be\r\npages muttering herself before he was going be able get\r\ncauldrons all right said harry had been trying find how\r\nkitchens dudley's gang had been trying find how could see\r\nexchange mystified looks like this is it was going be\r\n'n my dear professor mcgonagall was going be able get\r\nfletchley justin hufflepuff said harry had been trying find how\r\nscurrying around his head boy who was going be able\r\nserpent covered blood his head boy who was going be\r\nshutting door open door open door open door open door\r\ncomforting harry had been trying find how could see you", "rest of gryffindor")]
    public static void SteganographyTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Steganography.SolveSteganography(task));
    }
}


[TestFixture]
public class InverseMatrixTests
{
    [TestCase(@"-6 & 0 & 1 \\ -1 & -6 & -6 \\ -2 & -7 & -8", "0")]
    [TestCase(@"-1716 & -1788 & 1100 \\ 1248 & 1416 & -920 \\ 2088 & 2312 & -1480", "unsolvable")]
    public void InverseMatrixTest(string matrix, string expectedInverseMatrix)
    {
        var inversedMatrix = InverseMatrix.CalculateInverseMatrix(matrix);
        Assert.AreEqual(expectedInverseMatrix, inversedMatrix);
    }
}
