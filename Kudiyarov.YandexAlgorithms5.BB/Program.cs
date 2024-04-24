using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kudiyarov.YandexAlgorithms5.BB;

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
        using var enumerator = rawInput.GetEnumerator();

        enumerator.MoveNext();
        var line1 = enumerator.Current;
        var line1Splitted = line1.Split();
        var k = byte.Parse(line1Splitted[1]);

        enumerator.MoveNext();
        var line2 = enumerator.Current;
        var prices = line2
            .Split()
            .Select(int.Parse)
            .ToArray();

        var max = int.MinValue;

        var l = 0;

        while (l < prices.Length - 1)
        {
            var r = l + 1;

            while (r - l <= k && r < prices.Length)
            {
                var lPrice = prices[l];
                var rPrice = prices[r];

                var diff = rPrice - lPrice;

                if (diff > max)
                {
                    max = diff;
                }

                r++;
            }

            l++;
        }

        return Math.Max(0, max).ToString();
    }
}