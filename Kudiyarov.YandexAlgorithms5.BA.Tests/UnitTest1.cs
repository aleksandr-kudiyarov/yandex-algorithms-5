using Kudiyarov.YandexAlgorithms5.BaseTest;
using Xunit;

namespace Kudiyarov.YandexAlgorithms5.BA.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   4
                                   1 3
                                   3 1
                                   3 5
                                   6 3

                                   """;

    private const string Output01 = """
                                    1 1 6 5

                                    """;

    private const string Input02 = """
                                   5
                                   0 0
                                   1 0
                                   0 1
                                   10 10
                                   11 11
                                   
                                   """;

    private const string Output02 = """
                                    0 0 11 11

                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    public void Test1(string input, string output)
    {
        InnerTest(input, output);
    }

    protected override TimeSpan Timeout => TimeSpan.FromSeconds(1);

    protected override string GetActual(string input)
    {
        return Program.Solution(input.Split(Environment.NewLine));
    }
}