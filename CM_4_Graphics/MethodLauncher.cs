using CM_4.IO;
using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.SymmetrizationVariants;

namespace CM_4_Graphics;

public class MethodLauncher
{
    public static void LaunchMethod(IMethod method, List<Function> system, double[] point)
    {
        var pointO = new PointIO("../CM_4/Output/");
        var parameterI = new ParametersIO("../CM_4/Input/");

        var (eps1, eps2, maxIter) = parameterI.ReadParameters("parameters.txt");

        var matrix = new Matrix();

        point = method.Solve(system, matrix, point, eps1, eps2, maxIter);
        var type = method.GetType();
        pointO.Write(point, $"{type.Name}.txt");
    }
}