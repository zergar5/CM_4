namespace CM_4.Models.Functions;

public class Line : Function, IEquatable<Line>
{
    public double a { get; set; }
    public double b { get; set; }
    public double c { get; set; }

    public Line()
    {
        a = 0.0;
        b = 0.0;
        c = 0.0;
    }

    public Line(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void SetCoefficients(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public void SetC(double c) => this.c = c;

    public override double CalcFunction(double[] point)
    {
        return a * point[0] + b * point[1] + c;
    }

    public override double CalcDXFunction(double x)
    {
        return a;
    }

    public override double CalcDYFunction(double y)
    {
        return b;
    }

    public bool Equals(Line? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(a - other.a) < eps && Math.Abs(b - other.b) < eps && Math.Abs(c - other.c) < eps;
    }
}