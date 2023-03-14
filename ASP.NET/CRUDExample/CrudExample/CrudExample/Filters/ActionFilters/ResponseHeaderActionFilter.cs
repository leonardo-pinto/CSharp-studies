using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudExample.Filters.ActionFilters
{
    public class ResponseHeaderActionFilter : IActionFilter, IOrderedFilter
    {
        private readonly ILogger<ResponseHeaderActionFilter> _logger;
        private readonly string _key;
        private readonly string _value;

        public ResponseHeaderActionFilter(ILogger<ResponseHeaderActionFilter> logger,
            string key, string value, int order)
        {
            _logger = logger;
            _key = key;
            _value = value;
            Order = order;
        }

        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers[_key] = _value;
        }
    }
}
