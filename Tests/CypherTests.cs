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
    [TestCase("#a first longest word of the message=holiday#gcndhsmmnrdgcnedcogndyosdcl ndnrdldfootdco68tlydh18t#", "the summer then hope you have er a good holiday said")]
    [TestCase("#reversed#yag ma i#", "i am gay")]
    [TestCase("#reversed#kcid s'elddir mot#", "tom riddle's dick")]
    [TestCase("#reversed#uuuis uuuis uuuis  uuuis#", "siuuu  siuuu siuuu siuuu")]
    [TestCase("#Caesar's code=-22#3u u7pwu9p43up9xu8upau7up9xupr4408ps439qy3y3wp54au7v'1#", "never get one these were the books containing powerful")]
    [TestCase("#Caesar's code=-9#j7ej723j28fi2pfl2di2gfkk7i2 2k'fl9'k29ip88 e6fi2d73ek#", "sense as for you mr potter i thought gryffindor meant")]
    [TestCase("#Caesar's code=1#hpjohaupaljmmazpvaupojhiuarvjssfmmatobqqfeaijtagjohfst#", "going to kill you tonight quirrell snapped his fingers")]
    [TestCase("#prime multiplicator=8419 formula: (multiplicator * (charIndex + 1)) % (|ABC| + 1) - 1#dc4rnedc4rnernqeclqe7e c0062rne4nrrevx722n0veq ne07q#", "goyle goyle let out a horrible yell scabbers the rat")]
    [TestCase("#Vigenere's code=6fa85rlrtike#6sd7i 4qapodmyoj9qmrvsjmheiplq05vsox5fn 4r3q11jhci#", "and put the stone back in its pocket and as it did")]
    [TestCase(@"#Caesar's code=-2#abc= -beghilmnoprstuz|#proglb|lsi -out-omznhspz-gber#", "1")]
    [TestCase("#Caesar's code=-11#abc=()*+-12568ahimt|#*|+(-1m)8m261hi8h)6ht)251at8hm2#", "2")]
    [TestCase("#Caesar's code=-9#abc=-begimnrstux|#|-xsuriubtmnxg|se#", "3")]
    [TestCase("#Caesar's code=-2#abc=+-13679ahmt|#a7h9m+1t-3t6+|36#", "4")]
    [TestCase(@"#Caesar's code=-6#abc= -begimnorstuw|#gie|-ws-m tueoinbri| ugr-|-u#", "5")]
    [TestCase(@"#Caesar's code=2#abc= -bceghimnrstu|#u|tnsics reht-hnim|b|mtngh#", "6")]
    [TestCase(@"#Caesar's code=12#abc=-beghimnrstu|#rsnhme|mti-bnubhegs#", "7")]
    [TestCase(@"#Caesar's code=16#abc= ()*+-.0123456789^ailmnoprtxy|#32.7120-+.m42258^mpxyxn(xai6*|9l9^mtro)n|toooooooooo|ai6*y9l9 (yyntx))))))))))i6*x9l9^mrxt(ny)oooooooooo|ai6*t9l9^mr)onoxoooooooooopai6*r9l9xo n|i69l9x)nr#", "8")]
    [TestCase(@"#Caesar's code=5#abc=()*+-12356789ahimt|#*|+(-18h)6i)3758i)2318i)57a)58m)57t261h69251t)37h)68h2#", "9")]
    [TestCase(@"#Caesar's code=-2#abc= ()*+-.0123456789^ailmnoprtxy|#nmatlmi^9a*ommpx061.0-1-+434-----1(r82y)y.7475255+0626---.(r81y)y|*12-524.0+3010 (r80y)y|*05-7315.+-21477773 (ry)y|*0--17-0+-724777776 #", "10")]
    [TestCase(@"#Caesar's code=-2#abc= &-012345789\adeimnrt|#\anamedi9inr 7-t|t -3t|t 15t88t4-t|t27t|t0t88t 33t|t 4&t|t74#", "11")]
    [TestCase(@"#Caesar's code=19#abc= &-0245679\adeimnrt|#adrdniem\mrt&57| |0-|99|62| |74#", "12")]
    [TestCase("#Caesar's code=9#abc=-begimnorstu|#mni-e|seobtuirgeu#", "13")]
    [TestCase(@"#Caesar's code=-7#abc= &-012345789\adeimnrt|#45a5\87939ad||eiem&teiem &e22e  eie0-eiene22emr eiemrn eiemr1#", "14")]
    //[TestCase("", "15")]
    //[TestCase("", "16")]
    //[TestCase("", "17")]
    
    
    public static void CypherTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Cypher.SolveCypher(task));
    }
}
