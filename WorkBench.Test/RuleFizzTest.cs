using FluentAssertions;
using WorkBench.Engine.Interfaces.FizzBuzz;
using WorkBench.Engine.Rules;

namespace WorkBench.UnitTests;
public class RuleFizzTest
{
    private readonly IRuleSubstitute _fizz;

    public RuleFizzTest()
    {
        _fizz = new Fizz();
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(12)]
    [InlineData(15)]
    public void Fizz_is_applicable(int amount)
    {
        _fizz.Execute(amount);

        _fizz.Applicable.Should().BeTrue();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(11)]
    public void Fizz_isnt_applicable(int amount)
    {
        _fizz.Execute(amount);

        _fizz.Applicable.Should().BeFalse();
    }
}
