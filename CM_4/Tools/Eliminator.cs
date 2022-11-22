using CM_4.Models.Functions;

namespace CM_4.Tools;

public class Eliminator
{
    public static List<Function> Eliminate(List<Function> functions, double[] f, int n)
    {
        var absoluteValueOfRequiredFunctions = f
            .Select((item, index) => new KeyValuePair<int, double>(index, item))
            .OrderBy(absValue => Math.Abs(absValue.Value))
            .TakeLast(n)
            .Select(x => x.Key);
        var allFunctionsIndexes = functions
            .Select((_, index) => index);
        var requiredIndexes = allFunctionsIndexes
            .Select(index => index)
            .Intersect(absoluteValueOfRequiredFunctions
                .Select(index => index));
        var requiredFunctions = requiredIndexes
            .SelectMany(indexes => functions
                .Where((_, i) => i == indexes))
            .ToList();
        return requiredFunctions;
    }
}