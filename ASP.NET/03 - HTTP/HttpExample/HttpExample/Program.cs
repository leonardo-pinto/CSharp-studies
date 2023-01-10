using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Query.ContainsKey("id"))
    {
        string id = context.Request.Query["id"];
        await context.Response.WriteAsync($"<h3>Id is {id}<h3/>");
    }
    //string requestPath = context.Request.Path;
    //context.Response.Headers["MyKey"] = "my value";
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("\n<h1>Testing</h1> statusCode");
    //await context.Response.WriteAsync($"Request path: <h2>{requestPath}</>");

});

app.Run();
