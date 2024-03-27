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
