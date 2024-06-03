using Moq;
using WorkBench.Engine.FizzBuzz;
using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.UnitTests
{
    public class FizzBuzzTest
    {
        private readonly IFizzBuzz _fizzBuzz;
        private readonly Mock<IRules> _mockRules;

        public FizzBuzzTest()
        {
            _mockRules = new Mock<IRules>();
            _fizzBuzz = new FizzBuzz(_mockRules.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(100)]
        public void Does_rules_execute_in_fizzbuzz(int count)
        {
            _fizzBuzz.Calculate(count);

            _mockRules.Verify(x => x.Execute(It.IsAny<int>()), Times.Exactly(count));
        }
    }
}
