using CM_4.Models.Functions;
using CM_4.Tools.Calculators;

namespace CM_4.Models;

public class Matrix
{
    public double[,] A { get; set; }

    public void CalcJacobianAnalytically(List<Function> system, double[] point)
    {
        A = new double[system.Count, point.Length];

        for (var i = 0; i < system.Count; i++)
        {
            var derivatives = system[i].CalcDerivatives(point);
            for (var j = 0; j < derivatives.Length; j++)
            {
                A[i, j] = derivatives[j];
            }
        }
    }

    public void CalcJacobianNumerically(List<Function> system, double[] point)
    {
        A = new double[system.Count, point.Length];

        for (var i = 0; i < system.Count; i++)
        {
            for (var j = 0; j < point.Length; j++)
            {
                A[i, j] = DerivativeCalculator.CalcDerivative(system[i], (char)('x' + j), point);
            }
        }
    }

    public void LDUDecomposition()
    {
        var n = A.GetLength(0);
        for (var i = 0; i < n; i++)
        {
            var sumD = 0.0;
            for (var j = 0; j < i; j++)
            {
                var sumL = 0.0;
                var sumU = 0.0;
                for (var k = 0; k < j; k++)
                {
                    sumL += A[i, k] * A[k, k] * A[k, j];
                    sumU += A[j, k] * A[k, k] * A[k, i];
                }

                A[i, j] = (A[i, j] - sumL) / A[j, j];
                A[j, i] = (A[j, i] - sumU) / A[j, j];
                sumD += A[i, j] * A[j, j] * A[j, i];
            }

            A[i, i] -= sumD;
        }
    }
}