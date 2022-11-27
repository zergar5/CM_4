using CM_4.Models.Functions;
using CM_4.Models;
using CM_4.Tools.Calculators;
using CM_4.Tools;

namespace CM_4.SymmetrizationVariants;

public class TransposeNumerically : Method
{
    public override IEnumerable<(double[] point, double norm, double beta)> Solve(List<Function> system, Matrix matrix, double[] startPoint, double eps1, double eps2, int maxIter)
    {
        var point = Preparation(system, startPoint, out var beta, out var residual, out var normF0);

        yield return (point, normF0, beta);

        for (var i = 1; i < maxIter && residual > eps2; i++)
        {
            var f = SystemCalculator.CalcF(system, point);
            var normFPrev = Calculator.CalcNorm(f);

            matrix.CalcJacobianNumerically(system, point);
            var matrixA = matrix.A;

            var minusATF = Calculator.InvertSignOfVector(Calculator.MultiplyTransposedOnVector(matrixA, f));

            matrix.A = Calculator.MultiplyTransposedOnOriginal(matrixA);

            matrix.LDUDecomposition();

            var deltaX = SLAESolver.SolveSLAE(matrix.A, minusATF);

            var nextPoint = Calculator.SumVectors(point, deltaX);

            var fNext = SystemCalculator.CalcF(system, nextPoint);
            var normF = Calculator.CalcNorm(fNext);

            beta = 1.0;

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