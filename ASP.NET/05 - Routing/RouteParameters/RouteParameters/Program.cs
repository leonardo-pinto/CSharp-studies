var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routing
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async (HttpContext context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"filename is {filename}");
        await context.Response.WriteAsync($"extension is {extension}");

    });

    // example of default value
    endpoints.Map("products/details/{id=1}", async (HttpContext context) =>
    {
        string? id = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"id is {id}");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
