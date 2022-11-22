namespace CM_4.Models.Functions;

public interface IFunction
{
    public double CalcFunction(double[] point);

    public double[] CalcDerivatives(double[] point);

    public double CalcDXFunction(double x);

    public double CalcDYFunction(double y);
}