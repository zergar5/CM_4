using CM_4.Models.Functions;
using System.Drawing;

namespace CM_4_Graphics;

public class SystemDrawer
{
    public static void DrawLine(Graphics graphics, Line line, Point center, int scale, double eps)
    {
        var pen = new Pen(Color.FromArgb(166, 79, 255), 3f);
        if (Math.Abs(line.B) < eps)
        {
            graphics.DrawLine(pen, new PointF((float)(center.X - line.C / line.A * scale), 0),
                new PointF((float)(center.X - line.C / line.A * scale), center.Y * 2));

        }
        else if (Math.Abs(line.A) < eps)
        {
            graphics.DrawLine(pen, new PointF(0, (float)(center.Y + line.C / line.B * scale)),
                new PointF(center.X * 2, (float)(center.Y + line.C / line.B * scale)));
        }
        else
        {
            graphics.DrawLine(pen,
                new PointF((float)(-line.C * scale / line.B), (float)(center.Y + center.X * -line.A / line.B)),
                new PointF((float)(center.X * 2 - line.C * scale / line.B),
                    (float)(center.Y - center.X * -line.A / line.B)));
        }
    }

    public static void DrawCircle(Graphics graphics, Circle circle, Point center, int scale)
    {
        var pen = new Pen(Color.FromArgb(57, 105, 255), 3f);
        var upperLeftCorner = new PointF((float)(center.X + (circle.CenterX - circle.Radius) * scale), (float)(center.Y - (circle.CenterY + circle.Radius) * scale));
        var d = (float)(circle.Radius * 2 * scale);
        var rectangle = new RectangleF(upperLeftCorner.X, upperLeftCorner.Y, d, d);
        graphics.DrawEllipse(pen, rectangle);
    }

    public static void DrawSinusoid(Graphics graphics, Sinusoid sinusoid, Point center, int scale)
    {
        var pen = new Pen(Color.FromArgb(160, 255, 57), 3f);
        var leftPoints = new PointF[center.X * 4];
        var rightPoints = new PointF[center.X * 4];
        for (var i = 0; i < center.X * 4; i++)
        {
            leftPoints[i] = new PointF(center.X + i / 100.0f * scale,
                (float)(center.Y - (sinusoid.Shift + sinusoid.Amplitude *
                    Math.Sin(sinusoid.Frequency * i / 100.0f + sinusoid.NegativeShift)) * scale));
            rightPoints[i] = new PointF(center.X - i / 100.0f * scale,
                (float)(center.Y - (sinusoid.Shift + sinusoid.Amplitude *
                    Math.Sin(sinusoid.Frequency * (-i / 100.0f) + sinusoid.NegativeShift)) * scale));
        }

        graphics.DrawLines(pen, leftPoints);
        graphics.DrawLines(pen, rightPoints);
    }
}