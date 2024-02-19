using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CircuitBreakerWithOutPolly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        public readonly IJokeService _jokeService;
        public JokeController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [HttpGet(Name = "GetRandomeJokes")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _jokeService.GetRandomJokes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
