using CM_4.Models.Functions;
using System.Text;

namespace CM_4_Graphics;

public class SystemRepresentator
{
    public static string RepresentLine(Line line, double eps)
    {
        var stringBuilder = new StringBuilder();
        if (Math.Abs(line.A - 1.0) < eps) stringBuilder.Append("x ");
        else if (Math.Abs(line.A + 1.0) < eps) stringBuilder.Append("-x ");
        else if (Math.Abs(line.A) > eps) stringBuilder.Append($"{line.A}x ");

        if (Math.Abs(line.A) > eps)
        {
            if (Math.Abs(line.B - 1.0) < eps) stringBuilder.Append("+ y ");
            else if (Math.Abs(line.B + 1.0) < eps) stringBuilder.Append("- y ");
        }
        else
        {
            if (Math.Abs(line.B - 1.0) < eps) stringBuilder.Append("y ");
            else if (Math.Abs(line.B + 1.0) < eps) stringBuilder.Append("-y ");
        }

        if (Math.Abs(line.B) > eps && Math.Abs(Math.Abs(line.B) - 1.0) > eps)
        {
            IdentifySign(stringBuilder, line.B);
            stringBuilder.Append($" {Math.Abs(line.B)}y ");
        }

        if (Math.Abs(line.C) > eps)
        {
            IdentifySign(stringBuilder, line.C);
            stringBuilder.AppendLine($" {Math.Abs(line.C)} = 0");
        }
        else
        {
            stringBuilder.AppendLine(" = 0");
        }

        return stringBuilder.ToString();
    }

    public static string RepresentCircle(Circle circle, double eps)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("(x");
        if (Math.Abs(circle.CenterX) < eps)
        {
            stringBuilder.Append(")^2 + (y");
        }
        else
        {
            IdentifyInvertSign(stringBuilder, circle.CenterX);
            stringBuilder.Append($"{Math.Abs(circle.CenterX)})^2 + (y");
        }

        if (Math.Abs(circle.CenterY) < eps)
        {
            stringBuilder.Append(")^2");
        }
        else
        {
            IdentifyInvertSign(stringBuilder, circle.CenterY);
            stringBuilder.Append($"{Math.Abs(circle.CenterY)})^2");
        }

        stringBuilder.AppendLine($" - {Math.Pow(circle.Radius, 2)} = 0");
        return stringBuilder.ToString();
    }

    public static string RepresentSinusoid(Sinusoid sinusoid, double eps)
    {
        var stringBuilder = new StringBuilder();
        if (Math.Abs(sinusoid.Shift) > eps)
        {
            stringBuilder.Append($"{sinusoid.Shift} ");
            if (Math.Abs(sinusoid.Amplitude) < eps)
            {
                stringBuilder.AppendLine("- y = 0");
            }
            else
            {
                if (Math.Abs(Math.Abs(sinusoid.Amplitude) - 1.0) > eps)
                {
                    IdentifySign(stringBuilder, sinusoid.Amplitude);
                    stringBuilder.Append($" {Math.Abs(sinusoid.Amplitude)}sin(");
                }
                else if (Math.Abs(sinusoid.Amplitude - 1.0) < eps)
                {
                    stringBuilder.Append("+ sin(");
                }
                else if (Math.Abs(sinusoid.Amplitude + 1.0) < eps)
                {
                    stringBuilder.Append("- sin(");
                }

                if (Math.Abs(sinusoid.Frequency) < eps)
                {
                    if (Math.Abs(sinusoid.NegativeShift) < eps)
                    {
                        stringBuilder.AppendLine("0) - y = 0");
                    }
                    else if (Math.Abs(sinusoid.NegativeShift - 1.0) < eps)
                    {
                        stringBuilder.AppendLine($"{Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                    else if (Math.Abs(sinusoid.NegativeShift + 1.0) < eps)
                    {
                        IdentifySign(stringBuilder, sinusoid.NegativeShift);
                        stringBuilder.AppendLine($"{Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                        IdentifySign(stringBuilder, sinusoid.NegativeShift);
                        stringBuilder.AppendLine($"{Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                }
                else
                {
                    if (Math.Abs(sinusoid.Frequency - 1.0) < eps)
                    {
                        stringBuilder.Append("x");
                    }
                    else if (Math.Abs(sinusoid.Frequency + 1.0) < eps)
                    {
                        stringBuilder.Append("-x");
                    }
                    else
                    {
                        stringBuilder.Append($"{sinusoid.Frequency}x");
                    }

                    if (Math.Abs(sinusoid.NegativeShift) < eps)
                    {
                        stringBuilder.AppendLine(") - y = 0");
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                        IdentifySign(stringBuilder, sinusoid.NegativeShift);
                        stringBuilder.AppendLine($" {Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                }
            }
        }
        else
        {
            if (Math.Abs(sinusoid.Amplitude) < eps)
            {
                stringBuilder.AppendLine("- y = 0");
            }
            else
            {
                if (Math.Abs(Math.Abs(sinusoid.Amplitude) - 1.0) > eps)
                {
                    IdentifySign(stringBuilder, sinusoid.Amplitude);
                    stringBuilder.Append($" {Math.Abs(sinusoid.Amplitude)}sin(");
                }
                else if (Math.Abs(sinusoid.Amplitude - 1.0) < eps)
                {
                    stringBuilder.Append("sin(");
                }
                else if (Math.Abs(sinusoid.Amplitude + 1.0) < eps)
                {
                    stringBuilder.Append("-sin(");
                }

                if (Math.Abs(sinusoid.Frequency) < eps)
                {
                    if (Math.Abs(sinusoid.NegativeShift) < eps)
                    {
                        stringBuilder.AppendLine("0) - y = 0");
                    }
                    else if (Math.Abs(sinusoid.NegativeShift - 1.0) < eps)
                    {
                        stringBuilder.AppendLine($"{Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                    else if (Math.Abs(sinusoid.NegativeShift + 1.0) < eps)
                    {
                        IdentifySign(stringBuilder, sinusoid.NegativeShift);
                        stringBuilder.AppendLine($"{Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                        IdentifySign(stringBuilder, sinusoid.NegativeShift);
                        stringBuilder.AppendLine($"{Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                }
                else
                {
                    if (Math.Abs(sinusoid.Frequency - 1.0) < eps)
                    {
                        stringBuilder.Append("x");
                    }
                    else if (Math.Abs(sinusoid.Frequency + 1.0) < eps)
                    {
                        stringBuilder.Append("-x");
                    }
                    else
                    {
                        stringBuilder.Append($"{sinusoid.Frequency}x");
                    }

                    if (Math.Abs(sinusoid.NegativeShift) < eps)
                    {
                        stringBuilder.AppendLine(") - y = 0");
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                        IdentifySign(stringBuilder, sinusoid.NegativeShift);
                        stringBuilder.AppendLine($" {Math.Abs(sinusoid.NegativeShift)}) - y = 0");
                    }
                }
            }
        }

        return stringBuilder.ToString();
    }

    public static void IdentifySign(StringBuilder stringBuilder, double number)
    {
        var sign = Math.Sign(number);
        switch (sign)
        {
            case -1:
                stringBuilder.Append("-");
                break;
            case 1:
                stringBuilder.Append("+");
                break;
            case 0:
                stringBuilder.Append("+");
                break;
        }
    }

    public static void IdentifyInvertSign(StringBuilder stringBuilder, double number)
    {
        var sign = Math.Sign(number);
        switch (sign)
        {

            case 1:
                stringBuilder.Append("-");
                break;
            case 0:
                stringBuilder.Append("-");
                break;
            case -1:
                stringBuilder.Append("+");
                break;
        }
    }
}