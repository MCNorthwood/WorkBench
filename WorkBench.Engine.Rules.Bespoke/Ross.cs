using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.Engine.Rules.Bespoke;

public class Ross : IRuleSubstitute
{
    public int Ordinal => 5;

    public bool Applicable { get; private set; }

    public string Value => GetType().Name;

    public void Execute(int input)
    {
        Applicable = input % 4 == 0;
    }
}
