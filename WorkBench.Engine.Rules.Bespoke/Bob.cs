using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.Engine.Rules.Bespoke;

public class Bob : IRuleSubstitute
{
    public int Ordinal => 4;

    public bool Applicable { get; private set; }

    public string Value => GetType().Name;

    public void Execute(int input)
    {
        Applicable = input % 7 == 0;
    }
}
