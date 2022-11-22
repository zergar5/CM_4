using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.Tools.Calculators;

namespace CM_4_Tests;

public class MatrixTest
{
    private Matrix _matrix;
    private double[,] _A;
    private double[] _point;
    private List<Function> _linesSystem;
    private List<Function> _circlesSystem;
    private List<Function> _sinusoidSystem;
    private DerivativeCalculator _derivativeCalculator;

    [SetUp]
    public void Setup()
    {
        _matrix = new Matrix();
        _A = new[,]
        {
            { 5.0, 11.0, 17.0 },
            { 11.0, 25, 39.0 },
            { 17.0, 39.0, 60.0 }
        };
        _point = new[] { 1.0, 1.0 };
        _linesSystem = new List<Function>
        {
            new Line(1, -10, 0),
            new Line(1, 1, -4),
            new Line(1, -0.5, 0)
        };
        _circlesSystem = new List<Function>
        {
            new Circle(1, 2, 2),
            new Circle(6, 2, 2),
        };
        _sinusoidSystem = new List<Function>
        {
            new Sinusoid(0, 1, 2, 0),
            new Line(1, 1, -4),
        };
        _derivativeCalculator = new DerivativeCalculator();
    }

    [Test]
    public void LDUDecompositionTest()
    {
        var actual = new[,]
        {
            { 5.0, 2.2, 3.4 },
            { 2.2, 0.79999999999999716, 2.0000000000000089 },
            { 3.4, 2.0, -1.0 }
        };
        _matrix.A = _A;
        _matrix.LDUDecomposition();
        CollectionAssert.AreEqual(_matrix.A, actual);
    }

    [Test]
    public void AnalyticalJacobianLinesTest()
    {
        
        _matrix.CalcJacobian(_linesSystem, _point);
        var actual = new[,]
        {
            { 1.0, -10 },
            { 1.0, 1.0 },
            { 1.0, -0.5 }
        };
        CollectionAssert.AreEqual(_matrix.A, actual);
    }

    [Test]
    public void AnalyticalJacobianCirclesTest()
    {

        _matrix.CalcJacobian(_circlesSystem, _point);
        var actual = new[,]
        {
            { 0.0, -2.0 },
            { -10.0, -2.0 },
        };
        CollectionAssert.AreEqual(_matrix.A, actual);
    }

    [Test]
    public void AnalyticalJacobianSinusoidTest()
    {

        _matrix.CalcJacobian(_sinusoidSystem, _point);
        var actual = new[,]
        {
            { -0.83229367309428481, -1.0 },
            { 1.0, 1.0 },
        };
        CollectionAssert.AreEqual(_matrix.A, actual);
    }

    [Test]
    public void NumericalJacobianLinesTest()
    {
        
        _matrix.CalcJacobian(_linesSystem, _point, _derivativeCalculator);
        var actual = new[,]
        {
            { 0.99999999999944578, -9.9999999999988987 },
            { 0.99999999999988987, 0.99999999999988987 },
            { 0.99999999999994538, -0.49999999999994493 }
        };
        CollectionAssert.AreEqual(_matrix.A, actual);
    }

    [Test]
    public void NumericalJacobianCirclesTest()
    {

        _matrix.CalcJacobian(_circlesSystem, _point, _derivativeCalculator);
        var actual = new[,]
        {
            { 0.0, -1.9999999999997797 },
            { -9.9999999999980105, -2.0000000000006679 },
        };
        CollectionAssert.AreEqual(_matrix.A, actual);
    }

    [Test]
    public void NumericalJacobianSinusoidTest()
    {

        _matrix.CalcJacobian(_sinusoidSystem, _point, _derivativeCalculator);
        var actual = new[,]
        {
            { -0.83229311823190821, -0.99999999999994538 },
            { 0.99999999999988987, 0.99999999999988987 },
        };
        CollectionAssert.AreEqual(_matrix.A, actual);
    }
}