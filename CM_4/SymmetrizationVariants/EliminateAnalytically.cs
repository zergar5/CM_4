using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.Tools;
using CM_4.Tools.Calculators;

namespace CM_4.SymmetrizationVariants;

public class EliminateAnalytically : IMethod
{
    public double[] Solve(List<Function> system, Matrix matrix, double[] point, double eps1, double eps2, int maxIter)
    {
        var beta = 1.0;
        var residual = 1.0;
        var f = SystemCalculator.CalcF(system, point);
        var normF0 = Calculator.CalcNorm(f);
        for (var i = 1; i < maxIter && beta > eps1 && residual > eps2; i++)
        {
            f = SystemCalculator.CalcF(system, point);
            var normFPrev = Calculator.CalcNorm(f);

            var newSystem = Eliminator.Eliminate(system, f, point.Length);

            matrix.CalcJacobianAnalytically(newSystem, point);
            matrix.LDUDecomposition();
            var matrixA = matrix.A;

            var requiredF = SystemCalculator.CalcF(newSystem, point);

            var deltaX = SLAESolver.SolveSLAE(matrixA, Calculator.InvertSignOfVector(requiredF));

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

    //public double[] SolveNumerically(List<Function> system, Matrix matrix, double[] point, double eps1, double eps2, int maxIter, DerivativeCalculator derivativeCalculator)
    //{
    //    var beta = 1.0;
    //    var residual = 1.0;
    //    var f = SystemCalculator.CalcF(system, point);
    //    var normF0 = Calculator.CalcNorm(f);
    //    for (var i = 1; i < maxIter && beta > eps1 && residual > eps2; i++)
    //    {
    //        f = SystemCalculator.CalcF(system, point);
    //        var normFPrev = Calculator.CalcNorm(f);

    //        var newSystem = Eliminator.Eliminate(system, f, point.Length);

    //        matrix.CalcJacobian(newSystem, point, derivativeCalculator);
    //        matrix.LDUDecomposition();
    //        var matrixA = matrix.A;

    //        var requiredF = SystemCalculator.CalcF(newSystem, point);

    //        var deltaX = SLAESolver.SolveSLAE(matrixA, Calculator.InvertSignOfVector(requiredF));

    //        var nextPoint = Calculator.SumVectors(point, deltaX);

    //        var fNext = SystemCalculator.CalcF(system, nextPoint);
    //        var normF = Calculator.CalcNorm(fNext);

    //        while (normF > normFPrev)
    //        {
    //            beta /= 2.0;
    //            var betaDeltaX = Calculator.MultiplyVectorOnNumber(deltaX, beta);
    //            nextPoint = Calculator.SumVectors(point, betaDeltaX);

    //            fNext = SystemCalculator.CalcF(system, nextPoint);
    //            normF = Calculator.CalcNorm(fNext);
    //        }

    //        point = nextPoint;

    //        CourseHolder.GetInfo(i, beta, point, normF);

    //        residual = normF / normF0;
    //    }

    //    return point;
    //}
}