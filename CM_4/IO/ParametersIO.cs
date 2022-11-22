namespace CM_4.IO;

public class ParametersIO
{
    private readonly string _path;
    public ParametersIO(string path)
    {
        _path = path;
    }
    public (double, double, int) ReadParameters(string fileName)
    {
        using var streamReader = new StreamReader(_path + fileName);
        var paramsIn = streamReader.ReadLine().Replace('.', ',').Split(' ');
        var parameters = (double.Parse(paramsIn[0]), double.Parse(paramsIn[1]), int.Parse(paramsIn[2]));
        return parameters;
    }
}