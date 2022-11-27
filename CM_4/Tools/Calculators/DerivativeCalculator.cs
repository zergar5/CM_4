using CM_4.Models.Functions;

namespace CM_4.Tools.Calculators;

public class DerivativeCalculator
{
    private const double Delta = 0.001;

    private static readonly Dictionary<char, int> Point = new()
    {
        {'x', 0},
        {'y', 1}
    };

    public static double CalcDerivative(Function function, char variableChar, double[] point)
    {
        var variable = point[Point[variableChar]];

        point[Point[variableChar]] = variable + Delta;
        var f1 = function.CalcFunction(point);

        point[Point[variableChar]] = variable - Delta;
        var f2 = function.CalcFunction(point);

        point[Point[variableChar]] = variable;

        var derivative = (f1 - f2) / (2.0 * Delta);

        return derivative;
    }
}