using task14;
namespace task14tests;

using Xunit;
public class UnitTest1
{
    Func<double, double> X = x => x;
    Func<double, double> SIN = x => Math.Sin(x);

    [Fact]
    public void Solve_LinearFunction()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, X, 1e-4, 2), 1e-4);
    }

    [Fact]
    public void Solve_AnotherLinearFunction()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, X, 1e-4, 2), 1e-4);
    }

    [Fact]
    public void Solve_SinFunction()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, SIN, 1e-5, 8), 1e-4);
    }

    [Fact]
    public void Solve_InvalidThreadException()
    {
        Assert.Throws<Exception>(() => DefiniteIntegral.Solve(0, 1, X, 1e-4, 0));
        Assert.Throws<Exception>(() => DefiniteIntegral.Solve(0, 1, X, 1e-4, -1));
    }
}
