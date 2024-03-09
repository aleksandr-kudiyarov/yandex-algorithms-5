using Kudiyarov.YandexAlgorithms5.BaseTest;

namespace Kudiyarov.YandexAlgorithms5.AG.Tests;

public class UnitTest1 : BaseUnitTest
{
    private const string Input01 = """
                                   10
                                   11
                                   15
                                   
                                   """;

    private const string Output01 = """
                                    4
                                    
                                    """;

    private const string Input02 = """
                                   1
                                   2
                                   1
                                   
                                   """;

    private const string Output02 = """
                                    -1
                                    
                                    """;
    
    private const string Input03 = """
                                     1
                                     1
                                     1
                                     
                                     """;

    private const string Output03 = """
                                      1
                                      
                                      """;
    
    private const string Input04 = """
                                   25
                                   200
                                   10
                                   
                                   """;

    private const string Output04 = """
                                    13
                                    
                                    """;
    
    private const string Input09 = """
                                    250
                                    500
                                    187
                                    
                                    """;
    
    private const string Output09 = """
                                    250
                                    500
                                    187

                                    """;

    [Theory]
    [InlineData(Input01, Output01)]
    [InlineData(Input02, Output02)]
    [InlineData(Input03, Output03)]
    [InlineData(Input04, Output04)]
    [InlineData(Input09, Output09)]
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
