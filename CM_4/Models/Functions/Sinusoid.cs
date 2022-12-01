namespace CM_4.Models.Functions;

public class Sinusoid : Function, IEquatable<Sinusoid>
{
    public double Shift { get; set; }
    public double Amplitude { get; set; }
    public double Frequency { get; set; }
    public double NegativeShift { get; set; }

    public Sinusoid()
    {
        Shift = 0.0;
        Amplitude = 0.0;
        Frequency = 0.0;
        NegativeShift = 0.0;
    }

    public Sinusoid(double shift, double amplitude, double frequency, double negativeShift)
    {
        Shift=shift;
        Amplitude=amplitude;
        Frequency=frequency;
        NegativeShift=negativeShift;
    }

    public void SetParameters(double shift, double amplitude, double frequency, double negativeShift)
    {
        Shift=shift;
        Amplitude=amplitude;
        Frequency=frequency;
        NegativeShift=negativeShift;
    }

    public override double CalcFunction(double[] point)
    {
        return Shift + Amplitude * Math.Sin(Frequency * point[0] + NegativeShift) - point[1];
    }

    public override double CalcDXFunction(double x)
    {
        return Amplitude * Frequency * Math.Cos(Frequency * x + NegativeShift);
    }

    public override double CalcDYFunction(double y)
    {
        return -1;
    }

    public bool Equals(Sinusoid? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(Shift - other.Shift) < eps && Math.Abs(Amplitude - other.Amplitude) < eps && Math.Abs(Frequency - other.Frequency) < eps && Math.Abs(NegativeShift - other.NegativeShift) < eps;
    }
}