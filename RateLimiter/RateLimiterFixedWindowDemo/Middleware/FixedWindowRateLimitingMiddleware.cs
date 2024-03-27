using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;

namespace RateLimiterFixedWindowDemo.Middleware
{
    public class FixedWindowRateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TimeSpan _window = TimeSpan.FromSeconds(20); // Set your time span
        private readonly int _limit = 5; // Set your max requests
        private static ConcurrentDictionary<string, int> _requests = new ConcurrentDictionary<string, int>();

        public FixedWindowRateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IMemoryCache cache)
        {

            /*
             * var clientIp = context.Connection.RemoteIpAddress.ToString(); - This line gets the IP address of the client making the request. This is used to identify unique clients.

              var windowKey = $"{clientIp}:{DateTime.Now.Ticks / _window.Ticks}"; - 
            This line creates a unique key for each client and each time window. DateTime.Now.Ticks / _window.Ticks calculates the current time window based on the _window duration. By dividing the current time's ticks by the window duration's ticks, we ensure that the result changes only when the time window changes.

            _requests.AddOrUpdate(windowKey, 1, (_, count) => count + 1); - 
            This line adds a new entry to the _requests dictionary for the windowKey with a value of 1, or if the windowKey already exists, it increments the existing value. This keeps track of the number of requests made by each client in each time window.

             cache.Set(windowKey, _requests[windowKey], _window); - T
            his line stores the current count of requests for the windowKey in the cache, with an expiration time equal to the duration of the time window (_window). This means that the count will be automatically removed from the cache when the time window ends. This is useful for freeing up memory, as counts for old time windows are no longer needed.
             */

            var clientIp = context.Connection.RemoteIpAddress.ToString();
            var windowKey = $"{clientIp}:{DateTime.Now.Ticks / _window.Ticks}";

            int count;
            bool exists = _requests.TryGetValue(windowKey, out count);

            if (!exists)
            {
                _requests.TryAdd(windowKey, 1);
            }
            else
            {
                _requests.TryUpdate(windowKey, count + 1, count);
            }
            cache.Set(windowKey, _requests[windowKey], _window);

            if (_requests[windowKey] > _limit)
            {
                context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                await context.Response.WriteAsync("Too many requests. Please try again later.");
                return;
            }

            await _next(context);
        }
    }
}
