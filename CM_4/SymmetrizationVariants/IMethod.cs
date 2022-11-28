using CM_4.Models;
using CM_4.Models.Functions;

namespace CM_4.SymmetrizationVariants;

public interface IMethod
{
    public double[] Preparation(List<Function> system, double[] startPoint, out double beta, out double residual,
        out double normF0);

    public IEnumerable<(double[] point, double norm, double beta)> Solve(List<Function> system, Matrix matrix,
        double[] startPoint, double eps1, double eps2, int maxIter);
}