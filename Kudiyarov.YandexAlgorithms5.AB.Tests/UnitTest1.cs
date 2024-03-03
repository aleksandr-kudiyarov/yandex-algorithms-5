using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.AB.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   0:0
                                   0:0
                                   1

                                   """;

    private const string Output01 = """
                                    1

                                    """;

    private const string Input02 = """
                                   0:2
                                   0:3
                                   1

                                   """;

    private const string Output02 = """
                                    5

                                    """;

    private const string Input03 = """
                                   0:2
                                   0:3
                                   2

                                   """;

    private const string Output03 = """
                                    6

                                    """;

    private const string Input05 = """
                                   2:2
                                   1:1
                                   2

                                   """;

    private const string Output05 = """
                                    0

                                    """;

    private const string Input41 = """
                                   1:1
                                   1:4
                                   1

                                   """;

    private const string Output41 = """
                                    3

                                    """;

    private const string Input51 = """
                                   4:3
                                   0:3
                                   2

                                   """;

    private const string Output51 = """
                                    2

                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    [InlineData(Input03, Output03)]
    [InlineData(Input05, Output05)]
    [InlineData(Input41, Output41)]
    [InlineData(Input51, Output51)]
    public void Test1(string input, string output)
    {
        InnerTest(input, output);
    }

    protected override string GetActual(string input)
    {
        var arr = input.Split(Environment.NewLine);
        return Program.Solution(arr);
    }
}