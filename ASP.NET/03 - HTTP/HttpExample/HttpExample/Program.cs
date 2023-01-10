using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string requestPath = context.Request.Path;
    context.Response.Headers["MyKey"] = "my value";
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("<h1>Testing</h1> statusCode");
    await context.Response.WriteAsync($"Request path: <h2>{requestPath}</>");

});

app.Run();
