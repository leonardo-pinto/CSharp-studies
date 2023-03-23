using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Swagger

builder.Services.AddEndpointsApiExplorer(); // enables Swagger to read metadata of endpoints
builder.Services.AddSwaggerGen(options =>
{
    // Project -> Properties -> Build -> Output -> api.xml
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
}); // configures swagger to generate documentation

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHsts();
app.UseHttpsRedirection();

app.UseSwagger(); // creates endpointn for swagger.json
app.UseSwaggerUI(); // creates swagger UI for testing all web api endpoints / action methods

app.UseAuthorization();

app.MapControllers();



app.Run();
