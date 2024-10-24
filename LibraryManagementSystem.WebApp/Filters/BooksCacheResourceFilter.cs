using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;

namespace LibraryManagementSystem.WebApp.Filters
{
    public class BooksCacheResourceFilter(IMemoryCache cache) : IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var pageNumber = context.RouteData.Values["pageNumber"]?.ToString();

            var cacheKey = $"BooksPage-{pageNumber}";

            if (cache.TryGetValue(cacheKey, out var cachedData))
            {
                var viewResult = new ViewResult
                {
                    ViewName = "Index",
                    ViewData=new ViewDataDictionary(new EmptyModelMetadataProvider(),new ModelStateDictionary()) { Model= cachedData }
                };

                context.Result = viewResult;

                return;
            }

            var resultContext = await next();

            if (resultContext.Result is ViewResult viewResultFromService)
            {
                cache.Set(cacheKey, viewResultFromService.Model, TimeSpan.FromMinutes(1));
            }
        }
    }

}
