namespace CM_4.Models.Functions;

public class Sinusoid : Function, IEquatable<Sinusoid>
{
    private double _shift;
    private double _amplitude;
    private double _frequency;
    private double _negativeShift;

    public Sinusoid()
    {
        _shift = 0.0;
        _amplitude = 0.0;
        _frequency = 0.0;
        _negativeShift = 0.0;
    }

    public Sinusoid(double shift, double amplitude, double frequency, double negativeShift)
    {
        _shift=shift;
        _amplitude=amplitude;
        _frequency=frequency;
        _negativeShift=negativeShift;
    }

    public void SetParameters(double shift, double amplitude, double frequency, double negativeShift)
    {
        _shift=shift;
        _amplitude=amplitude;
        _frequency=frequency;
        _negativeShift=negativeShift;
    }

    public override double CalcFunction(double[] point)
    {
        return _shift + _amplitude * Math.Sin(_frequency * point[0] + _negativeShift) - point[1];
    }

    public override double CalcDXFunction(double x)
    {
        return _amplitude * _frequency * Math.Cos(_frequency * x + _negativeShift);
    }

    public override double CalcDYFunction(double y)
    {
        return -1;
    }

    public bool Equals(Sinusoid? other)
    {
        const double eps = 10.0e-16;
        return Math.Abs(_shift - other._shift) < eps && Math.Abs(_amplitude - other._amplitude) < eps && Math.Abs(_frequency - other._frequency) < eps && Math.Abs(_negativeShift - other._negativeShift) < eps;
    }
}