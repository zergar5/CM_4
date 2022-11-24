using System.Windows.Forms.VisualStyles;
using CM_4.IO;
using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.SymmetrizationVariants;

namespace CM_4_Graphics;

public class MethodLauncher
{
    public static (List<double[]>, List<double>) LaunchMethod(IMethod method, List<Function> system)
    {
        var pointO = new PointIO("../CM_4/Output/");
        var pointI = new PointIO("../CM_4/Input/");
        var parameterI = new ParametersIO("../CM_4/Input/");

        var point = pointI.Read("point.txt");

        var (eps1, eps2, maxIter) = parameterI.ReadParameters("parameters.txt");

        var matrix = new Matrix();

        var result = method.Solve(system, matrix, point, eps1, eps2, maxIter);
        var type = method.GetType();
        pointO.Write(result.Item1[^1], $"{type.Name}.txt");
        return result;
    }
}