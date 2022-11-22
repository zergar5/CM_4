using CM_4.IO;
using CM_4.Models;
using CM_4.Models.Functions;
using CM_4.SymmetrizationVariants;
using CM_4.Tools.Calculators;

var pointI = new PointIO("../CM_4/Input/");
var pointO = new PointIO("../CM_4/Output/");
var parameterI = new ParametersIO("../CM_4/Input/");

var point = pointI.Read("point.txt");
var (eps1, eps2, maxIter) = parameterI.ReadParameters("parameters.txt");

var matrix = new Matrix();

var derivativeCalculator = new DerivativeCalculator();

var system = new List<Function>
{
    new Circle(2, 2, 2),
    new Circle(5, 2, 2),
    new Line(-1, -1, 5)
};

var result = new double[point.Length];
Array.Copy(point, result, point.Length);
result = Eliminate.SolveAnalytically(system, matrix, result, eps1, eps2, maxIter);
pointO.Write(result, "EliminateAnalytically.txt");

Array.Copy(point, result, point.Length);
result = Eliminate.SolveNumerically(system, matrix, result, eps1, eps2, maxIter, derivativeCalculator);
pointO.Write(result, "EliminateNumerically.txt");

Array.Copy(point, result, point.Length);
result = Transpose.SolveAnalytically(system, matrix, result, eps1, eps2, maxIter);
pointO.Write(result, "TransposeAnalytically.txt");

Array.Copy(point, result, point.Length);
result = Transpose.SolveNumerically(system, matrix, result, eps1, eps2, maxIter, derivativeCalculator);
pointO.Write(result, "TransposeNumerically.txt");