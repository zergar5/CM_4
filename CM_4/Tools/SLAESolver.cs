namespace CM_4.Tools;

public class SLAESolver
{
    public static double[] SolveSLAE(double[,] matrix, double[] f)
    {
        var y = CalcY(matrix, f);
        CalcZ(matrix, y);
        CalcX(matrix, y);
        return y;
    }

    public static double[] CalcY(double[,] matrix, double[] f)
    {
        var n = f.Length;
        var y = new double[n];
        Array.Copy(f, y, n);
        for (var i = 0; i < n; i++)
        {
            var sumL = 0.0;
            for (var j = 0; j < i; j++)
            {
                sumL += matrix[i, j] * y[j];
            }
            y[i] -= sumL;
        }
        return y;
    }

    public static void CalcZ(double[,] matrix, double[] y)
    {
        for (var i = 0; i < y.Length; i++)
        {
            y[i] /= matrix[i, i];
        }
    }

    public static void CalcX(double[,] matrix, double[] z)
    {
        for (var i = z.Length - 1; i >= 0; i--)
        {
            for (var j = 0; j < i; j++)
            {
                z[j] -= matrix[j, i] * z[i];
            }
        }
    }
}