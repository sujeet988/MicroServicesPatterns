using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CircuitBreakerWithOutPolly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CbApi : ControllerBase
    {
        private CircuitBreaker _circuitBreaker = null;
        private HttpClient _httpClient = new HttpClient();
        public CbApi(CircuitBreaker circuitBreaker)
        {
            _circuitBreaker = circuitBreaker;

        }

        [HttpPost("GetData")]
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            if (_circuitBreaker.IsCircuitOpen)
            {
                throw new Exception("Circuit is open. Can't perform the operation.");
            }

            try
            {
                var response = await _httpClient.GetAsync(url);
                _circuitBreaker.Reset();
                return response;
            }
            catch
            {
                _circuitBreaker.RecordFailure();
                throw;
            }
        }

    }
}
