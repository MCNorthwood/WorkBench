using FluentAssertions;
using Moq;
using WorkBench.Engine.Interfaces.FizzBuzz;
using WorkBench.Engine.Rules;

namespace WorkBench.UnitTests;
public class RulesTest
{
    private readonly Rules _rules;
    private readonly Mock<IRule> _default = new();
    private readonly Mock<IRuleSubstitute> _fizz = new();
    private readonly Mock<IRuleSubstitute> _buzz = new();

    public RulesTest()
    {
        IEnumerable<IRule> ruleList = [_buzz.Object, _default.Object, _fizz.Object];
        _rules = new Rules(ruleList);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(15)]
    public void Does_irule_in_rules_execute(int count)
    {
        _rules.Execute(count);

        _default.Verify(_ =>  _.Execute(It.IsAny<int>()), Times.Once);
        _fizz.Verify(_ =>  _.Execute(It.IsAny<int>()), Times.Once);
        _buzz.Verify(_ =>  _.Execute(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void Does_rules_value_get_value_from_irules()
    {
        _default.Setup(x => x.Value).Returns("1");
        _default.Setup(x => x.Applicable).Returns(true);

        _rules.Execute(1);

        _rules.Value.Should().Be("1");
    }

    [Fact]
    public void Does_rules_value_get_empty_string_if_no_rules_are_applicable()
    {
        _default.Setup(x => x.Value).Returns("1");
        _default.Setup(x => x.Applicable).Returns(false);

        _rules.Execute(1);

        _rules.Value.Should().BeEmpty();
    }
}
