using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.Tools;
using CM_4.Tools.Calculators;

namespace CM_4.SymmetrizationVariants;

public class EliminateAnalytically : Method
{
    public override IEnumerable<(double[] point, double norm, double beta)> Solve(List<Function> system, Matrix matrix,
        double[] startPoint, double eps1, double eps2, int maxIter)

    {
        var point = Preparation(system, startPoint, out var beta, out var residual, out var normF0);

        yield return (point, normF0, beta);

        for (var i = 1; i < maxIter && beta > eps1 && residual > eps2; i++)
        {
            var f = SystemCalculator.CalcF(system, point);
            var normFPrev = Calculator.CalcNorm(f);

            var newSystem = Eliminator.Eliminate(system, f, point.Length);

            matrix.CalcJacobianAnalytically(newSystem, point);
            matrix.LDUDecomposition();
            var matrixA = matrix.A;

            var requiredF = SystemCalculator.CalcF(newSystem, point);

            var deltaX = SLAESolver.SolveSLAE(matrixA, Calculator.InvertSignOfVector(requiredF));

            var nextPoint = Calculator.SumVectors(point, deltaX);

            beta = 1.0;

            var fNext = SystemCalculator.CalcF(system, nextPoint);
            var normF = Calculator.CalcNorm(fNext);

            while (normF > normFPrev && beta > eps1)
            {
                beta /= 2.0;
                var betaDeltaX = Calculator.MultiplyVectorOnNumber(deltaX, beta);
                nextPoint = Calculator.SumVectors(point, betaDeltaX);

                fNext = SystemCalculator.CalcF(system, nextPoint);
                normF = Calculator.CalcNorm(fNext);
            }

            point = nextPoint;

            residual = normF / normF0;

            yield return (point, normF, beta);
        }
    }
}