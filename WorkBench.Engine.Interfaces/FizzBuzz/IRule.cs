namespace WorkBench.Engine.Interfaces.FizzBuzz;
public interface IRule : IExecute, IValueOfT<string>
{
    int Ordinal { get; }
    bool Applicable { get; }
}
