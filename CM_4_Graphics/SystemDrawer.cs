using CM_4.Models.Functions;

namespace CM_4_Graphics;

public class SystemDrawer
{
    public static int X0;
    public static int Y0;
    public static int FunctionNumber;
    public static Font Font;
    public static (Label, PictureBox) DrawLine(Graphics graphics, Line line, Point center, int scale, double eps, int xSize, int ySize)
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
                new PointF((float)(center.X - (xSize - 1) * scale), (float)(center.Y - ((xSize - 1) * line.A - line.C) / line.B * scale)),
                new PointF((float)(center.X + (xSize - 1) * scale), (float)(center.Y + ((xSize - 1) * line.A + line.C) / line.B * scale)));
        }

        CreateFunctionView(pen.Color, out var fLabel, out var fColor);

        return (fLabel, fColor);
    }

    public static (Label, PictureBox) DrawCircle(Graphics graphics, Circle circle, Point center, int scale)
    {
        var pen = new Pen(Color.FromArgb(57, 105, 255), 3f);
        var upperLeftCorner = new PointF((float)(center.X + (circle.CenterX - circle.Radius) * scale), (float)(center.Y - (circle.CenterY + circle.Radius) * scale));
        var d = (float)(circle.Radius * 2 * scale);
        var rectangle = new RectangleF(upperLeftCorner.X, upperLeftCorner.Y, d, d);
        graphics.DrawEllipse(pen, rectangle);

        CreateFunctionView(pen.Color, out var fLabel, out var fColor);

        return (fLabel, fColor);
    }

    public static (Label, PictureBox) DrawSinusoid(Graphics graphics, Sinusoid sinusoid, Point center, int scale)
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

        CreateFunctionView(pen.Color, out var fLabel, out var fColor);

        return (fLabel, fColor);
    }

    private static void CreateFunctionView(Color color, out Label fLabel, out PictureBox fColor)
    {
        fLabel = new Label
        {
            Location = new Point(X0, Y0),
            Size = new Size(40, 20),
            Text = $"f{FunctionNumber++} (x)",
            Font = Font
        };
        Y0 += 20;
        fColor = new PictureBox
        {
            Location = new Point(X0, Y0),
            Size = new Size(40, 5),
            BackColor = color
        };
        Y0 += 5;
    }
}