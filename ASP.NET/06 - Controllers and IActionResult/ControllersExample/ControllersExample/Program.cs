using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

// add service one-by-one
//builder.Services.AddTransient<HomeController>();

// automatically adds all controllers
builder.Services.AddControllers();

var app = builder.Build();

//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    // enables routing for each action methods
//    endpoints.MapControllers();
//});

// uses UseRouting and UseEndpoints as above
app.MapControllers();

app.Run();
