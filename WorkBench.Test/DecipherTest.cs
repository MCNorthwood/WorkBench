using FluentAssertions;
using Moq;
using WorkBench.Engine.CaesarCipher;
using WorkBench.Engine.Interfaces.CaesarCipher;

namespace WorkBench.UnitTests;
public class DecipherTest
{
    private readonly IDecipher _caesarCipher;
    private readonly Mock<ICipher> _caesarCipherMock = new();

    public DecipherTest()
    {
        _caesarCipher = new Decipher(_caesarCipherMock.Object);
    }

    [Theory]
    [InlineData("Yes", 3)]
    [InlineData("Bob Ross", 8)]
    [InlineData("Let's get it on", 15)]
    public void Cipher_in_decipher_ciphor_executes(string input, int length)
    {
        _caesarCipherMock.Setup(x => x.Execute(It.IsAny<char>(), It.IsAny<int>()));

        _caesarCipher.Execute(input, 3);

        _caesarCipher.Value.Should().NotBeNull();
        _caesarCipherMock.Verify(x => x.Execute(It.IsAny<char>(), It.IsAny<int>()), Times.Exactly(length));
    }
}
