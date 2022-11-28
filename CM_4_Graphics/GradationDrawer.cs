using CM_4.Models.Functions;
using CM_4.Tools.Calculators;
using System.Drawing.Drawing2D;

namespace CM_4_Graphics;

public class GradationDrawer
{
    public static void DrawGradation(Graphics graphics, List<Function> system, Point center, int xSize, int ySize, int scale, Graphics gradationLegend, int legendWidth, int legendHeight, Font font)
    {
        CalcMin(system, center, xSize, ySize, scale, out var min, out var minPoint);

        var colorBlend = CreateColorBlend(system, center, min, xSize, ySize, scale, out var centralPoints, out var contour, out var ranges);

        DrawLegend(gradationLegend, legendWidth, legendHeight, colorBlend, font, ranges);

        var graphicsPath = new GraphicsPath();

        PointF centerPoint;

        if (centralPoints.Count == 0)
        {
            centerPoint = minPoint;
        }
        else
        {
            centerPoint = new PointF(centralPoints.Sum(point => point.X) / centralPoints.Count,
                centralPoints.Sum(point => point.Y) / centralPoints.Count);
        }

        if (contour.Count > 4)
        {
            graphicsPath.AddLines(BuildContour(contour, center));

            var pathGradientBrush = new PathGradientBrush(graphicsPath);

            pathGradientBrush.InterpolationColors = colorBlend;

            pathGradientBrush.CenterPoint = centerPoint;

            graphics.FillPath(pathGradientBrush, graphicsPath);
        }
        else
        {
            var canvas = new RectangleF(-center.X, -center.Y, center.X * 4, center.Y * 4);
            graphicsPath.AddEllipse(canvas);

            var pathGradientBrush = new PathGradientBrush(graphicsPath);
            pathGradientBrush.InterpolationColors = colorBlend;
            pathGradientBrush.CenterPoint = centerPoint;

            graphics.FillEllipse(pathGradientBrush, canvas);
        }
    }

    private static void CalcMin(List<Function> system, PointF center, int xSize, int ySize, int scale, out double min, out PointF minPoint)
    {
        min = double.MaxValue;
        minPoint = new PointF();

        for (var i = 0; i < (ySize * 2 - 1) * 100; i++)
        {
            for (var j = 0; j < (xSize * 2 - 1) * 100; j++)
            {
                var point = new[] { -(xSize - 1) + j / 100.0, (ySize - 1) - i / 100.0 };
                var f = SystemCalculator.CalcF(system, point);
                var normF = Math.Log10(Calculator.CalcNorm(f));
                var centralPoint = new PointF((float)(center.X - (xSize - 1) * scale + j / 100.0 * scale), (float)(center.Y - (ySize - 1) * scale + i / 100.0 * scale));

                if (!(normF < min)) continue;
                min = normF;
                minPoint = centralPoint;
            }
        }
    }

    private static ColorBlend CreateColorBlend(List<Function> system, PointF center, double min, int xSize, int ySize,
        int scale, out List<PointF> centralPoints, out List<(PointF, PointF)> contour, out List<double> ranges)

    {
        centralPoints = new List<PointF>();
        contour = new List<(PointF, PointF)>();

        const double delta = 1.0e-6;

        ranges = new List<double>
        {
            1.0e-9,
            1.0e-3,
            1.0e-2,
            1.0e-1,
            1.0e0,
            1.0e1,
            1.0e2,
        };

        var secondRange = 0;
        var thirdRange = 0;
        var fourthRange = 0;
        var fifthRange = 0;
        var sixthRange = 0;

        for (var i = 0; i < (ySize * 2 - 1) * 100; i++)
        {
            var leftPoint = new PointF(float.MaxValue, float.MaxValue);
            var rightPoint = new PointF(0.0f, 0.0f);
            for (var j = 0; j < (xSize * 2 - 1) * 100; j++)
            {
                var point = new[] { -(xSize - 1) + j / 100.0, (ySize - 1) - i / 100.0 };
                var f = SystemCalculator.CalcF(system, point);
                var normF = Math.Log10(Calculator.CalcNorm(f));
                var centralPoint = new PointF((float)(center.X - (xSize - 1) * scale + j / 100.0 * scale),
                    (float)(center.Y - (ySize - 1) * scale + i / 100.0 * scale));
                if (ranges[0] < normF && normF <= ranges[1] + delta)
                {
                    centralPoints.Add(centralPoint);
                    if (rightPoint.X < centralPoint.X)
                    {
                        rightPoint = centralPoint;
                    }

                    if (leftPoint.X > centralPoint.X)
                    {
                        leftPoint = centralPoint;
                    }
                }
                else if (ranges[1] + delta < normF && normF <= ranges[2] + delta)
                {
                    secondRange++;
                }
                else if (ranges[2] + delta < normF && normF <= ranges[3] + delta)
                {
                    thirdRange++;
                }
                else if (ranges[3] + delta < normF && normF <= ranges[4] + delta)
                {
                    fourthRange++;
                }
                else if (ranges[4] + delta < normF && normF <= ranges[5] + delta)
                {
                    fifthRange++;
                }
                else if (ranges[5] + delta < normF && normF <= ranges[6] + delta)
                {
                    sixthRange++;
                }
            }

            if (leftPoint.X < float.MaxValue || rightPoint.X > 0.0f)
            {
                switch (leftPoint.X)
                {
                    case < float.MaxValue when rightPoint.X > 0.0f:
                        contour.Add((leftPoint, rightPoint));
                        break;
                    case < float.MaxValue:
                        contour.Add((leftPoint, leftPoint));
                        break;
                    default:
                        contour.Add((rightPoint, rightPoint));
                        break;
                }
            }
        }

        var pointsNumber = (xSize * 2 - 1) * 100 * (ySize * 2 - 1) * 100;

        var colorBlend = new ColorBlend
        {
            Colors = new[]
            {
                Color.FromArgb(228, 0, 1),
                Color.FromArgb(255, 130, 33),
                Color.FromArgb(255, 215, 99),
                Color.FromArgb(242, 255, 82),
                Color.FromArgb(159, 255, 143),
                Color.FromArgb(95, 255, 184),
                Color.FromArgb(41, 248, 255)
            },
            Positions = new[]
            {
                0.0f,
                (float)sixthRange / pointsNumber,
                (float)(fifthRange + sixthRange) / pointsNumber,
                (float)(fifthRange + sixthRange + fourthRange) / pointsNumber,
                (float)(fifthRange + sixthRange + fourthRange + thirdRange) / pointsNumber,
                (float)(fifthRange + sixthRange + fourthRange + thirdRange + secondRange) / pointsNumber,
                1.0f
            }
        };
        return colorBlend;
    }

    private static PointF[] BuildContour(List<(PointF, PointF)> contour, PointF center)
    {
        var highPoints = contour.Take(1).Select(y => y.Item1 with { Y = y.Item1.Y - center.Y * 3 })
            .Concat(contour.Take(1).Select(y => y.Item2 with { Y = y.Item2.Y - center.Y * 3 }));
        var leftSidePoints = contour.GetRange(1, contour.Count - 2)
            .Select(x => x.Item1 with { X = x.Item1.X - center.X * 3 }).ToArray();
        var rightSidePoints = contour.GetRange(1, contour.Count - 2)
            .Select(x => x.Item2 with { X = x.Item1.X + center.X * 3 }).ToArray();
        var lowPoints = contour.TakeLast(1).Select(y => y.Item1 with { Y = y.Item1.Y + center.Y * 3 })
            .Concat(contour.TakeLast(1).Select(y => y.Item2 with { Y = y.Item2.Y + center.Y * 3 }));
        return leftSidePoints.Reverse().Concat(highPoints).Concat(rightSidePoints).Concat(lowPoints)
            .ToArray();
    }

    private static void DrawLegend(Graphics gradationLegend, int legendWidth, int legendHeight, ColorBlend colorBlend, Font font, List<double> ranges)
    {
        var canvas = new RectangleF(legendWidth/2, 14, legendWidth/2, legendHeight - 28);
        var legendBlend = new ColorBlend
        {
            Colors = colorBlend.Colors,
            Positions = new[]
            {
                0.0f,
                1/6f,
                2/6f,
                3/6f,
                4/6f,
                5/6f,
                1.0f
            }
        };
        var linearGradientBrush = new LinearGradientBrush(canvas, legendBlend.Colors[0], legendBlend.Colors[^1], LinearGradientMode.Vertical);
        linearGradientBrush.InterpolationColors = legendBlend;
        gradationLegend.FillRectangle(linearGradientBrush, canvas);

        const int offset = 58;

        var pen = new Pen(Color.Black, 1f);

        for (var i = 0; i < 7; i++)
        {
            gradationLegend.DrawString($"{ranges[i]:0.000e+000}", font, Brushes.Black,
                new PointF(0, i * offset));
            gradationLegend.DrawLine(pen, legendWidth / 2, i * offset + 14, legendWidth, i * offset + 14);
        }
        gradationLegend.DrawString($"{double.MaxValue:0.000e+000}", font, Brushes.Black,
            new PointF(0, legendHeight - 28));
        gradationLegend.DrawLine(pen, legendWidth / 2, legendHeight - 14, legendWidth, legendHeight - 14);
    }
}