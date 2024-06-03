using FluentAssertions;
using WorkBench.Engine.Interfaces.FizzBuzz;
using WorkBench.Engine.Rules;

namespace WorkBench.UnitTests;
public class RuleBuzzTest
{
    private readonly IRuleSubstitute _buzz;

    public RuleBuzzTest()
    {
        _buzz = new Buzz();
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void Buzz_is_applicable(int amount)
    {
        _buzz.Execute(amount);

        _buzz.Applicable.Should().BeTrue();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(11)]
    public void Buzz_isnt_applicable(int amount)
    {
        _buzz.Execute(amount);

        _buzz.Applicable.Should().BeFalse();
    }
}