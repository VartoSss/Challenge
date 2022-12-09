using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RandomMathTests
    {
        [TestCase("\"string-number|seven\" \"string-number|six\" \"math|86*32*6\" \"string-number|four\" \"string-number|seven\" \"string-number|eight\" \"math|((3+47-98)+(10+78+23-22)-(91+58-56/11))+((62+2)/3-(56%42))\" \"string-number|two\" \"math|26+37\" \"string-number|zero\" \"string-number|eight\" \"math|39-49-74*97\" \"string-number|nine\" \"math|((27-38*108)*(19*96)+(63*16+3*85)*(26*11/91))+((7-80)/52/53)\" \"math|40*60*108%108\" \"string-number|nine\" \"math|2+83+27+26-65\" \"math|((49/10+45/57)-(87*38-64+9)/22)+((43-55+31-96)-(16%17)+(3/10+42)+(95/81))+((27+30)+(81+5+72)*(19*93-76)-(79*88-75-85))\" \"math|((28-33+87+79)+(19/62-77)+(58+38-105%93)/34)+((21/2)+(36+90))+((25+26+8+37)*(60-105))+((90*86+82)*(19+0)+(90/34+23)-(44+69+107+100))\" \"math|((31-45+107-81)+(107%8+69)+(10+21-92-35))+((8%24-103)/80)+((58+105)+(27-6+73)+(98*86-85))-((17-88)+(8/85*93/15))\" \"string-number|nine\" \"string-number|zero\" \"math|88+90+94/101+51+6\" \"math|74*55+92\" \"math|((28+63-28+82)/37-(16+11*6-67)%35)+((55-26+86/15)*(27%28%1))*((56*85)*(89-64)/50)\"", "XD")]
        [TestCase("\"string-number|seven\" \"determinant|-15 & -5 & -12 \\\\ 9 & 2 & 2 \\\\ 6 & -9 & -2\" \"string-number|one million twenty-three\"", "\"7\" \"756\" \"1000023\"")]
        [TestCase("\"math|(7i*16i*12+8i)+(9*6*19i+8i)*(28+27i-11i)\" \"string-number|eight times three\"", "\"-17888+28960i\" \"24\"")]
        [TestCase("\"string-number|eighty-five times three cubed plus one thousand eighty-three squared\"", "\"1175184\"")]
        [TestCase("\"string-number|two cubed squared cubed\"", "\"262144\"")]
        [TestCase("\"string-number|two squared plus one\"", "\"5\"")]
        public static void RandomMathTest(string task, string expectedResult)
        {
            Assert.AreEqual(expectedResult, RandomMathSolver.SolveRandomMath(task));
        }
    }
}
