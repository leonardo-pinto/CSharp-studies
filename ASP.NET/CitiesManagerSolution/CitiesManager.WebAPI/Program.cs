using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json")); // ensures that all methods returns json
    options.Filters.Add(new ConsumesAttribute("application/json")); // ensures only json is accepeted
});

builder.Services.AddApiVersioning(config =>
{
    config.ApiVersionReader = new UrlSegmentApiVersionReader();

    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
});

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

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
        { Title = "Cities Web API", Version = "1.0" }
    );

    options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo()
    { Title = "Cities Web API", Version = "2.0" }
    );
}); // configures swagger to generate documentation

//
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // enables versioning for two-digits e.g. 1.1
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHsts();
app.UseHttpsRedirection();

app.UseSwagger(); // creates endpointn for swagger.json
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");

}); // creates swagger UI for testing all web api endpoints / action methods

app.UseAuthorization();

app.MapControllers();



app.Run();
