using System;
using System.IO;

namespace Kudiyarov.YandexAlgorithms5.AB;

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
        return InnerSolution(input).ToString();
    }

    private static int InnerSolution(string[] input)
    {
        var gameA = ParseGameResult(input[0]);
        var gameB = ParseGameResult(input[1]);
        var @switch = input[2];

        return IsWinCase(gameA, gameB)
            ? 0
            : OtherCases(gameA, gameB, @switch);
    }

    private static bool IsWinCase(GameResult gameA, GameResult gameB)
    {
        var teamATotal = gameA.TeamA + gameB.TeamA;
        var teamBTotal = gameA.TeamB + gameB.TeamB;
        return teamATotal > teamBTotal;
    }

    private static int OtherCases(GameResult gameA, GameResult gameB, string @switch)
    {
        var teamATotal = gameA.TeamA + gameB.TeamA;
        var teamBTotal = gameA.TeamB + gameB.TeamB;
        var diff = teamBTotal - teamATotal;
        gameB.TeamA += diff;

        var games = @switch switch
        {
            "1" => (gameB, gameA),
            "2" => (gameA, gameB),
            _ => throw new ArgumentOutOfRangeException(nameof(@switch), @switch, null)
        };

        var result = games.Item1.TeamA > games.Item2.TeamB
            ? diff
            : ++diff;

        return result;
    }

    private static GameResult ParseGameResult(string value)
    {
        var splitted = value.Split(':');
        var teamA = int.Parse(splitted[0]);
        var teamB = int.Parse(splitted[1]);

        return new GameResult
        {
            TeamA = teamA,
            TeamB = teamB
        };
    }
}

public class GameResult
{
    public int TeamA { get; set; }
    public int TeamB { get; set; }
}