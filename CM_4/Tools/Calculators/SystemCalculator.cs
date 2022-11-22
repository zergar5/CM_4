using CM_4.Models.Functions;

namespace CM_4.Tools.Calculators;

public class SystemCalculator
{
    public static double[] CalcF(List<Function> system, double[] point)
    {
        var f = new double[system.Count];

        for (var i = 0; i < system.Count; i++)
        {
            f[i] = system[i].CalcFunction(point);
        }

        return f;
    }
}