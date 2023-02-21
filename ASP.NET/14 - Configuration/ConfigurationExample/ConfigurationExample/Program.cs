using ConfigurationExample.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Supply an object of WeatherApiOptions as a service
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("Weatherapi"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/config", async context =>
//    {
//        // not case-sensitive
//        //await context.Response.WriteAsync(app.Configuration["MyKey"]);
//        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));
//        await context.Response.WriteAsync(app.Configuration.GetValue("AnotherKey", "default value"));

//    });
//});
app.MapControllers();


app.Run();
