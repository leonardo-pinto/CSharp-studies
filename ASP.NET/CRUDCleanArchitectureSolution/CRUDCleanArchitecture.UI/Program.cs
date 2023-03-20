//using ServiceContracts;
//using Services;
//using Microsoft.EntityFrameworkCore;
//using Entities;
//using Repositories;
//using RepositoryContracts;
using Serilog;
//using CrudExample.Filters.ActionFilters;
using CrudExample;
using CrudExample.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Host.UseSerilog((HostBuilderContext context,
    IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    // read configuration settings from built-in IConfiguration
    .ReadFrom.Configuration(context.Configuration)
    // read out current app services and make them available to serilog
    .ReadFrom.Services(services);
    // must add Serilog to appsettings.json
});

// calling extension method
builder.Services.ConfigureServices(builder.Configuration);

// add Global-level filters
//builder.Services.AddControllersWithViews(options => {
    // can not supply argument values with this syntax
    // options.Filters.Add<ResponseHeaderActionFilter>();

    // add ILogger
//    var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<ResponseHeaderActionFilter>>();
//    options.Filters.Add(new ResponseHeaderActionFilter("My-Key-From-Global", "My-Value-From-Global", 2));
//});

// add servicos into IOC
//builder.Services.AddScoped<ICountriesService, CountriesService>();
//builder.Services.AddScoped<IPersonsService, PersonsService>();
//builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
//builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();

// DbContext as a service - EFC
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
    // supply connection string
    // should save in configuration
    // scoped service as default ! cannot add into a singleton
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

// String Connection
// Data Source=(localdb)\MSSQLLocalDB;
// Initial Catalog=PersonsDatabase;
// Integrated Security=True;
// Connect Timeout=30;
// Encrypt=False;
// TrustServerCertificate=False;
// ApplicationIntent=ReadWrite;
// MultiSubnetFailover=False

var app = builder.Build();

app.UseSerilogRequestLogging();

// enable HTTP logging;
// set log level in config file (dev and prod)!
//app.UseHttpLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseExceptionHandlingMiddleware();
}

//app.Logger.LogDebug("debug-message");
//app.Logger.LogCritical("critical-message");
//app.Logger.LogWarning("warning-message");

if (builder.Environment.IsEnvironment("Test") == false) {
    Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");
}

app.UseStaticFiles();
app.UseAuthentication(); // Reading Identity cookie
app.UseRouting(); // Identifying action method based
app.MapControllers(); // Execute the filter pipeline (action + filters)
app.Run();

// needs to change in project file 
public partial class Program { } // make the auto-generated Program accessible programatically