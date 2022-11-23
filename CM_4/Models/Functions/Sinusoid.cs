namespace CM_4.Models.Functions;

public class Sinusoid : Function, IEquatable<Sinusoid>
{
    public double shift;
    public double amplitude;
    public double frequency;
    public double negativeShift;

    public Sinusoid()
    {
        shift = 0.0;
        amplitude = 0.0;
        frequency = 0.0;
        negativeShift = 0.0;
    }

    public Sinusoid(double shift, double amplitude, double frequency, double negativeShift)
    {
        this.shift=shift;
        this.amplitude=amplitude;
        this.frequency=frequency;
        this.negativeShift=negativeShift;
    }

    public void SetParameters(double shift, double amplitude, double frequency, double negativeShift)
    {
        this.shift=shift;
        this.amplitude=amplitude;
        this.frequency=frequency;
        this.negativeShift=negativeShift;
    }

    public override double CalcFunction(double[] point)
    {
        return shift + amplitude * Math.Sin(frequency * point[0] + negativeShift) - point[1];
    }

    public override double CalcDXFunction(double x)
    {
        return amplitude * frequency * Math.Cos(frequency * x + negativeShift);
    }

    public override double CalcDYFunction(double y)
    {
        return -1;
    }

    public bool Equals(Sinusoid? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(shift - other.shift) < eps && Math.Abs(amplitude - other.amplitude) < eps && Math.Abs(frequency - other.frequency) < eps && Math.Abs(negativeShift - other.negativeShift) < eps;
    }
}