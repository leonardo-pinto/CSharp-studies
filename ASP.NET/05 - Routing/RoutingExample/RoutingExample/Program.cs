var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    Microsoft.AspNetCore.Http.Endpoint endpoint = context.GetEndpoint();
    if (endpoint != null)
    {
        await context.Response.WriteAsync($" Endpoint: {endpoint.DisplayName}");
    }
    await next(context);
});

// enable routing
app.UseRouting();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    if (endpoint != null)
    {
        await context.Response.WriteAsync($" Endpoint: {endpoint.DisplayName}");
    }
    await next(context);
});

app.UseEndpoints(endpoints =>
{
    // add endpoints
    //endpoints.Map("/map1", async (context) =>
    //{
    //    await context.Response.WriteAsync("In map 1");
    //});

    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync("Map1 Get");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();