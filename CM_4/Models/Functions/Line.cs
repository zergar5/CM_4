namespace CM_4.Models.Functions;

public class Line : Function, IEquatable<Line>
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Line()
    {
        A = 0.0;
        B = 0.0;
        C = 0.0;
    }

    public Line(double a, double b, double c)
    {
        this.A = a;
        this.B = b;
        this.C = c;
    }

    public void SetCoefficients(double a, double b)
    {
        this.A = a;
        this.B = b;
    }

    public void SetC(double c) => this.C = c;

    public override double CalcFunction(double[] point)
    {
        return A * point[0] + B * point[1] + C;
    }

    public override double CalcDXFunction(double x)
    {
        return A;
    }

    public override double CalcDYFunction(double y)
    {
        return B;
    }

    public bool Equals(Line? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(A - other.A) < eps && Math.Abs(B - other.B) < eps && Math.Abs(C - other.C) < eps;
    }
}