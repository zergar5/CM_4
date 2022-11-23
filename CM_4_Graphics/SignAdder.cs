using System.Text;

namespace CM_4_Graphics;

public class SignAdder
{
    public static void IdentifySign(StringBuilder stringBuilder, double number)
    {
        var sign = Math.Sign(number);
        switch (sign)
        {
            case -1:
                stringBuilder.Append(" - ");
                break;
            case 1:
                stringBuilder.Append(" + ");
                break;
            case 0:
                stringBuilder.Append(" + ");
                break;
        }
    }

    public static void IdentifyInvertSign(StringBuilder stringBuilder, double number)
    {
        var sign = Math.Sign(number);
        switch (sign)
        {

            case 1:
                stringBuilder.Append(" - ");
                break;
            case 0:
                stringBuilder.Append(" - ");
                break;
            case -1:
                stringBuilder.Append(" + ");
                break;
        }
    }
}