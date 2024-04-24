using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kudiyarov.YandexAlgorithms5.BA;

public abstract class Program
{
    public static void Main()
    {
        var rawInput = File.ReadLines("input.txt");
        var result = Solution(rawInput);
        File.WriteAllText("output.txt", result);
    }

    public static string Solution(IEnumerable<string> rawInput)
    {
        var points = GetPoints(rawInput);

        var minX = int.MaxValue;
        var minY = int.MaxValue;
        var maxX = int.MinValue;
        var maxY = int.MinValue;

        foreach (var point in points)
        {
            if (point.X < minX)
            {
                minX = point.X;
            }

            if (point.X > maxX)
            {
                maxX = point.X;
            }

            if (point.Y < minY)
            {
                minY = point.Y;
            }

            if (point.Y > maxY)
            {
                maxY = point.Y;
            }
        }

        var minPoint = new Point(minX, minY);
        var maxPoint = new Point(maxX, maxY);

        return $"{minPoint.X} {minPoint.Y} {maxPoint.X} {maxPoint.Y}";
    }

    private static IEnumerable<Point> GetPoints(IEnumerable<string> input)
    {
        var points = input
            .Skip(1)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(GetPoint);

        return points;
    }

    private static Point GetPoint(string line)
    {
        var splittedLine = line.Split();

        var rawX = splittedLine[0];
        var rawY = splittedLine[1];

        var x = int.Parse(rawX);
        var y = int.Parse(rawY);

        var point = new Point(x, y);

        return point;
    }
}

public readonly record struct Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}