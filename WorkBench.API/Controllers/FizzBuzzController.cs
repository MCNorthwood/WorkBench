using Microsoft.AspNetCore.Mvc;
using WorkBench.Engine.Interfaces.FizzBuzz;

namespace WorkBench.API.Controllers;
[ApiController]
[Route("[controller]")]
public class FizzBuzzController(IFizzBuzz _fizzBuzz) : Controller
{
    [HttpGet("{count}",Name = "GetFizzBuzz")]
    public IEnumerable<string> Index(int count)
    {
        return _fizzBuzz.Calculate(count);
    }
}
