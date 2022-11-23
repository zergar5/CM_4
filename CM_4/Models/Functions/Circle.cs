namespace CM_4.Models.Functions;

public class Circle : Function, IEquatable<Circle>
{
    public double centerX;
    public double centerY;
    public double radius;

    public Circle()
    {
        centerX = 0.0;
        centerY = 0.0;
        radius = 0.0;
    }

    public Circle(double centerX, double centerY, double radius)
    {
        this.centerX = centerX;
        this.centerY = centerY;
        this.radius = radius;
    }

    public void SetCenter(double x, double y)
    {
        centerX = x;
        centerY = y;
    }

    public void SetRadius(double radius) => this.radius = radius;

    public override double CalcFunction(double[] point)
    {
        return Math.Pow(point[0] - centerX, 2) + Math.Pow(point[1] - centerY, 2) - Math.Pow(radius, 2);
    }

    public override double CalcDXFunction(double x)
    {
        return 2 * x - 2 * centerX;
    }

    public override double CalcDYFunction(double y)
    {
        return 2 * y - 2 * centerY;
    }

    public bool Equals(Circle? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(centerX - other.centerX) < eps && Math.Abs(centerY - other.centerY) < eps && Math.Abs(radius - other.radius) < eps;
    }
}