using CM_4.Models.Functions;

namespace CM_4_Graphics;

public class SystemProvider
{
    public List<Function>? Functions { get; }

    public SystemProvider()
    {
        Functions = new List<Function>();
    }

    public void AddFunction(Function function)
    {
        Functions.Add(function);
    }

    public void DeleteFunction()
    {
        if(Functions.Count != 0) Functions.RemoveAt(0);
    }
}