using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.BB.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   5 2
                                   1 2 3 4 5

                                   """;

    private const string Output01 = """
                                    2

                                    """;

    private const string Input02 = """
                                   5 2
                                   5 4 3 2 1

                                   """;

    private const string Output02 = """
                                    0

                                    """;

    private const string Input04 = """
                                   2 1
                                   1 2

                                   """;

    private const string Output04 = """
                                    1

                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    [InlineData(Input04, Output04)]
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