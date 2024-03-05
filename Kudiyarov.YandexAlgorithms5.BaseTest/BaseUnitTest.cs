using System.Diagnostics;
using Xunit;

namespace Kudiyarov.YandexAlgorithms5.BaseTest;

public abstract class BaseUnitTest
{
    protected abstract TimeSpan Timeout { get; }
    
    protected void InnerTest(string input, string output)
    {
        // act
        var sw = Stopwatch.StartNew();
        var actual = GetActual(input);
        sw.Stop();

        // assert
        Assert.Equal(output.Trim(), actual.Trim());
        Assert.True(sw.Elapsed < Timeout);
    }

    protected abstract string GetActual(string input);
}