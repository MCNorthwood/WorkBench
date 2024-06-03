using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.Engine.Rules;
public class Rules(IEnumerable<IRule> rules) : IRules
{
    public string Value => string.Join("", rules.Where(_ => _.Applicable).OrderBy(_ => _.Ordinal).Select(rule => rule.Value));

    public void Execute(int input)
    {
        rules.ToList().ForEach(rule =>
        {
            rule.Execute(input);
        });
    }
}
