using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Bootcamp.API.Filters
{
    public class CacheResourceFilter : IResourceFilter
    {
        private readonly IMemoryCache _memoryCache;
        private string _cacheKey;

        public CacheResourceFilter()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _cacheKey = context.HttpContext.Request.Path.ToString();

            string contentResult = string.Empty;
            Debug.WriteLine(_cacheKey);
            contentResult = (string)_memoryCache.Get(_cacheKey);

            if (!string.IsNullOrEmpty(contentResult))
            {
                context.Result = new ContentResult()
                { Content = contentResult };
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!string.IsNullOrEmpty(_cacheKey))
            {
                var result = context.Result as ContentResult;
                if (result != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(1));   
                    _memoryCache.Set(_cacheKey, result.Content, cacheEntryOptions);
                }
            }
        }
    }
}
