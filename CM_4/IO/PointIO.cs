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

    public double[] Read(string fileName)
    {
        using var streamReader = new StreamReader(_path + fileName);
        var text = streamReader.ReadLine().Replace('.', ',');
        var point = text.Split(' ').Select(double.Parse).ToArray();
        if (point.Length > 3) throw new Exception("Too many variables");

        return point;
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