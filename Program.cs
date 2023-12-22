var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/hello", (HttpContext httpContext) =>
{
    return "Hello world";
});

app.Run();