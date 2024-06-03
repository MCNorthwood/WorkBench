using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.Engine.Rules;
public class Buzz : IRuleSubstitute
{
    public int Ordinal => 3;

    public bool Applicable { get; private set; }

    public string Value => GetType().Name;

    public void Execute(int input)
    {
        Applicable = input % 5 == 0;
    }
}
