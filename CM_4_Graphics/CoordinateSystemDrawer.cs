using System.Drawing;

namespace CM_4_Graphics;

public class CoordinateSystemDrawer
{
    public static void DrawCoordinateSystem(Graphics graphics, Point center, Font font, int scale, int xSize, int ySize)
    {
        var stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        var pen = new Pen(Color.Black, 1f);

        graphics.DrawLine(pen, center, center with { X = center.X * 2 });
        graphics.DrawLine(pen, center, center with { X = 0 });
        graphics.DrawLine(pen, center, center with { Y = 0 });
        graphics.DrawLine(pen, center, center with { Y = center.Y * 2 });

        for (var i = 1; i < xSize; i++)
        {
            graphics.DrawString($"{i}", font, Brushes.Black,
                new PointF(center.X + i * scale, center.Y + scale), stringFormat);
            graphics.DrawString($"{-i}", font, Brushes.Black,
                new PointF(center.X - i * scale, center.Y + scale), stringFormat);
        }

        for (var i = 1; i < ySize; i++)
        {
            graphics.DrawString($"{i}", font, Brushes.Black,
                new PointF(center.X - scale, center.Y - i * scale), stringFormat);
            graphics.DrawString($"{-i}", font, Brushes.Black,
                new PointF(center.X - scale, center.Y + i * scale), stringFormat);
        }
    }
}