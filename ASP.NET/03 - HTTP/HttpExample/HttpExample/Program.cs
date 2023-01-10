var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["MyKey"] = "my value";
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("<h1>Testing</h1> statusCode");
});

app.Run();
