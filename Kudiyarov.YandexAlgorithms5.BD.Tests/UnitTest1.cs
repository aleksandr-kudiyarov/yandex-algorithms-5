using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.BD.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   3
                                   1 1
                                   1 2
                                   2 1

                                   """;

    private const string Output01 = """
                                    8

                                    """;

    private const string Input02 = """
                                   1
                                   8 8

                                   """;

    private const string Output02 = """
                                    4

                                    """;
    
    private const string Input12 = """
                                   36
                                   1 1
                                   1 2
                                   1 3
                                   1 4
                                   1 5
                                   1 6
                                   1 7
                                   1 8
                                   2 8
                                   3 1
                                   3 2
                                   3 3
                                   3 4
                                   3 5
                                   3 6
                                   3 7
                                   3 8
                                   4 8
                                   5 1
                                   5 2
                                   5 3
                                   5 4
                                   5 5
                                   5 6
                                   5 7
                                   5 8
                                   6 8
                                   7 1
                                   7 2
                                   7 3
                                   7 4
                                   7 5
                                   7 6
                                   7 7
                                   7 8
                                   8 8

                                   """;

    private const string Output12 = """
                                    74
                                    
                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    [InlineData(Input12, Output12)]
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