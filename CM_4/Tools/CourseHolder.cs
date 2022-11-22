using System.Text;

namespace CM_4.Tools;

public class CourseHolder
{

    public static void GetInfo(int iteration, double beta, double[] point, double normF)
    {
        Console.CursorVisible = false;
        var stringBuilder = new StringBuilder();

        var iterationInfo = $"Iteration: {iteration}, ";
        stringBuilder.Append(iterationInfo);

        stringBuilder.Append($"Beta: {beta}                  \n".Replace(',', '.'));

        for (var i = 0; i < point.Length; i++)
        {
            stringBuilder.Append($"Coordinate {(char)('x' + i)}: {point[i]}                  \n".Replace(',', '.'));
        }

        stringBuilder.Append($"F norm: {normF}                  ".Replace(',', '.'));
        Console.SetCursorPosition(0, 0);

        Console.Write(stringBuilder.ToString());
    }
}