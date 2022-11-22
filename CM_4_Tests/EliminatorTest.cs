using CM_4.Models.Functions;
using CM_4.Tools;
using CM_4.Tools.Calculators;

namespace CM_4_Tests;

public class EliminatorTest
{
    private List<Function> _system;
    private double[] _point;

    [SetUp]
    public void Setup()
    {
        _system = new List<Function>
        {
            new Line(1, -10, 0),
            new Line(1, 1, -4),
            new Line(1, -0.5, 0)
        };
        _point = new[] { 1.0, 1.0 };
    }

    [Test]
    public void EliminateTest()
    {
        var actual = new List<Function>
        {
            new Line(1, -10, 0),
            new Line(1, 1, -4),
        };
        var expected = Eliminator.Eliminate(_system, SystemCalculator.CalcF(_system, _point), _point.Length);
        CollectionAssert.AreEqual(expected, actual);
    }
}