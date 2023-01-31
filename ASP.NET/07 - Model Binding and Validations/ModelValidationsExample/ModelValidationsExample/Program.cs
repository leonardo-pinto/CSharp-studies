using ModelValidationsExample.CustomModelBinder;

var builder = WebApplication.CreateBuilder(args);
// add options to use ModelBinderProviders
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
// asp.net don have a xml formatter by default
builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();



app.Run();
