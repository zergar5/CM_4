using CM_4.Models.Functions;
using CM_4.Tools.Calculators;

namespace CM_4_Tests;

public class SystemCalculatorTest
{
    private double[] _point;

    [SetUp]
    public void Setup()
    {
        _point = new[] { 1.0, 1.0 };
    }

    [TestCase(new[] { -9.0, -2.0, 0.5 })]
    public void CalcFLinesTest(double[] actual)
    {
        var linesSystem = new List<Function>
        {
            new Line(1, -10, 0),
            new Line(1, 1, -4),
            new Line(1, -0.5, 0)
        };
        var expected = SystemCalculator.CalcF(linesSystem, _point);
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCase(new[] { -3.0, 22.0 })]
    public void CalcFCirclesTest(double[] actual)
    {
        var circlesSystem = new List<Function>
        {
            new Circle(1, 2, 2),
            new Circle(6, 2, 2),
        };
        var expected = SystemCalculator.CalcF(circlesSystem, _point);
        CollectionAssert.AreEqual(expected, actual);
    }
}