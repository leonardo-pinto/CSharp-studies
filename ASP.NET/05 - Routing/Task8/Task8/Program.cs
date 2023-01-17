var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IDictionary<int, string> countries = new Dictionary<int, string>
{
    { 1, "United States" },
    { 2, "Canada" },
    { 3, "United Kingdom" },
    { 4, "India" },
    { 5, "Japan" }
};


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", async (HttpContext context) =>
    {
        foreach(KeyValuePair<int, string> item in countries)
        {
            await context.Response.WriteAsync($"{item.Key}. {item.Value}\n");
        }
    });

    endpoints.MapGet("/countries/{id:range(1,5)}", async (HttpContext context) =>
    {
      
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            if (countries.ContainsKey(id))
            {
                await context.Response.WriteAsync(countries[id]);
            }
            else
            {
                await context.Response.WriteAsync("Invalid country id");
            }
    });
});


app.Run();
