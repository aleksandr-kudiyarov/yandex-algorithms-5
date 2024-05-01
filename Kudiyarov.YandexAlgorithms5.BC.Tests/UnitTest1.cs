using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.BC.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   4
                                   1 5 2 1
                                   
                                   """;

    private const string Output01 = """
                                    1
                                    
                                    """;

    private const string Input02 = """
                                   4
                                   5 12 4 3
                                   
                                   """;

    private const string Output02 = """
                                    24
                                    
                                    """;
    
    private const string Input06 = """
                                   3
                                   3 4 5
                                   
                                   """;

    private const string Output06 = """
                                    12

                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    [InlineData(Input06, Output06)]
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