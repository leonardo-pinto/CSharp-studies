var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routing
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Route parameters
    endpoints.Map("files/{filename}.{extension}", async (HttpContext context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"filename is {filename}");
        await context.Response.WriteAsync($"extension is {extension}");

    });

    // Default Parameters
    endpoints.Map("products/details/{id=1}", async (HttpContext context) =>
    {
        string? id = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"id is {id}");
    });

    // Optional Parameters
    //endpoints.Map("employee/{id?}", async (HttpContext context) =>
    //{
    //    // check if parameter exists
    //    if (context.Request.RouteValues.ContainsKey("id")) { 
    //        string? id = Convert.ToString(context.Request.RouteValues["id"]);
    //        await context.Response.WriteAsync($"id is {id}");
    //    }
    //    else
    //    {
    //        await context.Response.WriteAsync("Id was not informed");
    //    }
    //});

    // Route Constraints with int
    endpoints.Map("employee/{id:int?}", async (HttpContext context) =>
    {
        // check if parameter exists
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"id is {id}");
        }
        else
        {
            await context.Response.WriteAsync("Id was not informed");
        }
    });

    // Route Constraints with DateTime
    // daily-digest-report/{reportdate}
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async (HttpContext context) =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");
    });

    // Route Constraints with Guid
    // citites/{cityid}
    endpoints.Map("cities/{cityid:guid}", async (HttpContext context) => {
        Guid cityid = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City id is {cityid}");
    });

    // Route Constraints with Length
    // min, max, range (values)
    // minLength, maxLength, length (string)
    // regex
    endpoints.Map("login/{username:length(4,10)}", async (HttpContext context) =>
    {
        string? username = Convert.ToString(context.Request.RouteValues["username"]);
        await context.Response.WriteAsync($"username is {username}");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
