using ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;
using Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// add servicos into IOC
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IPersonsService, PersonsService>();

// DbContext as a service - EFC
builder.Services.AddDbContext<PersonsDbContext>(options =>
{
    // supply connection string
    // should save in configuration
    // scoped service as default ! cannot add into a singleton
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
