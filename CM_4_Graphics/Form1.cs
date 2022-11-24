using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Net.Http.Headers;
using System.Text;
using CM_4.Models.Functions;
using CM_4.SymmetrizationVariants;

namespace CM_4_Graphics;

public partial class Form1 : Form
{
    private SystemProvider _systemProvider;
    private IMethod? _method;
    private Line _line;
    private Circle _circle;
    private Sinusoid _sinusoid;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        _systemProvider = new SystemProvider();
    }

    private void SolveButton_Click(object sender, EventArgs e)
    {
        if (_method == null || _systemProvider.Functions == null) return;
        var graphics = GraphicBox.CreateGraphics();
        graphics.Clear(Color.White);

        const int scale = 33;

        var font = new Font("TimesNewRoman", 9, FontStyle.Regular);
        var stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;
        var center = new Point(GraphicBox.Width/2, GraphicBox.Height/2);
        var pen = new Pen(Color.Black, 1f);

        graphics.DrawLine(pen, center, center with { X = GraphicBox.Width });
        graphics.DrawLine(pen, center, center with { X = 0 });
        graphics.DrawLine(pen, center, center with { Y = 0 });
        graphics.DrawLine(pen, center, center with { Y = GraphicBox.Height });

        for (var i = 1; i < Width; i++)
        {
            graphics.DrawString($"{i}", font, Brushes.Black,
                new Point(center.X + i * scale, center.Y + 10), stringFormat);
            graphics.DrawString($"{-i}", font, Brushes.Black,
                new Point(center.X - i * scale, center.Y + 10), stringFormat);
            graphics.DrawString($"{i}", font, Brushes.Black,
                new Point(center.X - 10, center.Y - i * scale), stringFormat);
            graphics.DrawString($"{-i}", font, Brushes.Black,
                new Point(center.X - 10, center.Y + i * scale), stringFormat);

        }

        foreach (var function in _systemProvider.Functions)
        {
            switch (function)
            {
                case Line line:
                    pen = new Pen(Color.Purple, 3f);
                    var a = line.C / -line.A;
                    var b = line.C / -line.B;
                    var x0 = (float)center.X;
                    var y0 = (float)(center.Y - b * scale);

                    graphics.DrawLine(pen, new PointF(x0, y0), new PointF((float)(x0 - GraphicBox.Width * a * scale), (float)(y0 - GraphicBox.Width * b * scale)));
                    graphics.DrawLine(pen, new PointF(x0, y0), new PointF((float)(x0 + GraphicBox.Width * a * scale), (float)(y0 + GraphicBox.Width * b * scale)));
                    break;

                case Circle circle:
                    pen = new Pen(Color.Blue, 3f);
                    var upperLeftCorner = new PointF((float)(center.X + (circle.CenterX - circle.Radius) * scale), (float)(center.Y - (circle.CenterY + circle.Radius) * scale));
                    var d = (float)(circle.Radius * 2 * scale);
                    var rectangle = new RectangleF(upperLeftCorner.X, upperLeftCorner.Y, d, d);
                    graphics.DrawEllipse(pen, rectangle);
                    break;

                case Sinusoid sinusoid:
                    pen = new Pen(Color.LimeGreen, 2f);
                    var leftPoints = new PointF[GraphicBox.Width];
                    var rightPoints = new PointF[GraphicBox.Width];
                    for (var i = 0; i < GraphicBox.Width; i++)
                    {
                        leftPoints[i] = new PointF(i * scale,
                            (float)(center.Y + sinusoid.Shift * scale + sinusoid.Amplitude *
                                Math.Sin(sinusoid.Frequency * i + sinusoid.NegativeShift) * scale));
                    }

                    graphics.DrawLines(pen, leftPoints);
                    graphics.DrawLines(pen, rightPoints);
                    break;
            }
        }

        switch (_method)
        {
            case EliminateAnalytically eliminateAnalytically:
                
                var (points, norms) = MethodLauncher.LaunchMethod(eliminateAnalytically, _systemProvider.Functions);
                
                var drawPoints = new PointF[points.Count];
                for (var i = 0; i < points.Count; i++)
                {
                    drawPoints[i] = new PointF((float)(center.X + points[i][0] * scale),
                        (float)(center.Y - points[i][1] * scale));
                }

                var linearGradient = new LinearGradientBrush(new PointF(drawPoints[0].X - 25, drawPoints[0].Y - 25),
                    new PointF(drawPoints[^1].X + 25, drawPoints[^1].Y + 25), Color.Red, Color.DarkOrange);
                pen = new Pen(linearGradient, 3f);
                graphics.DrawLines(pen, drawPoints);
                break;
            case TransposeAnalytically transposeAnalytically:
                (points, norms) = MethodLauncher.LaunchMethod(transposeAnalytically, _systemProvider.Functions);

                drawPoints = new PointF[points.Count];
                for (var i = 0; i < points.Count; i++)
                {
                    drawPoints[i] = new PointF((float)(center.X + points[i][0] * scale),
                        (float)(center.Y - points[i][1] * scale));
                }
                linearGradient = new LinearGradientBrush(new PointF(drawPoints[0].X - 25, drawPoints[0].Y - 25),
                    new PointF(drawPoints[^1].X + 25, drawPoints[^1].Y + 25), Color.Red, Color.DarkOrange);
                pen = new Pen(linearGradient, 3f);
                graphics.DrawLines(pen, drawPoints);
                break;
            case TransposeNumerically transposeNumerically:
                (points, norms) = MethodLauncher.LaunchMethod(transposeNumerically, _systemProvider.Functions);

                drawPoints = new PointF[points.Count];
                for (var i = 0; i < points.Count; i++)
                {
                    drawPoints[i] = new PointF((float)(center.X + points[i][0] * scale),
                        (float)(center.Y - points[i][1] * scale));
                }
                graphics.DrawLines(pen, drawPoints);
                linearGradient = new LinearGradientBrush(new PointF(drawPoints[0].X - 25, drawPoints[0].Y - 25),
                    new PointF(drawPoints[^1].X + 25, drawPoints[^1].Y + 25), Color.Red, Color.DarkOrange);
                pen = new Pen(linearGradient, 3f);
                graphics.DrawLines(pen, drawPoints);
                break;
        }
    }

    private void FunctionsBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedFunction = FunctionsBox.SelectedItem.ToString();
        switch (selectedFunction)
        {
            case "Line":
                _line = new Line();
                LineBox.Visible = true;
                CircleBox.Visible = false;
                SinusoidBox.Visible = false;
                break;
            case "Circle":
                _circle = new Circle();
                LineBox.Visible = false;
                CircleBox.Visible = true;
                SinusoidBox.Visible = false;
                break;
            case "Sinusoid":
                _sinusoid = new Sinusoid();
                LineBox.Visible = false;
                CircleBox.Visible = false;
                SinusoidBox.Visible = true;
                break;
        }
    }

    private void MethodsBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedMethod = MethodsBox.SelectedItem.ToString();
        _method = selectedMethod switch
        {
            "EliminateAnalytically" => new EliminateAnalytically(),
            "TransposeAnalytically" => new TransposeAnalytically(),
            "TransposeNumerically" => new TransposeNumerically(),
            _ => _method
        };
    }

    private void ATextBox_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(ATextBox.Text, out var a))
        {
            _line.A = a;
        }
    }

    private void BTextBox_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(BTextBox.Text, out var b))
        {
            _line.B = b;
        }
    }

    private void CTextBox_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(CTextBox.Text, out var c))
        {
            _line.C = c;
        }
    }

    private void CenterXBox_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(CenterXBox.Text, out var centerX))
        {
            _circle.CenterX = centerX;
        }
    }

    private void CenterYBox_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(CenterYBox.Text, out var centerY))
        {
            _circle.CenterY = centerY;
        }
    }

    private void RadiusBox_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(RadiusBox.Text, out var radius))
        {
            _circle.Radius = radius;
        }
    }

    private void Shift_TextChanged(object? sender, EventArgs e)
    {
        if (double.TryParse(ShiftBox.Text, out var shift))
        {
            _sinusoid.Shift = shift;
        }
    }

    private void Amplitude_TextChanged(object? sender, EventArgs e)
    {
        if (double.TryParse(AmplitudeBox.Text, out var amplitude))
        {
            _sinusoid.Amplitude = amplitude;
        }
    }

    private void Frequency_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(FrequencyBox.Text, out var frequency))
        {
            _sinusoid.Frequency = frequency;
        }
    }

    private void NegativeShift_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(NegativeShiftBox.Text, out var negativeShift))
        {
            _sinusoid.NegativeShift = negativeShift;
        }
    }

    private void AddFunctionButton_Click(object sender, EventArgs e)
    {
        if (FunctionsBox.SelectedItem == null) return;
        var selectedFunction = FunctionsBox.SelectedItem.ToString();
        var stringBuilder = new StringBuilder();
        var text = SystemTextBox.Text;
        switch (selectedFunction)
        {
            case "Line":
                _systemProvider.AddFunction(_line);
                stringBuilder.Append($"{_line.A}x");
                SignAdder.IdentifySign(stringBuilder, _line.B);
                stringBuilder.Append($"{Math.Abs(_line.B)}y");
                SignAdder.IdentifySign(stringBuilder, _line.C);
                stringBuilder.AppendLine($"{Math.Abs(_line.C)} = 0");
                SystemTextBox.Text = text + stringBuilder;
                _line = new Line(_line.A, _line.B, _line.C);
                break;
            case "Circle":
                _systemProvider.AddFunction(_circle);
                stringBuilder.Append("(x");
                SignAdder.IdentifyInvertSign(stringBuilder, _circle.CenterX);
                stringBuilder.Append($"{Math.Abs(_circle.CenterX)})^2 + (y");
                SignAdder.IdentifyInvertSign(stringBuilder, _circle.CenterY);
                stringBuilder.Append($"{Math.Abs(_circle.CenterY)})^2");
                SignAdder.IdentifyInvertSign(stringBuilder, _circle.Radius);
                stringBuilder.AppendLine($"{Math.Pow(_circle.Radius, 2)} = 0");
                SystemTextBox.Text = text + stringBuilder;
                _circle = new Circle(_circle.CenterX, _circle.CenterY, _circle.Radius);
                break;
            case "Sinusoid":
                _systemProvider.AddFunction(_sinusoid);
                stringBuilder.Append($"{_sinusoid.Shift}");
                SignAdder.IdentifySign(stringBuilder, _sinusoid.Amplitude);
                stringBuilder.Append($"{Math.Abs(_sinusoid.Amplitude)}sin(");
                stringBuilder.Append($"{_sinusoid.Frequency}x");
                SignAdder.IdentifySign(stringBuilder, _sinusoid.NegativeShift);
                stringBuilder.AppendLine($"{Math.Abs(_sinusoid.NegativeShift)}) - y = 0");
                SystemTextBox.Text = text + stringBuilder;
                _sinusoid = new Sinusoid(_sinusoid.Shift, _sinusoid.Amplitude, _sinusoid.Frequency,
                    _sinusoid.NegativeShift);
                break;
        }

    }

    private void DeleteFunctionButton_Click(object sender, EventArgs e)
    {
        var text = SystemTextBox.Text;
        if (text == null) return;
        var index = text.IndexOf("\n");
        SystemTextBox.Text = text.Remove(0, index + 1);
        _systemProvider.DeleteFunction();
    }

    public static void GiveInfo()
    {

    }
}