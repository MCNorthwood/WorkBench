using WorkBench.Engine.Interfaces.CaesarCipher;

namespace WorkBench.Engine.CaesarCipher;

public class Encipher(ICipher cipher) : IEncipher
{
    public string Value { get; private set; } = string.Empty;

    public void Execute(string input, int key)
    {
        foreach (char ch in input)
        {
            cipher.Execute(ch, key);
        }

        Value = string.Concat(cipher?.Value ?? []);
    }
}
