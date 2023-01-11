var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (HttpContext context, RequestDelegate next) =>
        {
            await context.Response.WriteAsync("Request has username in query");
            await next(context);
        });
    }
);

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("No username in query");
});


app.Run();
