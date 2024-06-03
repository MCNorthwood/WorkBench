using FluentAssertions;
using WorkBench.Engine.Interfaces.FizzBuzz;
using WorkBench.Engine.Rules;

namespace WorkBench.UnitTests;
public class RuleDefaultTest
{
    private readonly IRule _default;

    public RuleDefaultTest()
    {
        IEnumerable<IRuleSubstitute> rulesSubstitute = [new Buzz(), new Fizz()];
        _default = new Default(rulesSubstitute);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, false)]
    [InlineData(4, true)]
    [InlineData(5, false)]
    [InlineData(7, true)]
    [InlineData(15, false)]
    public void Is_default_Applicable(int amount, bool applicable)
    {
        _default.Execute(amount);

        _default.Applicable.Should().Be(applicable);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(4, "4")]
    [InlineData(7, "7")]
    [InlineData(11, "11")]
    [InlineData(13, "13")]
    [InlineData(14, "14")]
    public void Is_default_values_correct(int amount, string result)
    {
        _default.Execute(amount);

        _default.Value.Should().Contain(result);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(15)]
    public void Is_default_values_empty(int amount)
    {
        _default.Execute(amount);

        _default.Value.Should().BeNull();
    }

    [Fact]
    public void If_default_has_no_rule_substitutes_no_value_should_be_returned()
    {
        var defaultNoRuleSubstitutes = new Default(null);

        defaultNoRuleSubstitutes.Execute(5);

        defaultNoRuleSubstitutes.Applicable.Should().BeFalse();
        defaultNoRuleSubstitutes.Value.Should().BeNull();
    }

    [Fact]
    public void If_default_has_no_rule_substitutes_it_should_not_throw_an_exception()
    {
        var defaultNoRuleSubstitutes = new Default(null);

        Action act = () => defaultNoRuleSubstitutes.Execute(5);

        act.Should().NotThrow();
    }
}
