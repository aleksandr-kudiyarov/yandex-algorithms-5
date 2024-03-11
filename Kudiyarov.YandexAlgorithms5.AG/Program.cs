using System;
using System.IO;
using System.Linq;

namespace Kudiyarov.YandexAlgorithms5.AG;

public static class Program
{
    public static void Main()
    {
        var rawInput = File
            .ReadAllLines("input.txt");

        var result = Solution(rawInput);
        
        File.WriteAllText("output.txt", result);
    }

    public static string Solution(string[] rawInput)
    {
        var input = rawInput
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => int.Parse(line))
            .ToList();
        
        var stats = new GameState
        {
            MySoldiers = input[0],
            BarrackHp = input[1],
            EnemySoldiersPerMove = input[2],
            EnemySoldiers = 0
        };

        try
        {
            CheckConditions(stats);
            var round = 0;

            while (stats.BarrackHp > 0 || stats.EnemySoldiers > 0)
            {
                round++;
                Round(stats);
            }

            return round.ToString();
        }
        catch (LoseException ex)
        {
            return "-1";
        }
    }

    private static void CheckConditions(GameState stats)
    {
        if (stats.BarrackHp >= stats.MySoldiers * 2 && stats.EnemySoldiersPerMove >= stats.MySoldiers)
        {
            throw new LoseException();
        }
    }

    private static void Round(GameState state)
    {
        MyMove(state);
        EnemyMove(state);
    }

    private static void MyMove(GameState state)
    {
        var freeSoldiers = state.MySoldiers;

        if (CanDestroyBarrack(state) && CanKillAllSoldiers(state))
        {
            freeSoldiers -= state.BarrackHp;
            state.BarrackHp = 0;
        }
        
        // damage to soldiers
        var damageToSoldiers = Math.Min(freeSoldiers, state.EnemySoldiers);
        state.EnemySoldiers = Math.Max(0, state.EnemySoldiers - damageToSoldiers);
        freeSoldiers -= damageToSoldiers;

        // damage to barracks
        state.BarrackHp = Math.Max(0, state.BarrackHp - freeSoldiers);
    }

    private static int GetMinSoldiersToKill(int enemySoldiers)
    {
        var range = Enumerable
            .Range(0, enemySoldiers);

        foreach (var mySoldiers in range)
        {
            if (CanKill(mySoldiers, enemySoldiers))
            {
                return mySoldiers;
            }
        }

        return 0;
    }

    private static bool CanDestroyBarrack(GameState state)
    {
        var result = state.BarrackHp > 0 && state.MySoldiers >= state.BarrackHp;
        return result;
    }
    
    private static bool CanKillAllSoldiers(GameState state)
    {
        // my move
        var freeSoldiers = state.MySoldiers - state.BarrackHp;
        var enemySoldiers = state.EnemySoldiers - freeSoldiers;

        // enemy move
        var mySoldiers = state.MySoldiers - enemySoldiers;
        var result = CanKill(mySoldiers, enemySoldiers);
        
        return result;
    }

    private static bool CanKill(int mySoldiers, int enemySoldiers)
    {
        while (true)
        {
            if (mySoldiers <= 0)
            {
                return false;
            }

            if (enemySoldiers <= 0)
            {
                return true;
            }

            enemySoldiers = Math.Max(0, enemySoldiers - mySoldiers);
            mySoldiers = Math.Max(0, mySoldiers - enemySoldiers);
        }
    }

    private static void EnemyMove(GameState state)
    {
        EnemyAttack(state);
        EnemyProduce(state);
    }

    private static void EnemyAttack(GameState state)
    {
        state.MySoldiers = Math.Max(0, state.MySoldiers - state.EnemySoldiers);

        if (state.MySoldiers == 0)
        {
            throw new LoseException();
        }
    }

    private static void EnemyProduce(GameState state)
    {
        if (state.BarrackHp > 0)
        {
            state.EnemySoldiers += state.EnemySoldiersPerMove;   
        }
    }
}

public class GameState
{
    public int MySoldiers { get; set; }
    public int EnemySoldiers { get; set; }
    public int EnemySoldiersPerMove { get; set; }
    public int BarrackHp { get; set; }
}

public sealed class LoseException : Exception { }
