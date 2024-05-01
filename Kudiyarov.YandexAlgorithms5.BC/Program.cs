using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kudiyarov.YandexAlgorithms5.BC;

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
        var ls = GetInput(rawInput);

        var (sum, max) = SumMax(ls);

        var sumWoMax = sum - max;

        var min = max - sumWoMax;

        var result = min > 0
            ? min
            : max + sumWoMax;

        return result.ToString();
    }

    private static (int sum, int max) SumMax(IEnumerable<int> ls)
    {
        var max = int.MinValue;
        var sum = 0;

        foreach (var l in ls)
        {
            if (max < l)
            {
                max = l;
            }

            sum += l;
        }

        return (sum, max);
    }

    private static IEnumerable<int> GetInput(IEnumerable<string> rawInput)
    {
        var ls = rawInput
            .Skip(1)
            .First()
            .Split()
            .Select(int.Parse);

        return ls;
    }
}