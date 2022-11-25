using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

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
