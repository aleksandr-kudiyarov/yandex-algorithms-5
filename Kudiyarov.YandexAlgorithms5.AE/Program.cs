using System.IO;
using System.Linq;
using System.Text;

namespace Kudiyarov.YandexAlgorithms5.AE;

public static class Program
{
    public static void Main()
    {
        var rawInput = File.ReadAllText("input.txt");
        var solution = Solution(rawInput);
        File.WriteAllText("output.txt", solution);
    }

    public static string Solution(string rawInput)
    {
        var result = rawInput
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();

        var input = new Params
        {
            InitialIncome = result[0],
            Users = result[1],
            Days = result[2]
        };

        var answer = GetAnswer(input);
        return answer;
    }

    private static string GetAnswer(Params input)
    {
        var income = input.InitialIncome * 10;
        var users = input.Users;
        var days = input.Days;

        for (var i = 0; i < 10; i++)
        {
            if (income % users == 0)
            {
                var sb = new StringBuilder();
                sb.Append(income);
                sb.Append('0', days - 1);
                return sb.ToString();
            }

            income++;
        }

        return (-1).ToString();
    }
}

public class Params
{
    public int InitialIncome { get; init; }
    public int Users { get; init; }
    public int Days { get; init; }
}