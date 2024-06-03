using Autofac;
using FluentAssertions;
using System.Reflection;
using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.ComponentTests;
public class FizzBuzzBespokeContainerTest
{
    private readonly IFizzBuzz _fizzBuzz;
    private readonly IRules _rules;

    public FizzBuzzBespokeContainerTest()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.FizzBuzz")).AsImplementedInterfaces();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules")).AsImplementedInterfaces();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules.Bespoke")).AsImplementedInterfaces();
        var container = containerBuilder.Build();

        _fizzBuzz = container.Resolve<IFizzBuzz>();
        _rules = container.Resolve<IRules>();
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "1,2")]
    [InlineData(3, "1,2,Fizz")]
    [InlineData(4, "1,2,Fizz,Ross")]
    [InlineData(5, "1,2,Fizz,Ross,Buzz")]
    [InlineData(7, "1,2,Fizz,Ross,Buzz,Fizz,Bob")]
    [InlineData(15, "1,2,Fizz,Ross,Buzz,Fizz,Bob,Ross,Fizz,Buzz,11,FizzRoss,13,Bob,FizzBuzz")]
    public void Does_fizz_buzz_calculate(int count, string result)
    {
        var response = _fizzBuzz.Calculate(count);

        string.Join(",", response).Should().Be(result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(4, "Ross")]
    [InlineData(5, "Buzz")]
    [InlineData(7, "Bob")]
    [InlineData(15, "FizzBuzz")]
    public void Does_rules_execute(int count, string result)
    {
        _rules.Execute(count);

        _rules.Value.Should().Be(result);
    }
}
