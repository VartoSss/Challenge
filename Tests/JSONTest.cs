using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class JSONTest
{
    [TestCase(@"{""disacknowledgement"":""85"",""allelism"":""-46"",""radiata"":""74"",""commatic"":""-81""}", "32")]
    [TestCase(@"{""orbicle"":""12"",""exceptio"":""83"",""sufficientness"":""39"",""sizar"":""-61"",""allotypies"":""3"",""echeloned"":{""oropharynxes"":""59"",""pattinsonize"":""-9"",""mormondom"":""-67"",""unsalness"":""-21"",""plethysmographic"":""46"",""unlengthened"":""91""},""gorgeously"":{""unseething"":""-64"",""kohlrabies"":""83"",""inwalling"":""-73"",""aversion"":""87"",""approbativeness"":""2"",""pragmatizer"":""38""},""supracondyloid"":{""scowed"":""-98"",""antichrist"":""62"",""patterer"":""-29"",""tercelet"":""4"",""pellety"":""-57"",""bloodthirstiness"":""44""},""stonewaller"":{""marvin"":""66"",""ovisaclike"":""55"",""fleuretty"":""-98"",""metronomically"":""-13""}}", "184")]
    public static void JSONTests(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, json.SolveCommonJSON(task));
    }
}
