using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class ShapeTests
{
    [TestCase(ShapeData.Circle, "circle")]
    [TestCase(ShapeData.Circle2, "circle")]
    [TestCase(ShapeData.Square, "square")]
    [TestCase(ShapeData.Equilateraltriangle, "equilateraltriagle")]
    [TestCase(ShapeData.Ellipse, "ellipse")]
    [TestCase(ShapeData.Rectangle, "rectangle")]
    [TestCase(ShapeData.Triangle, "triangle")]
    public static void ShapeTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, NewShape.NewShapeSolver(task));
    }
}
