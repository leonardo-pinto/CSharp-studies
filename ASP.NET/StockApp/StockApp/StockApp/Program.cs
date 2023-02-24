using ServiceContracts;
using Services;
using StockApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFinnhubService, FinnhubService>();
builder.Services.AddSingleton<IStocksService, StocksService>();
//builder.Services.AddHttpClient();

builder.Services.AddHttpClient<IFinnhubService, FinnhubService>();

// Add configuration as Service
builder.Services.Configure<TradingOptions>(
    builder.Configuration.GetSection("TradingOptions"));


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
