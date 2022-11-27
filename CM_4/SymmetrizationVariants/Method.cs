using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.Tools.Calculators;

namespace CM_4.SymmetrizationVariants;

public abstract class Method : IMethod
{
    public virtual double[] Preparation(List<Function> system, double[] startPoint, out double beta,
        out double residual, out double normF0)
    {
        beta = 1.0;
        residual = 1.0;
        var f = SystemCalculator.CalcF(system, startPoint);
        normF0 = Calculator.CalcNorm(f);
        var point = new double[startPoint.Length];
        Array.Copy(startPoint, point, startPoint.Length);
        return point;
    }

    public abstract IEnumerable<(double[] point, double norm, double beta)> Solve(List<Function> system, Matrix matrix,
        double[] startPoint, double eps1, double eps2, int maxIter);
}