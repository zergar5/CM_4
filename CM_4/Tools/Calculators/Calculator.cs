namespace CM_4.Tools.Calculators;

public class Calculator
{
    public static double[,] MultiplyTransposedOnOriginal(double[,] matrix)
    {
        var result = new double[matrix.GetLength(1), matrix.GetLength(1)];
        for (var i = 0; i < matrix.GetLength(1); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = 0.0;

                for (var k = 0; k < matrix.GetLength(0); k++)
                {
                    result[i, j] += matrix[k, i] * matrix[k, j];
                }
            }
        }
        return result;
    }

    public static double[] MultiplyTransposedOnVector(double[,] matrix, double[] f)
    {
        var result = new double[matrix.GetLength(1)];
        for (var i = 0; i < matrix.GetLength(1); i++)
        {
            result[i] = 0.0;
            for (var j = 0; j < f.Length; j++)
            {
                result[i] += matrix[j, i] * f[j];
            }
        }

        return result;
    }

    public static double[] InvertSignOfVector(double[] f)
    {
        return f.Select(x => -x).ToArray();
    }

    public static double CalcNorm(double[] f)
    {
        return Math.Sqrt(f.Sum(item => item * item));
    }

    public static double[] MultiplyVectorOnNumber(double[] deltaX, double beta)
    {
        return deltaX.Select(x => x * beta).ToArray();
    }

    public static double[] SumVectors(double[] a, double[] b)
    {
        var result = new double[a.Length];
        for (var i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }

        return result;
    }
}