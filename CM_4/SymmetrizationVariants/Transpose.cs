using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.Tools;
using CM_4.Tools.Calculators;

namespace CM_4.SymmetrizationVariants;

public class Transpose
{
    public static double[] SolveAnalytically(List<Function> system, Matrix matrix, double[] point, double eps1, double eps2, int maxIter)
    {
        var beta = 1.0;
        var residual = 1.0;
        var f = SystemCalculator.CalcF(system, point);
        var normF0 = Calculator.CalcNorm(f);
        for (var i = 1; i < maxIter && beta > eps1 && residual > eps2; i++)
        {
            f = SystemCalculator.CalcF(system, point);
            var normFPrev = Calculator.CalcNorm(f);

            matrix.CalcJacobian(system, point);
            var matrixA = matrix.A;

            var minusATF = Calculator.InvertSignOfVector(Calculator.MultiplyTransposedOnVector(matrixA, f));

            matrix.A = Calculator.MultiplyTransposedOnOriginal(matrixA);
            
            matrix.LDUDecomposition();

            var deltaX = SLAESolver.SolveSLAE(matrix.A, minusATF);

            var nextPoint = Calculator.SumVectors(point, deltaX);

            var fNext = SystemCalculator.CalcF(system, nextPoint);
            var normF = Calculator.CalcNorm(fNext);

            while (normF > normFPrev)
            {
                beta /= 2.0;
                var betaDeltaX = Calculator.MultiplyVectorOnNumber(deltaX, beta);
                nextPoint = Calculator.SumVectors(point, betaDeltaX);

                fNext = SystemCalculator.CalcF(system, nextPoint);
                normF = Calculator.CalcNorm(fNext);
            }

            point = nextPoint;

            CourseHolder.GetInfo(i, beta, point, normF);

            residual = normF / normF0;
        }

        return point;
    }

    public static double[] SolveNumerically(List<Function> system, Matrix matrix, double[] point, double eps1, double eps2, int maxIter, DerivativeCalculator derivativeCalculator)
    {
        var beta = 1.0;
        var residual = 1.0;
        var f = SystemCalculator.CalcF(system, point);
        var normF0 = Calculator.CalcNorm(f);
        for (var i = 1; i < maxIter && beta > eps1 && residual > eps2; i++)
        {
            f = SystemCalculator.CalcF(system, point);
            var normFPrev = Calculator.CalcNorm(f);

            matrix.CalcJacobian(system, point, derivativeCalculator);
            var matrixA = matrix.A;

            var minusATF = Calculator.InvertSignOfVector(Calculator.MultiplyTransposedOnVector(matrixA, f));

            matrix.A = Calculator.MultiplyTransposedOnOriginal(matrixA);

            matrix.LDUDecomposition();

            var deltaX = SLAESolver.SolveSLAE(matrix.A, minusATF);

            var nextPoint = Calculator.SumVectors(point, deltaX);

            var fNext = SystemCalculator.CalcF(system, nextPoint);
            var normF = Calculator.CalcNorm(fNext);

            while (normF > normFPrev)
            {
                beta /= 2.0;
                var betaDeltaX = Calculator.MultiplyVectorOnNumber(deltaX, beta);
                nextPoint = Calculator.SumVectors(point, betaDeltaX);

                fNext = SystemCalculator.CalcF(system, nextPoint);
                normF = Calculator.CalcNorm(fNext);
            }

            point = nextPoint;

            CourseHolder.GetInfo(i, beta, point, normF);

            residual = normF / normF0;
        }

        return point;
    }
}