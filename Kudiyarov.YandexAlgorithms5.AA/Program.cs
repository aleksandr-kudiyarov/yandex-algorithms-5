using System;
using System.IO;

namespace Kudiyarov.YandexAlgorithms5.AA;

public static class Program
{
    public static void Main()
    {
        var input = File.ReadAllLines("input.txt");
        var solution = Solution(input);
        File.WriteAllText("output.txt", solution);
    }

    public static string Solution(string[] input)
    {
        var (vasya, masha) = GetInputParams(input);

        var res = 0;

        if (IsIntersect(vasya, masha))
        {
            var max = Math.Max(vasya.Max, masha.Max);
            var min = Math.Min(vasya.Min, masha.Min);
            res = max - min + 1;
        }
        else
        {
            res = (vasya.Max - vasya.Min + 1) + (masha.Max - masha.Min + 1);
        }

        return res.ToString();
    }

    private static (InputParam, InputParam) GetInputParams(string[] input)
    {
        var vasyaLine = input[0];
        var mashaLine = input[1];

        var vasya = GetInputParam(vasyaLine);
        var masha = GetInputParam(mashaLine);

        return (vasya, masha);
    }

    private static InputParam GetInputParam(string line)
    {
        var splitted = line.Split(" ");

        var start = splitted[0];
        var distance = splitted[1];

        var result = new InputParam
        {
            Start = int.Parse(start),
            Distance = int.Parse(distance)
        };

        return result;
    }

    private static bool IsIntersect(InputParam a, InputParam b)
    {
        return a.Min <= b.Max && a.Max >= b.Min;
    }
}

public class InputParam
{
    public int Start { get; init; }
    public int Distance { get; init; }

    public int Min => Start - Distance;
    public int Max => Start + Distance;
}