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
    [TestCase("(-7.1)*x + 54", false)]
    [TestCase("0*x + 1", true)]
    [TestCase("(-27.3)*x^3 + 4.3999999999999995*x^2 + 26.900000000000002*x + 2.8000000000000003", false)]
    [TestCase("20.5*x^5 + (-5.3)*x^4 + 32.300000000000004*x^3 + (-11.5)*x^2 + 5.6*x + 1.1", false)]
    [TestCase("2.7*x^5 + (-77)*x^4 + (-72.69999999999999)*x^3 + 60.9*x^2 + 34.6*x + 14.6", false)]
    [TestCase("0.4*x^4 + (-0.82)*x^3 + 1.53*x^2 + (-0.86)*x + 0.8", true)]
    [TestCase("(-1.3)*x^3 + 2.1*x^2 + 1.6*x + 0.9", false)]
    [TestCase("37*x^3 + 90*x^2 + 89.89999999999999*x + (-92.1)", false)]
    [TestCase("108619.35840000001*x^4 + 1258636.1760000004*x^3 + (-6188048.9748)*x^2 + (-2832058.3284000005)*x + 1977745.8959999995", false)]
    [TestCase("(-7.1)*x + 54", false)]
    [TestCase("(-69.1)*x^2 + 9.5*x + 60", false)]
    [TestCase("23858127.930000003*x^4 + 28894775.243200004*x^3 + 3685588.185900001*x^2 + (-2991464.287)*x + (-341474.4552)", false)]
    [TestCase("208.75000000000003*x^4 + 140.73999999999998*x^3 + 1774.97*x^2 + 232.0599999999999*x + 3403.1799999999994", true)]
    [TestCase("4352.04*x^6 + (-4305.12)*x^5 + 4524*x^4 + (-4101.1)*x^3 + 1675.7199999999998*x^2 + 1391.8200000000002*x + (-1306.2600000000002)", false)]
    [TestCase("3672.6799999999994*x^6 + (-4725.2199999999975)*x^5 + (-19844.1)*x^4 + (-10495.489999999998)*x^3 + 4567.9800000000005*x^2 + 11265.079999999998*x + 3585.8399999999997", false)]
    [TestCase("1156.19*x^4 + (-5627.71)*x^3 + 8596.04*x^2 + (-2349.4600000000005)*x + 310.44", true)]
    [TestCase("9.799999999999999*x^2 + 96.8*x + 56.6", false)]
    [TestCase("(-1250881.9200000004)*x^4 + 361944.72839999804*x^3 + 17393930.254599996*x^2 + 24365058.529*x + 9033328.48", false)]
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
        Assert.Less(polynomResult, 1e-3);
    }
}