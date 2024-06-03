using Autofac;
using FluentAssertions;
using System.Reflection;
using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.ComponentTests;
public class FizzBuzzContainerTest
{
    private readonly IFizzBuzz _fizzBuzz;
    private readonly IRules _rules;

    public FizzBuzzContainerTest()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.FizzBuzz")).AsImplementedInterfaces();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules")).AsImplementedInterfaces();
        var container = containerBuilder.Build();

        _fizzBuzz = container.Resolve<IFizzBuzz>();
        _rules = container.Resolve<IRules>();
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "1,2")]
    [InlineData(3, "1,2,Fizz")]
    [InlineData(4, "1,2,Fizz,4")]
    [InlineData(5, "1,2,Fizz,4,Buzz")]
    [InlineData(7, "1,2,Fizz,4,Buzz,Fizz,7")]
    [InlineData(15, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz")]
    public void Does_fizz_buzz_calculate(int count, string result)
    {
        var response = _fizzBuzz.Calculate(count);

        string.Join(",", response).Should().Be(result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(4, "4")]
    [InlineData(5, "Buzz")]
    [InlineData(7, "7")]
    [InlineData(15, "FizzBuzz")]
    public void Does_rules_execute(int count, string result)
    {
        _rules.Execute(count);

        _rules.Value.Should().Be(result);
    }
}
