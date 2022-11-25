using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

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