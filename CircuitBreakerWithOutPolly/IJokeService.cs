namespace CircuitBreakerWithOutPolly
{
    public interface IJokeService
    {
        public Task<string> GetRandomJokes();
        public Task<string> GetRandomJokesV2();
    }
}
