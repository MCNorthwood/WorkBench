using FluentAssertions;
using WorkBench.Engine.Cipher;
using WorkBench.Engine.Interfaces.CaesarCipher;

namespace WorkBench.UnitTests;
public class CaesarTest
{
    private readonly ICipher _caesar;

    public CaesarTest()
    {
        _caesar = new Caesar(); 
    }

    [Theory]
    [InlineData('A', 'D')]
    [InlineData('J', 'M')]
    [InlineData('Z', 'C')]
    public void Does_caesar_cipher_capitalise(char input, char result)
    {
        _caesar.Execute(input, 3);

        _caesar.Value.First().Should().Be(result);
    }

    [Theory]
    [InlineData('D', 'A')]
    [InlineData('M', 'J')]
    [InlineData('C', 'Z')]
    public void Does_caesar_deciphor_capitalise(char input, char result)
    {
        _caesar.Execute(input, 23);

        _caesar.Value.First().Should().Be(result);
    }

    [Theory]
    [InlineData('a', 'd')]
    [InlineData('j', 'm')]
    [InlineData('z', 'c')]
    public void Does_caesar_cipher_lowercase(char input, char result)
    {
        _caesar.Execute(input, 3);

        _caesar.Value.First().Should().Be(result);
    }

    [Theory]
    [InlineData('d', 'a')]
    [InlineData('m', 'j')]
    [InlineData('c', 'z')]
    public void Does_caesar_deciphor_lowercase(char input, char result)
    {
        _caesar.Execute(input, 23);

        _caesar.Value.First().Should().Be(result);
    }

    [Theory]
    [InlineData(' ')]
    [InlineData(',')]
    [InlineData('.')]
    public void Does_caesar_return_unicode(char input)
    {
        _caesar.Execute(input, 3);

        _caesar.Value.First().Should().Be(input);
    }
}
