using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kudiyarov.YandexAlgorithms5.AF;

public static class Program
{
    public static void Main()
    {
        var rawInput = File.ReadLines("input.txt");
        var solution = Solution(rawInput);
        File.WriteAllText("output.txt", solution);
    }

    public static string Solution(IEnumerable<string> input)
    {
        var result = input
            .Skip(1)
            .First()
            .Split(' ')
            .Select(n => long.Parse(n))
            .ToList();
        
        var inputSize = result.Count - 1;

        var signs = new StringBuilder();

        var r = 1;
        
        while (r <= inputSize)
        {
            var innerL = result[r - 1];
            var innerR = result[r];

            var sign = innerL.IsOdd() && innerR.IsOdd()
                ? 'x'
                : '+';

            signs.Append(sign);
            
            r++;
        }

        return signs.ToString();
    }
}

public static class IntHelper
{
    public static bool IsOdd(this long number) => number % 2 != 0;
}