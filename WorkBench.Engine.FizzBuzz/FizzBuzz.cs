using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.Engine.FizzBuzz
{
    public class FizzBuzz(IRules rules) : IFizzBuzz
    {
        public List<string> Calculate(int count)
        {
            var list = new List<string>();

            for (int i = 1; i <= count; i++)
            {
                rules.Execute(i);
                list.Add(rules.Value);
            }

            return list;
        }
    }
}
