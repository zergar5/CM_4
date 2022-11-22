namespace CM_4.Models.Functions;

public class Line : Function, IEquatable<Line>
{
    private double _a;
    private double _b;
    private double _c;

    public Line()
    {
        _a = 0.0;
        _b = 0.0;
        _c = 0.0;
    }

    public Line(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public void SetCoefficients(double a, double b)
    {
        _a = a;
        _b = b;
    }

    public void SetC(double c) => _c = c;

    public override double CalcFunction(double[] point)
    {
        return _a * point[0] + _b * point[1] + _c;
    }

    public override double CalcDXFunction(double x)
    {
        return _a;
    }

    public override double CalcDYFunction(double y)
    {
        return _b;
    }

    public bool Equals(Line? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(_a - other._a) < eps && Math.Abs(_b - other._b) < eps && Math.Abs(_c - other._c) < eps;
    }
}