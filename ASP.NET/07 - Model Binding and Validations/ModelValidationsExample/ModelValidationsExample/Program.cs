var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// asp.net don have a xml formatter by default
builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();



app.Run();
