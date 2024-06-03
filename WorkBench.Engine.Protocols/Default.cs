using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.Engine.Rules;

public class Default(IEnumerable<IRuleSubstitute>? ruleSubstitutes) : IRule
{
    public int Ordinal => 1;

    public bool Applicable { get; private set; }

    public string? Value { get; private set; }

    public void Execute(int input)
    {
        ruleSubstitutes?.ToList().ForEach(_ => _.Execute(input));
        Applicable = !ruleSubstitutes?.Any(_ => _.Applicable) ?? false;
        Value = Applicable ? $"{input}" : null;
    }
}