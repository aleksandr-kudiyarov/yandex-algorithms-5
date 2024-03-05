using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.AA.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input1 = """
                                  0 7
                                  12 5

                                  """;

    private const string Output1 = """
                                   25

                                   """;

    [Theory]
    [InlineData(Input1, Output1)]
    public void Test1(string input, string output)
    {
        InnerTest(input, output);
    }

    protected override TimeSpan Timeout => TimeSpan.FromSeconds(1);

    protected override string GetActual(string input)
    {
        var arr = input.Split(Environment.NewLine);
        return Program.Solution(arr);
    }
}