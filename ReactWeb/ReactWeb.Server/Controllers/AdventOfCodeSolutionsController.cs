using Microsoft.AspNetCore.Mvc;

namespace ReactWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdventOfCodeSolutionsController : ControllerBase
    {
        private readonly ILogger<AdventOfCodeSolutionsController> _logger;

        public AdventOfCodeSolutionsController(ILogger<AdventOfCodeSolutionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAdventOfCodeSolutions")]
        public IEnumerable<AdventOfCodeSolution> Get()
        {
            return new List<AdventOfCodeSolution>{
                new AdventOfCodeSolution { Description = "Solution to Day 1 part 1", Solution = Day01Part1.Solve() },
                new AdventOfCodeSolution { Description = "Solution to Day 1 part 2", Solution = Day01Part2.Solve() },
                new AdventOfCodeSolution { Description = "Solution to Day 2 part 1", Solution = Day02Part1.Solve() },
                new AdventOfCodeSolution { Description = "Solution to Day 2 part 2", Solution = Day02Part2.Solve() },
                new AdventOfCodeSolution { Description = "Solution to Day 3 part 1", Solution = Day03Part1.Solve() },
                new AdventOfCodeSolution { Description = "Solution to Day 3 part 2", Solution = Day03Part2.Solve() },
                new AdventOfCodeSolution { Description = "Solution to Day 4 part 1", Solution = Day04Part1.Solve() },
                new AdventOfCodeSolution { Description = "Solution to Day 4 part 2", Solution = Day04Part2.Solve() }
            };
        }
    }
}
