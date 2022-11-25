using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class StringNumbersTests
{
    [TestCase("four hundred ninety-six million five hundred ninety-one thousand six hundred twenty-seven", "496591627")]
    [TestCase("one", "1")]
    [TestCase("one million twenty-three", "1000023")]
    [TestCase("zero", "0")]
    public void StringNumberTests(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, StringNumber.StringNumberSolver(task));
    }
}