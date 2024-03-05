using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.AF.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   3
                                   5 7 2
                                   
                                   """;

    private const string Output01 = """
                                    x+
                                    
                                    """;

    private const string Input02 = """
                                   2
                                   4 -5
                                   
                                   """;

    private const string Output02 = """
                                    +
                                    
                                    """;
    
    private const string MyInput01 = """
                                   2
                                   0 1

                                   """;

    private const string MyOutput01 = """
                                    +

                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    [InlineData(MyInput01, MyOutput01)]
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