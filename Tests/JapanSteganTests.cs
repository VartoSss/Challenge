using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class JapanSteganTests
{
    [TestCase("columns:1,3;1,3;2,2;1,1,1;3,2;2,2,1;1,1;1,3,1;4,1;rows:1,1,1;5,1;1,1,2;2,6;2,1,2;5,1;1,2,2;;\r\nhard to follow my masters instructions he is a great wizard and i am weak you mean he was there in the classroom", "0")]
    public static void JapanSteganTest(string result, string expectedValue)
    {
        Assert.AreEqual(expectedValue, JapanStegan.JapanSteganSolver(result));
    }
}
