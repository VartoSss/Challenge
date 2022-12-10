using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class StatisticsTest
{
    [TestCase("firstmostfrequent|6 4 5 6 0 9 1", "6")]
    [TestCase("firstmostfrequent|55 4 55 6 55 3 17", "55")]
    [TestCase("increment.increment.decrement.decrement|1 1 1 1 1", "1 1 1 1 1")]
    [TestCase("increment.decrement.decrement|17 3 18 7 6", "16 2 17 6 5")]
    [TestCase("sum.increment.increment.decrement.decrement|0 1 2 3 4", "10")]
    [TestCase("min.increment.increment.decrement.increment.increment|-1 1 2 3 4", "2")]
    [TestCase("max.increment.decrement.decrement.decrement|-19 -17 -12 -6 -5", "-7")]
    [TestCase("sum|5 5 5 5 5 5", "30")]
    [TestCase("double.double.take(11).increment.increment.double.decrement.double.take(25).double.decrement.take(18).increment.increment.double.increment.double.increment.decrement.take(15).double.skip(1).decrement.increment.decrement|47 54 75 34 36 65 19 81 52 0 45 17 38 21 36 10 44 86 32 76 70 16 39 71 37 37 51 36 93 12 18 26 6 67 83", "30")]
    [TestCase("max|33 45 75 9 14 6", "75")]
    [TestCase("increment.decrement.decrement|", "0")]
    [TestCase("sum.increment.decrement.decrement|", "0")]
    [TestCase("sum.increment.decrement.decrement.increment.increment.increment.decrement.increment.decrement.increment.decrement.increment.decrement.decrement.decrement.decrement.increment.decrement.decrement.decrement.increment.increment.decrement.increment.decrement.increment|4 58 84 65 52 13 43 99 33 82 13 52 57 66 69 54 11 63 50 61 16 12 58 15 45 20 27 61 58 85 35 19 59 35 51 87 85 92 37 35 89 8 45 25 1 33 9 87 30", "2190")]
    [TestCase("sum.increment.double|2 7 18 9 5", "87")]
    [TestCase("#Caesar's code=-20#abc= %()*+-./0123456789abcdeiklmnoprstu|#35.e3+*19lae(05 -)e3+*19lae(05 -)e*/%2).)/4e(05 -)e()%2).)/4e()%2).)/4e()%2).)/4e(05 -)e4|+)9mlae*/%2).)/4e4|+)9msae()%2).)/4e3+*19mae*/%2).)/4e(05 -)e4|+)9muae*/%2).)/4e3+*19lae4|+)9lpae*/%2).)/4e4|+)9mua6mtcoocmrbos7ul7mu7otinrioocop8l7puimtcpnimubscln7pscmkcomcnlctcmm7olipocmsiuclk7lmdltiordludopbom7oriprcmmcnl8ou7oldppinp7r8lu7rm7rs7st7rilpcnu7nndplinbmpbu7ps7pscorindpmdmpcos7tt7rn7lcmpcpu7us7pdnrimmbripkdmk7nncmrioocos7rp7um7tt7ptdlndpncmocom7on7st7lpcorbnu7ms7lu8mr7ncpodk7os7ptcntill7um#", "75")]
    [TestCase("decrement.increment.take(26).skip(2).skip(2).double.take(17).increment.take(23).decrement.double.double.take(19).decrement.decrement.double.skip(2).decrement.double.take(12)|99 95 31 85 38 18 42 71 30 67 97 45 58 41 34 55 3 85 94 69 63 24 53 99 11 72 31 81 98 76 14 18 60 62 98 54 15 56 56 69 35 34 91", "")]
    [TestCase("sum.decrement.take(10).decrement.double.take(22).decrement.double.take(27).take(18).take(11).increment.double.increment.decrement.decrement.increment.take(14).decrement.take(10).increment.double.double.double.skip(0).double.double.double.take(13).decrement.decrement|20 79 13+58*15*37+1*18 3*45-15*43 59+17-26+16+19 68 76 41*38 9+7+57*25*0-4 98 22%16-56/15 58 11/46 51 5 12*35 54 39*33*9 5%31*47 29+11*40*35%19 31+30*48 37+59*27/23+43%42 14 25*20-6+1*39-51 12+19+28*12 32+50+10+45 38 21 38+55%38%19*16/6 52 32+24 74 75 31-32/31 10 61 15", "87")]
    public static void StatisticsTests(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Statistics.SolveStatistics(task));
    }
}
