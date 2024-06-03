using Autofac;
using FluentAssertions;
using System.Reflection;
using WorkBench.Engine.Interfaces.CaesarCipher;

namespace WorkBench.ComponentTests;
public class EncipherComponentTest
{
    private readonly IEncipher _encipher;

    public EncipherComponentTest()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.CaesarCipher")).AsImplementedInterfaces();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules")).AsImplementedInterfaces();
        var container = containerBuilder.Build();

        _encipher = container.Resolve<IEncipher>();
    }

    [Theory]
    [InlineData("Yes", 3, "Bhv")]
    [InlineData("This is the Sound of Music", 5, "Ymnx nx ymj Xtzsi tk Rzxnh")]
    [InlineData("Let's get it on", 25, "Kds'r fds hs nm")]
    public void Does_encipher_cipher(string input, int key, string answer)
    {
        _encipher.Execute(input, key);

        _encipher.Value.Should().Be(answer);
    }
}
