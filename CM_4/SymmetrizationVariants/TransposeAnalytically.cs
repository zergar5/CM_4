using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.Tools;
using CM_4.Tools.Calculators;

namespace CM_4.SymmetrizationVariants;

public class TransposeAnalytically : IMethod
{
    public void Solve(List<Function> system, Matrix matrix, double[] point, double eps1, double eps2, int maxIter,
        out List<double[]> points, out List<double> norms, out List<double> betas)
    {
        points = new List<double[]>();
        norms = new List<double>();
        betas = new List<double>();
        var beta = 1.0;
        var residual = 1.0;
        var f = SystemCalculator.CalcF(system, point);
        var normF0 = Calculator.CalcNorm(f);
        var startPoint = new double[point.Length];
        Array.Copy(point, startPoint, point.Length);
        points.Add(startPoint);
        norms.Add(normF0);
        for (var i = 1; i < maxIter && residual > eps2; i++)
        {
            f = SystemCalculator.CalcF(system, point);
            var normFPrev = Calculator.CalcNorm(f);

            matrix.CalcJacobianAnalytically(system, point);
            var matrixA = matrix.A;

            var minusATF = Calculator.InvertSignOfVector(Calculator.MultiplyTransposedOnVector(matrixA, f));

            matrix.A = Calculator.MultiplyTransposedOnOriginal(matrixA);
            
            matrix.LDUDecomposition();

            var deltaX = SLAESolver.SolveSLAE(matrix.A, minusATF);

            var nextPoint = Calculator.SumVectors(point, deltaX);

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

            //CourseHolder.GetInfo(i, beta, point, normF);

            residual = normF / normF0;

            points.Add(point);
            norms.Add(normF);
            betas.Add(beta);
        }
    }
}