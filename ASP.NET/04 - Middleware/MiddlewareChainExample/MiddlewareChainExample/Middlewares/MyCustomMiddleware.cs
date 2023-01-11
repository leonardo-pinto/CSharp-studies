namespace Middlewares
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("*** CLASS *** Middleware 2");
            await next(context);
            await context.Response.WriteAsync("*** CLASS *** Middleware 2 after");
        }
    }
}
