using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

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
    [TestCase("((60+0)%6+(16*sum(27)(49)-15))+((max(8)(27)*65/38-4)-(22-20*32-21)-(20+right(28)(30))-(min(18)(62)-28))", "1842")]
    [TestCase("47-5+7+34 \"46 + 30 - 4 - 35\" 42+7%26-17 \"6 - 42\"", "83 37 32 -36")]
    [TestCase("47-5+7+34 \"46 + 30 - 4 - 35\" 42+7%26-17 \"6 - 42\" \"30 * 49 + 48 - 8 + 47\" \"32 + 45 * 49\" \"26 % 2 + 15 - 26\" \"2 - 7 - 44 + 20 + 32\" 35/17-32", "83 37 32 -36 1557 2237 -11 3 -30")]
    [TestCase("mul(25)(sum(15)(12))", "675")]
    [TestCase("((69%13)*(38*right(45)(14)+8-68)/46)+((6/23+0)+(33+24-sum(29)(17)/11))+((53+5+sum(15)(19)-left(4)(5))-(60+mul(mul(18)(23))(10)-max(left(1)(55))(67)+sum(mul(10)(9))(max(8)(34))))*((61+min(22)(22)+3)+(41*min(sum(57)(70))(36)/48)/37*(mul(1)(4)+20*sum(69)(sum(60)(63))+58))", "-358440")]
    public static void MathTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, MathSolver.Solve(task));
    }
}
