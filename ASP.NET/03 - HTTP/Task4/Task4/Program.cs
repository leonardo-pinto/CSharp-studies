using static System.Net.WebRequestMethods;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET")
    {
        // Example 1
        // If you receive a HTTP GET request at path "/", if firstNumber, secondNumber and operator are submitted,
        // it should perform the given operation and return HTTP 200 response.
        //Request Url: /? firstNumber = 5 & secondNumber = 2 & operation = add
        // Request Method: GET
        // Response Status Code: 200
        // Response Body(output): 7
        if (
            context.Request.Query.ContainsKey("firstNumber")
            && context.Request.Query.ContainsKey("secondNumber")
            && context.Request.Query.ContainsKey("operation")
        )
        {
            double firstNumber = int.Parse(context.Request.Query["firstNumber"]);
            double secondNumber = int.Parse(context.Request.Query["secondNumber"]);
            double result = 0;
            switch (context.Request.Query["operation"])
            {
                case "add":
                    result = firstNumber + secondNumber;
                    break;
                default:
                    break;
            }

            await context.Response.WriteAsync($"Result is {result}");
        }
    }
});

app.Run();
