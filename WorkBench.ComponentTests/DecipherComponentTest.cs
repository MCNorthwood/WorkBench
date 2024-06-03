using Autofac;
using FluentAssertions;
using System.Reflection;
using WorkBench.Engine.Interfaces.CaesarCipher;

namespace WorkBench.ComponentTests;
public class DecipherComponentTest
{
    private readonly IDecipher _decipher;

    public DecipherComponentTest()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.CaesarCipher")).AsImplementedInterfaces();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Cipher")).AsImplementedInterfaces();
        var container = containerBuilder.Build();

        _decipher = container.Resolve<IDecipher>();
    }

    [Theory]
    [InlineData("Bhv", 3, "Yes")]
    [InlineData("Ymnx nx ymj Xtzsi tk Rzxnh", 5, "This is the Sound of Music")]
    [InlineData("Kds'r fds hs nm", 25, "Let's get it on")]
    public void Does_encipher_cipher(string input, int key, string answer)
    {
        _decipher.Execute(input, key);

        _decipher.Value.Should().Be(answer);
    }
}
