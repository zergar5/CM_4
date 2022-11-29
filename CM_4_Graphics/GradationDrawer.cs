using CM_4.Models.Functions;
using CM_4.Tools.Calculators;
using System;
using System.Drawing.Drawing2D;

namespace CM_4_Graphics;

public class GradationDrawer
{
    public static void DrawGradation(Graphics graphics, List<Function> system, Point center, int xSize, int ySize, int scale, Graphics gradationLegend, int legendWidth, int legendHeight, Font font)
    {
        const double delta = 1.0e-6;

        var ranges = new List<double>
        {
            1.0e-9,
            1.0e-3,
            1.0e-2,
            1.0e-1,
            1.0e0,
            1.0e1,
            1.0e2,
            1.0e3
        };

        var colors = new[]
        {
            Color.FromArgb(41, 248, 255),
            Color.FromArgb(95, 255, 184),
            Color.FromArgb(159, 255, 143),
            Color.FromArgb(242, 255, 82),
            Color.FromArgb(255, 215, 99),
            Color.FromArgb(255, 130, 33),
            Color.FromArgb(228, 0, 1)
        };

        var brushes = new[]
        {
            new SolidBrush(colors[0]),
            new SolidBrush(colors[1]),
            new SolidBrush(colors[2]),
            new SolidBrush(colors[3]),
            new SolidBrush(colors[4]),
            new SolidBrush(colors[5]),
            new SolidBrush(colors[6])
        };

        DrawLegend(gradationLegend, legendWidth, legendHeight, colors, font, ranges);

        CreateGradation(system, graphics, center, brushes, ranges, delta, scale);
    }

    private static void DrawLegend(Graphics gradationLegend, int legendWidth, int legendHeight, Color[] colors, Font font, List<double> ranges)
    {
        var canvas = new RectangleF(legendWidth/2, 14, legendWidth/2, legendHeight - 28);
        var legendBlend = new ColorBlend
        {
            Colors = colors,
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

        for (var i = 0; i < ranges.Count; i++)
        {
            gradationLegend.DrawString($"{ranges[i]:0.000e+000}", font, Brushes.Black,
                new PointF(0, i * offset));
            gradationLegend.DrawLine(pen, legendWidth / 2, i * offset + 14, legendWidth, i * offset + 14);
        }
    }

    public static void CreateGradation(List<Function> system, Graphics graphics, Point center, SolidBrush[] brushes, List<double> ranges, double delta, int scale)
    {
        for (var i = 0; i < center.Y * 2; i++)
        {
            for (var j = 0; j < center.X * 2; j++)
            {
                var point = new[] { (double)(-center.X + j) / scale, (double)(center.Y - i) / scale };
                var f = SystemCalculator.CalcF(system, point);
                var normF = Math.Log10(Calculator.CalcNorm(f));
                var pixel = new PointF(j, i);
                if (ranges[0] < normF && normF <= ranges[1] + delta)
                {
                    graphics.FillRectangle(brushes[0], pixel.X, pixel.Y, 1, 1);
                }
                else if (ranges[1] + delta < normF && normF <= ranges[2] + delta)
                {
                    graphics.FillRectangle(brushes[1], pixel.X, pixel.Y, 1, 1);
                }
                else if (ranges[2] + delta < normF && normF <= ranges[3] + delta)
                {
                    graphics.FillRectangle(brushes[2], pixel.X, pixel.Y, 1, 1);
                }
                else if (ranges[3] + delta < normF && normF <= ranges[4] + delta)
                {
                    graphics.FillRectangle(brushes[3], pixel.X, pixel.Y, 1, 1);
                }
                else if (ranges[4] + delta < normF && normF <= ranges[5] + delta)
                {
                    graphics.FillRectangle(brushes[4], pixel.X, pixel.Y, 1, 1);
                }
                else if (ranges[5] + delta < normF && normF <= ranges[6] + delta)
                {
                    graphics.FillRectangle(brushes[5], pixel.X, pixel.Y, 1, 1);
                }
                else if (ranges[6] + delta < normF && normF <= ranges[7] + delta)
                {
                    graphics.FillRectangle(brushes[6], pixel.X, pixel.Y, 1, 1);
                }
            }
        }
    }
}