var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Middleware 1");
    await next(context);
    await context.Response.WriteAsync("Middleware 1 after");
});

app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Middleware 2");
    await next(context);
    await context.Response.WriteAsync("Middleware 2 after");
});

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware 3");
});

app.Run();
