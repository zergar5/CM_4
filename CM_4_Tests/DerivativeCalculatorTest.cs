using System.Drawing;
using CM_4.Models.Functions;
using CM_4.Tools.Calculators;

namespace CM_4_Tests;

public class DerivativeCalculatorTest
{
    private Function _line;
    private Function _circle;
    private Function _sinusoid;
    private double[] _point;
    private DerivativeCalculator _derivativeCalculator;

    [SetUp]
    public void Setup()
    {
        _line = new Line(1, 1, -4);
        _circle = new Circle(6, 2, 2);
        _sinusoid = new Sinusoid(0, 1, 2, 0);
        _point = new[] { 1.0, 1.0 };
        _derivativeCalculator = new DerivativeCalculator();
    }

    [TestCase(0.99999999999988987)]
    public void CalcXDerivativeLineTest(double actual)
    {
        var expected = _derivativeCalculator.CalcDerivative(_line, 'x', _point);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0.99999999999988987)]
    public void CalcYDerivativeLineTest(double actual)
    {
        var expected = _derivativeCalculator.CalcDerivative(_line, 'y', _point);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-9.9999999999980105)]
    public void CalcXDerivativeCircleTest(double actual)
    {
        var expected = _derivativeCalculator.CalcDerivative(_circle, 'x', _point);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-2.0000000000006679)]
    public void CalcYDerivativeCircleTest(double actual)
    {
        var expected = _derivativeCalculator.CalcDerivative(_circle, 'y', _point);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-0.83229311823190821)]
    public void CalcXDerivativeSinusoidTest(double actual)
    {
        var expected = _derivativeCalculator.CalcDerivative(_sinusoid, 'x', _point);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-0.99999999999994538)]
    public void CalcYDerivativeSinusoidTest(double actual)
    {
        var expected = _derivativeCalculator.CalcDerivative(_sinusoid, 'y', _point);
        Assert.That(actual, Is.EqualTo(expected));
    }
}