using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Middlewares
{
    public class CustomCachingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CustomCachingMiddleware> _logger;

        public CustomCachingMiddleware(RequestDelegate next, IMemoryCache memoryCache, ILogger<CustomCachingMiddleware> logger)
        {
            _next = next;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if caching is applicable for this request (e.g., only for GET requests)
            if (context.Request.Method == "GET")
            {
                var cacheKey = GenerateCacheKeyFromRequest(context.Request);

                // Check if data exists in the cache
                if (_memoryCache.TryGetValue(cacheKey, out var cachedResponse))
                {
                    // Serve cached data
                    _logger.LogInformation("Cache hit for {CacheKey}", cacheKey);
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(cachedResponse.ToString());
                    return;
                }
                else
                {
                    // Cache miss: Let the pipeline continue (eventually allowing the action to run)
                    var originalBodyStream = context.Response.Body;
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        context.Response.Body = memoryStream;

                        // Call the next middleware in the pipeline (the action will be executed here)
                        await _next(context);

                        // After the action is executed, capture the response and cache it
                        memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                        var responseBody = new System.IO.StreamReader(memoryStream).ReadToEnd();
                        _memoryCache.Set(cacheKey, responseBody, TimeSpan.FromMinutes(5)); // Cache for 5 minutes

                        // Write the response back to the original body stream
                        memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                        await memoryStream.CopyToAsync(originalBodyStream);
                    }
                }
            }
            else
            {
                // Continue to the next middleware if the request is not cacheable (e.g., POST or PUT)
                await _next(context);
            }
        }

        // Generate a unique cache key based on the request
        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var key = $"{request.Path}{(request.QueryString.HasValue ? request.QueryString.Value : string.Empty)}";
            return key;
        }
    }
}
