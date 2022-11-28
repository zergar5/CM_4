using System.Text;

namespace CM_4_Graphics;

public class CourseHolder
{
    public static string GetInfo(int i, (double[] point, double norm, double beta) iteration)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Iteration: {i}");
        stringBuilder.AppendLine($"Beta: {iteration.beta}");
        stringBuilder.AppendLine($"X: {iteration.point[0]}");
        stringBuilder.AppendLine($"Y: {iteration.point[1]}");
        stringBuilder.Append($"Norm: {iteration.norm}");
        return stringBuilder.ToString().Replace(",", ".");
    }

    public static void DrawInfo(Graphics graphics, PointF startPoint, double[] point, Font font, Pen pen)
    {
        var stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Near;
        stringFormat.LineAlignment = StringAlignment.Near;

        graphics.DrawEllipse(pen, new RectangleF(startPoint.X - 5, startPoint.Y - 5, 10, 10));
        graphics.DrawString($"    ({point[0]}, {point[1]})", font, Brushes.Black,
        startPoint, stringFormat);
    }
}