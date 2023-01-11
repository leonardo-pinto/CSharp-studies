using Middlewares;

var builder = WebApplication.CreateBuilder(args);
// add middleware as a service
builder.Services.AddTransient<MyCustomMiddleware, MyCustomMiddleware>();
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Middleware 1");
    await next(context);
    await context.Response.WriteAsync("Middleware 1 after");
});

app.UseMiddleware<MyCustomMiddleware>();

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware 3");
});

app.Run();
