using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CircuitBreakerWithOutPolly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeV2Controller : ControllerBase
    {
        public readonly IJokeService _jokeService;

        public JokeV2Controller(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [HttpGet(Name = "GetRandomeJokesV2")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _jokeService.GetRandomJokesV2();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
