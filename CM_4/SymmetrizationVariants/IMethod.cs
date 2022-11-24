using CM_4.Models.Functions;
using CM_4.Models;
using CM_4.Tools.Calculators;

namespace CM_4.SymmetrizationVariants;

public interface IMethod
{
    public void Solve(List<Function> system, Matrix matrix, double[] point, double eps1, double eps2, int maxIter,
        out List<double[]> points, out List<double> norms, out List<double> betas);
}