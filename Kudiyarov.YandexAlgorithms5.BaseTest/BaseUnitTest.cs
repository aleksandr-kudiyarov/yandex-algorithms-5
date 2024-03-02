using Xunit;

namespace Kudiyarov.YandexAlgorithms5.BaseTest;

public abstract class BaseUnitTest
{
    protected void InnerTest(string input, string output)
    {
        // act
        var actual = GetActual(input);
        
        // assert
        Assert.Equal(output.Trim(), actual.Trim());
    }

    protected abstract string GetActual(string input);
}