using CM_4.IO;
using CM_4.Models.Functions;
using CM_4.SymmetrizationVariants;
using Matrix = CM_4.Models.Matrix;

namespace CM_4_Graphics;

public partial class SNUForm : Form
{
    private SystemProvider _systemProvider;
    private Method? _method;
    private double[] _point;
    private const double Eps = 10.0e-16;

    public SNUForm()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        _systemProvider = new SystemProvider();
    }

    private void SolveButton_Click(object sender, EventArgs e)
    {
        var system = _systemProvider.Functions;
        if (system == null || system.Count < 2 || _method == null) return;

        var graphics = GraphicBox.CreateGraphics();
        graphics.Clear(Color.White);

        const int scale = 29;
        const int xSize = 17;
        const int ySize = 8;

        var center = new Point(GraphicBox.Width / 2, GraphicBox.Height / 2);

        var font = new Font("TimesNewRoman", 9, FontStyle.Regular);

        var gradationLegend = GradationLegendBox.CreateGraphics();
        gradationLegend.Clear(Color.White);

        GradationDrawer.DrawGradation(graphics, system, center, xSize, ySize, scale, gradationLegend, GradationLegendBox.Width, GradationLegendBox.Height, font);

        CoordinateSystemDrawer.DrawCoordinateSystem(graphics, center, font, scale, xSize, ySize);

        if (Controls.Count > 21)
        {
            for (var i = 0; i < system.Count * 2; i++)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
        }

        SystemDrawer.X0 = SolveButton.Location.X + SolveButton.Width - 70;
        SystemDrawer.Y0 = SolveButton.Location.Y + SolveButton.Height + 10;
        SystemDrawer.FunctionNumber = 1;
        SystemDrawer.Font = font;

        var pen = new Pen(Color.FromArgb(255, 3, 4), 3f);

        var intersectionLabel = new Label
        {
            Location = new Point(SystemDrawer.X0, SystemDrawer.Y0),
            Size = new Size(70, 20),
            Text = "Intersection",
            Font = Font
        };
        SystemDrawer.Y0 += 20;
        var intersectionColor = new PictureBox
        {
            Location = new Point(SystemDrawer.X0, SystemDrawer.Y0),
            Size = new Size(70, 5),
            BackColor = pen.Color
        };
        SystemDrawer.Y0 += 5;

        Controls.Add(intersectionLabel);
        Controls.Add(intersectionColor);

        foreach (var function in system)
        {
            switch (function)
            {
                case Line line:
                    var (functionLabel, functionColor) = (SystemDrawer.DrawLine(graphics, line, center, scale, Eps, xSize, ySize));
                    Controls.Add(functionLabel);
                    Controls.Add(functionColor);
                    break;

                case Circle circle:
                    (functionLabel, functionColor) = (SystemDrawer.DrawCircle(graphics, circle, center, scale));
                    Controls.Add(functionLabel);
                    Controls.Add(functionColor);
                    break;

                case Sinusoid sinusoid:
                    (functionLabel, functionColor) = (SystemDrawer.DrawSinusoid(graphics, sinusoid, center, scale));
                    Controls.Add(functionLabel);
                    Controls.Add(functionColor);
                    break;
            }
        }

        if (_point == null) return;
        {
            var pointO = new PointIO("../CM_4/Output/");
            var parameterI = new ParametersIO("../CM_4/Input/");

            var matrix = new Matrix();

            var (eps1, eps2, maxIter) = parameterI.ReadParameters("parameters.txt");

            var point = new double[_point.Length];

            var i = 1;

            var startPoint = new PointF((float)(center.X + _point[0] * scale),
                (float)(center.Y - _point[1] * scale));

            foreach (var iteration in
                     _method.Solve(system, matrix, _point, eps1, eps2, maxIter))
            {
                IterationInfoBox.Text = CourseHolder.GetInfo(i++, iteration);
                IterationInfoBox.Update();

                point = iteration.point;
                var drawPoint = new PointF((float)(center.X + point[0] * scale),
                    (float)(center.Y - point[1] * scale));
                graphics.DrawLine(pen, startPoint, drawPoint);
                startPoint = drawPoint;
            }

            CourseHolder.DrawInfo(graphics, startPoint, point, font, pen);

            pointO.Write(point, $"{_method.GetType().Name}.txt");
        }
    }

    private void FunctionsBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedFunction = FunctionsBox.SelectedItem.ToString();
        switch (selectedFunction)
        {
            case "Line":
                LineBox.Visible = true;
                CircleBox.Visible = false;
                SinusoidBox.Visible = false;
                break;
            case "Circle":
                LineBox.Visible = false;
                CircleBox.Visible = true;
                SinusoidBox.Visible = false;
                break;
            case "Sinusoid":
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

    private void AddFunctionButton_Click(object sender, EventArgs e)
    {
        if (FunctionsBox.SelectedItem == null) return;
        var selectedFunction = FunctionsBox.SelectedItem.ToString();

        var functionText = "";
        var text = SystemTextBox.Text;

        switch (selectedFunction)
        {
            case "Line":
                if (!double.TryParse(ATextBox.Text, out var a)) a = 0.0;
                if (!double.TryParse(BTextBox.Text, out var b)) b = 0.0;
                if (!double.TryParse(CTextBox.Text, out var c)) c = 0.0;
                if (Math.Abs(a) < Eps && Math.Abs(b) < Eps) return;

                var line = new Line(a, b, c);
                _systemProvider.AddFunction(line);

                functionText = SystemRepresentator.RepresentLine(line, Eps);
                break;
            case "Circle":
                if (!double.TryParse(CenterXBox.Text, out var centerX)) centerX = 0.0;
                if (!double.TryParse(CenterYBox.Text, out var centerY)) centerY = 0.0;
                if (!double.TryParse(RadiusBox.Text, out var radius)) radius = 0.0;
                if (Math.Abs(radius) < Eps || radius < Eps) return;

                var circle = new Circle(centerX, centerY, radius);
                _systemProvider.AddFunction(circle);

                functionText = SystemRepresentator.RepresentCircle(circle, Eps);
                break;
            case "Sinusoid":
                if (!double.TryParse(ShiftBox.Text, out var shift)) shift = 0.0;
                if (!double.TryParse(AmplitudeBox.Text, out var amplitude)) amplitude = 0.0;
                if (!double.TryParse(FrequencyBox.Text, out var frequency)) frequency = 0.0;
                if (!double.TryParse(NegativeShiftBox.Text, out var negativeShift)) negativeShift = 0.0;

                var sinusoid = new Sinusoid(shift, amplitude, frequency, negativeShift);
                _systemProvider.AddFunction(sinusoid);

                functionText = SystemRepresentator.RepresentSinusoid(sinusoid, Eps);
                break;
        }
        SystemTextBox.Text = text + functionText;
    }

    private void DeleteFunctionButton_Click(object sender, EventArgs e)
    {
        var text = SystemTextBox.Text;
        if (text == null) return;
        var index = text.IndexOf("\n");
        SystemTextBox.Text = text.Remove(0, index + 1);
        _systemProvider.DeleteFunction();
    }

    private void PointButton_Click(object sender, EventArgs e)
    {
        if (!double.TryParse(XTextBox.Text, out var x)) x = 0.0;
        if (!double.TryParse(YTextBox.Text, out var y)) y = 0.0;
        _point = new[] { x, y };
    }
}