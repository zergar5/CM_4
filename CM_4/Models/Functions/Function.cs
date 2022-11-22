namespace CM_4.Models.Functions;

public abstract class Function : IFunction
{
    public abstract double CalcFunction(double[] point);

    public virtual double[] CalcDerivatives(double[] point)
    {
        var derivatives = new[]
        {
            CalcDXFunction(point[0]),
            CalcDYFunction(point[1])
        };
        return derivatives;
    }
    public abstract double CalcDXFunction(double x);
    public abstract double CalcDYFunction(double y);
}