namespace CM_4.Models.Functions;

public class Circle : Function, IEquatable<Circle>
{
    private double _centerX;
    private double _centerY;
    private double _radius;

    public Circle()
    {
        _centerX = 0.0;
        _centerY = 0.0;
        _radius = 0.0;
    }

    public Circle(double centerX, double centerY, double radius)
    {
        _centerX = centerX;
        _centerY = centerY;
        _radius = radius;
    }

    public void SetCenter(double x, double y)
    {
        _centerX = x;
        _centerY = y;
    }

    public void SetRadius(double radius) => _radius = radius;

    public override double CalcFunction(double[] point)
    {
        return Math.Pow(point[0] - _centerX, 2) + Math.Pow(point[1] - _centerY, 2) - Math.Pow(_radius, 2);
    }

    public override double CalcDXFunction(double x)
    {
        return 2 * x - 2 * _centerX;
    }

    public override double CalcDYFunction(double y)
    {
        return 2 * y - 2 * _centerY;
    }

    public bool Equals(Circle? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(_centerX - other._centerX) < eps && Math.Abs(_centerY - other._centerY) < eps && Math.Abs(_radius - other._radius) < eps;
    }
}