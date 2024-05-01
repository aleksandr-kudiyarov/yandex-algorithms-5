using System.Collections.Generic;
using System.IO;

namespace Kudiyarov.YandexAlgorithms5.BD;

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
        var points = GetInput(rawInput);

        var perimeter = 0;

        var dick = new Dictionary<Point, int>();
        
        foreach (var point in points)
        {
            var a = point with { X = point.X - 1 };
            var b = point with { X = point.X + 1 };
            var c = point with { Y = point.Y - 1 };
            var d = point with { Y = point.Y + 1 };

            TryAdd(dick, a);
            TryAdd(dick, b);
            TryAdd(dick, c);
            TryAdd(dick, d);

            dick.TryGetValue(point, out var n);
            var temp = 4 - n * 2;

            perimeter += temp;
        }

        return perimeter.ToString();
    }

    private static void TryAdd(Dictionary<Point, int> dick, Point point)
    {
        dick.TryAdd(point, 0);
        dick[point]++;
    }
    

    private static IEnumerable<Point> GetInput(IEnumerable<string> rawInput)
    {
        using var enumerator = rawInput.GetEnumerator();

        enumerator.MoveNext();
        var line0 = enumerator.Current;
        var n = int.Parse(line0);

        for (int i = 0; i < n; i++)
        {
            enumerator.MoveNext();
            var lineN = enumerator.Current;
            var splitted = lineN.Split();
            var xRaw = splitted[0];
            var yRaw = splitted[1];
            var x = int.Parse(xRaw);
            var y = int.Parse(yRaw);

            var point = new Point
            {
                X = x,
                Y = y
            };

            yield return point;
        }
    }
}

public record Point
{
    public int X { get; init; }
    public int Y { get; init; }
}