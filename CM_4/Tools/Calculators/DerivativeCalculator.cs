using CM_4.Models.Functions;

namespace CM_4.Tools.Calculators;

public class DerivativeCalculator
{
    private const double _delta = 0.001;

    private static readonly Dictionary<char, int> _point = new()
    {
        {'x', 0},
        {'y', 1}
    };

    public static double CalcDerivative(Function function, char variableChar, double[] point)
    {
        var variable = point[_point[variableChar]];

        point[_point[variableChar]] = variable + _delta;
        var f1 = function.CalcFunction(point);

        point[_point[variableChar]] = variable - _delta;
        var f2 = function.CalcFunction(point);

        point[_point[variableChar]] = variable;

        var derivative = (f1 - f2) / (2.0 * _delta);

        return derivative;
    }
}