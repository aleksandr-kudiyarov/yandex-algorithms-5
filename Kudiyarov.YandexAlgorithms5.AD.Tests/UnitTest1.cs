using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.AD.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   ********
                                   ********
                                   *R******
                                   ********
                                   ********
                                   ********
                                   ********
                                   ********

                                   """;

    private const string Output01 = """
                                    49

                                    """;

    private const string Input02 = """
                                   ********
                                   ********
                                   ******B*
                                   ********
                                   ********
                                   ********
                                   ********
                                   ********

                                   """;

    private const string Output02 = """
                                    54

                                    """;

    private const string Input03 = """
                                   ********
                                   *R******
                                   ********
                                   *****B**
                                   ********
                                   ********
                                   ********
                                   ********

                                   """;

    private const string Output03 = """
                                    40

                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    [InlineData(Input03, Output03)]
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