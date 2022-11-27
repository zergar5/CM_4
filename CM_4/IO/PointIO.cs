using System.Globalization;

namespace CM_4.IO;

public class PointIO
{
    private static readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");
    private readonly string _path;

    public PointIO(string path)
    {
        _path = path;
    }

    public void Write(double[] vector, string fileName)
    {
        using var streamWriter = new StreamWriter(_path + fileName);
        foreach (var element in vector)
        {
            streamWriter.WriteLine(element.ToString("0.00000000000000e+00", _culture));
        }
    }
}