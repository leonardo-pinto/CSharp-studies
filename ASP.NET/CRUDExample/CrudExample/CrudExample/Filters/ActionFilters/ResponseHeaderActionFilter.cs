using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudExample.Filters.ActionFilters
{
    public class ResponseHeaderActionFilter : ActionFilterAttribute
    {
        //private readonly ILogger<ResponseHeaderActionFilter> _logger;
        private readonly string _key;
        private readonly string _value;

        public ResponseHeaderActionFilter(string key, string value, int order)
        {
            _key = key;
            _value = value;
            Order = order;
        }

        //public int Order { get; set; }

        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    context.HttpContext.Response.Headers[_key] = _value;
        //}

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //_logger.LogInformation("{FilterName}. {MethodName} before method",
            //    nameof(ResponseHeaderActionFilter), nameof(OnActionExecutionAsync));
            // before action
            await next();
            // after action
            context.HttpContext.Response.Headers[_key] = _value;
        }
    }
}
