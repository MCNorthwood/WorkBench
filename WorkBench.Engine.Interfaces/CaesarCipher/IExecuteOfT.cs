namespace WorkBench.Engine.Interfaces.CaesarCipher;
public interface IExecuteOfT<T>
{
    void Execute(T input, int key);
}
