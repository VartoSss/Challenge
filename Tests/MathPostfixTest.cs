using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class MathPostfixTest
{
    [TestCase("((60+0)%6+(16*sum(27)(49)-15))", "XD")]
    public static void PostfixTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, PostfixBuilder.BuildPostfixExpression(task));
    }
}
