using DotNetEssentials.Logging.Logging;
using DotNetEssentials.Logging.Services;

var builder = WebApplication.CreateBuilder(args);

#region JSON logging in Console

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole(options => options.JsonWriterOptions = new System.Text.Json.JsonWriterOptions()
{
    Indented = true
});

#endregion

#region Redaction in logging

builder.Logging.EnableRedaction();

builder.Services.AddRedaction(x =>
{
    // TODO
});

#endregion

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

var app = builder.Build();

app.MapGet("/customer", (HttpContext httpContext, ILogger<Program> logger, ICustomerService customerService) =>
{
    logger.EndpointCalled("customer", HttpMethod.Get);

    var customer = customerService.GetCustomer();
    return TypedResults.Ok(customer);
});

app.MapGet("/invoice", (HttpContext httpContext, ILogger<Program> logger, IInvoiceService invoiceService) =>
{
    logger.EndpointCalled("invoice", HttpMethod.Get);

    var invoice = invoiceService.GetInvoice();
    return TypedResults.Ok(invoice);
});

app.Run();