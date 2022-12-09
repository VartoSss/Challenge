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
    [TestCase("(-2863.42)*x^6 + (-2995.179999999999)*x^5 + 10255.8*x^4 + (-12426.61)*x^3 + 11243.74*x^2 + (-3525.75)*x + (-479.73999999999995)", false)]
    [TestCase("(-91.6)*x^2 + 21*x + 50", false)]
    [TestCase("(-29.200000000000003)*x^3 + 24.900000000000002*x^2 + 68.6*x + 28", false)]
    [TestCase("(-97.6)*x^3 + 89.89999999999999*x^2 + 47.9*x + 33.1", false)]
    [TestCase("(-8.299999999999999)*x^3 + (-54.9)*x^2 + 90*x + 25.6", false)]
    [TestCase("(-54080.02599999999)*x^4 + (-1419526.5148)*x^3 + (-7557928.596)*x^2 + 8029795.460799997*x + 19137687.088000003", false)]
    [TestCase("96.5*x^3 + (-87.8)*x^2 + 84.19999999999999*x + 26.900000000000002", false)]
    [TestCase("50.2*x^3 + (-18.200000000000003)*x^2 + (-50.9)*x + 6.8999999999999995", false)]
    [TestCase("(-50.4)*x^3 + 37.800000000000004*x^2 + 81.8*x + (-69.89999999999999)", false)]
    [TestCase("74.19999999999999*x + 76.89999999999999", false)]
    [TestCase("1571.94*x^4 + (-1684.98)*x^3 + 6335.16*x^2 + (-5340.62)*x + 6774.3", true)]
    [TestCase("4987.71*x^6 + 6292.960000000001*x^5 + 6590.98*x^4 + 9287.78*x^3 + 4788.87*x^2 + 2257.3700000000003*x + 1545.3000000000002", true)]
    
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