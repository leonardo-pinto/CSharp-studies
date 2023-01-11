var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routing
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // add endpoints
    endpoints.Map("/map1", async (context) =>
    {
        await context.Response.WriteAsync("In map 1");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();