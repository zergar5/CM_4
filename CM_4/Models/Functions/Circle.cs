namespace CM_4.Models.Functions;

public class Circle : Function, IEquatable<Circle>
{
    public double CenterX { get; set; }
    public double CenterY { get; set; }
    public double Radius { get; set; }

    public Circle()
    {
        CenterX = 0.0;
        CenterY = 0.0;
        Radius = 0.0;
    }

    public Circle(double centerX, double centerY, double radius)
    {
        CenterX = centerX;
        CenterY = centerY;
        Radius = radius;
    }

    public void SetCenter(double x, double y)
    {
        CenterX = x;
        CenterY = y;
    }

    public void SetRadius(double radius) => Radius = radius;

    public override double CalcFunction(double[] point)
    {
        return Math.Pow(point[0] - CenterX, 2) + Math.Pow(point[1] - CenterY, 2) - Math.Pow(Radius, 2);
    }

    public override double CalcDXFunction(double x)
    {
        return 2 * x - 2 * CenterX;
    }

    public override double CalcDYFunction(double y)
    {
        return 2 * y - 2 * CenterY;
    }

    public bool Equals(Circle? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(CenterX - other.CenterX) < eps && Math.Abs(CenterY - other.CenterY) < eps && Math.Abs(Radius - other.Radius) < eps;
    }
}