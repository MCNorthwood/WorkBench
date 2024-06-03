using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.Engine.Rules;
public class Fizz : IRuleSubstitute
{
    public int Ordinal => 2;

    public bool Applicable { get; private set; }

    public string Value => GetType().Name;

    public void Execute(int input)
    {
        Applicable = input % 3 == 0;
    }
}
