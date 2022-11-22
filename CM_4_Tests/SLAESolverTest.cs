using CM_4.Models;
using CM_4.Tools;

namespace CM_4_Tests;

public class SLAESolverTest
{
    private double[,] _matrix;
    private double[] _f;

    [SetUp]
    public void Setup()
    {
        var matrix = new Matrix();
        _matrix = new[,]
        {
            { 5.0, 11.0, 17.0 },
            { 11.0, 25, 39.0 },
            { 17.0, 39.0, 60.0 }
        };
        matrix.A = _matrix;
        matrix.LDUDecomposition();
        _matrix = matrix.A;

        _f = new[] { 33.0, 75.0, 116.0 };
    }

    [TestCase(new[] { 1.0000000000000049, 1.0000000000000195, 0.99999999999998579 })]
    public void SolveSLAETest(double[] actual)
    {
        var expected = SLAESolver.SolveSLAE(_matrix, _f);
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCase(new[] { 33.0, 2.3999999999999915, -0.99999999999998579 })]
    public void CalcYTest(double[] actual)
    {
        var expected = SLAESolver.CalcY(_matrix, _f);
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCase(new[] { 6.6, 3.0, 0.99999999999998579 }, new[] { 33.0, 2.3999999999999915, -0.99999999999998579 })]
    public void CalcZTest(double[] actual, double[] y)
    {
        SLAESolver.CalcZ(_matrix, y);
        CollectionAssert.AreEqual(y, actual);
    }

    [TestCase(new[] { 1.0000000000000049, 1.0000000000000195, 0.99999999999998579 }, new[] { 6.6, 3.0, 0.99999999999998579 })]
    public void CalcXTest(double[] actual, double[] z)
    {
        SLAESolver.CalcX(_matrix, z);
        CollectionAssert.AreEqual(z, actual);
    }
}