using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Query.ContainsKey("id"))
    {
        string id = context.Request.Query["id"];
        await context.Response.WriteAsync($"<h3>Id is {id}</h3>");
    }

    if (context.Request.Headers.ContainsKey("Authorization"))
    {
        string authHeader = context.Request.Headers["Authorization"];
        await context.Response.WriteAsync($"Auth header: {authHeader}");
    
    }

    StreamReader reader = new(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"];
        await context.Response.WriteAsync($"First name: ${firstName}");
    }

    //string requestPath = context.Request.Path;
    //context.Response.Headers["MyKey"] = "my value";
    //context.Response.StatusCode = 200;
    await context.Response.WriteAsync("\n<h1>Testing</h1> statusCode");
    //await context.Response.WriteAsync($"Request path: <h2>{requestPath}</>");

});

app.Run();
