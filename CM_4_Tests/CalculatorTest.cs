using CM_4.Tools.Calculators;

namespace CM_4_Tests;

public class Tests
{
    private double[,] _matrix;
    private double[] _f;

    [SetUp]
    public void Setup()
    {
        _matrix = new[,]
        {
            { 1.0, 2.0 },
            { 3.0, 4.0 },
            { 5.0, 6.0 }
        };
        _f = new[] { 1.0, 2.0, 3.0 };
    }

    [Test]
    public void MultiplyTransposedOnOriginalTest()
    {
        var actual = new[,]
        {
            { 35.0, 44.0 },
            { 44.0, 56.0 }
        };
        var expected = Calculator.MultiplyTransposedOnOriginal(_matrix);
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCase(new[] { 22.0, 28.0 })]
    public void MultiplyTransposedOnVectorTest(double[] actual)
    {
        var expected = Calculator.MultiplyTransposedOnVector(_matrix, _f);
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCase(new[] { -1.0, -2.0, -3.0 })]
    public void InvertSignOfVectorTest(double[] actual)
    {
        var expected = Calculator.InvertSignOfVector(_f);
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCase(3.74165738677394138)]
    public void CalcNormTest(double actual)
    {
        var expected = Calculator.CalcNorm(_f);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new[] { 2.0, 4.0, 6.0 }, 2.0)]
    public void MultiplyVectorOnNumberTest(double[] actual, double beta)
    {
        var expected = Calculator.MultiplyVectorOnNumber(_f, beta);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new[] { 2.0, 4.0, 6.0 }, new[] { 1.0, 2.0, 3.0 })]
    public void MultiplyVectorOnNumberTest(double[] actual, double[] a)
    {
        var expected = Calculator.SumVectors(a, _f);
        CollectionAssert.AreEqual(actual, expected);
    }
}