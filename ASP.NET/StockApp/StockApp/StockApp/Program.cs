using Entities;
using ServiceContracts;
using Services;
using StockApp;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IFinnhubService, FinnhubService>();
builder.Services.AddTransient<IStocksService, StocksService>();
builder.Services.AddTransient<IFinhubRepository, FinnhubRepository>();
builder.Services.AddTransient<IStocksRepository, StocksRepository>();


//builder.Services.AddTransient<IFinn>
builder.Services.AddHttpClient();

//builder.Services.AddHttpClient<IFinnhubService, FinnhubService>();

builder.Services.AddDbContext<StockMarketDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add configuration as Service
builder.Services
    .Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));

var app = builder.Build();

if (builder.Environment.IsEnvironment("Test") == false)
{
    Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");
};

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
