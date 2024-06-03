using WorkBench.Engine.Interfaces.CaesarCipher;

namespace WorkBench.Engine.Cipher;
public class Caesar : ICipher
{
    public IList<char> Value { get; private set; } = [];

    public void Execute(char input, int key)
    {
        if (!char.IsLetter(input))
        {
            Value.Add(input);
            return;
        }

        char d = char.IsUpper(input) ? 'A' : 'a';
        Value.Add((char)(((input + key - d) % 26) + d));
    }
}
