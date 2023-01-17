var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    // declare a custom directory
    WebRootPath = "myroot"
});
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async (HttpContext context) =>
    {
        // should open any file in the wwwroot
        // ex: localhost/example1.png
        await context.Response.WriteAsync("Hello");
    });

});

app.Run();
