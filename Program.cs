using DotNetEssentials.Logging.Logging;
using DotNetEssentials.Logging.Services;
using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;

var builder = WebApplication.CreateBuilder(args);

#region JSON logging in Console

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole(options => options.JsonWriterOptions = new System.Text.Json.JsonWriterOptions()
{
    Indented = true
});

#endregion

#region Enrichment in logging

// builder.Logging.EnableEnrichment();

// builder.Services.AddProcessLogEnricher(options =>
// {
//     options.ProcessId = true;
//     options.ThreadId = true;
// });

// builder.Services.AddServiceLogEnricher(options =>
// {
//     options.ApplicationName = true;
//     options.BuildVersion = true;
//     options.DeploymentRing = true;
//     options.EnvironmentName = true;
// });

#region Custom enricher

//builder.Services.AddStaticLogEnricher<EnvironmentEnricher>();
//builder.Services.AddLogEnricher<AccountEnricher>();

#endregion Custom enricher

#endregion Enrichment in logging

#region Redaction in logging

builder.Logging.EnableRedaction();

builder.Services.AddRedaction(x =>
{
    x.SetRedactor<ErasingRedactor>(new DataClassificationSet(DataTaxonomy.PrivateData));

#pragma warning disable EXTEXP0002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    x.SetHmacRedactor(options =>
    {
        options.Key = Convert.ToBase64String("ReplaceThisValueForASecurelyStoredOne!"u8);
        options.KeyId = 1234;
    }, new DataClassificationSet(DataTaxonomy.SecretData));
#pragma warning restore EXTEXP0002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

    #region Custom redactor

    //x.SetRedactor<StarRedactor>(new DataClassificationSet(DataTaxonomy.PrivateData));

    #endregion Custom redactor
});

#endregion

builder.Services.AddTransient<IBetatalksService, BetatalksService>();

var app = builder.Build();

app.MapGet("/basics", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.LogDebug("API endpoint {endpoint} called using HTTP method {method}.", "Basics", HttpMethod.Get);

    var episode = episodeService.GetEpisodes().Where(x => x.Number == 1);
    return TypedResults.Ok(episode);
});

app.MapGet("/logger-message", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.EndpointCalled("Logger Message", HttpMethod.Get);

    var episode = episodeService.GetEpisodes().Where(x => x.Number == 2);
    return TypedResults.Ok(episode);
});

app.MapGet("/log-properties", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.EndpointCalled("Log properties", HttpMethod.Get);

    var episode = episodeService.GetEpisode(3);
    return TypedResults.Ok(episode);
});

app.MapGet("/tag-provider", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.EndpointCalled("Tag provider", HttpMethod.Get);

    var episode = episodeService.GetEpisode(4);
    logger.SpecialEpisodeRetrieved(episode);
    return TypedResults.Ok(episode);
});

app.MapGet("/redactors", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.EndpointCalled("Redactors", HttpMethod.Get);

    var speaker = episodeService.GetSpeaker("Steven");
    return TypedResults.Ok(speaker);
});

app.MapGet("/custom-redactor", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.EndpointCalled("Custom redactor", HttpMethod.Get);

    var speaker = episodeService.GetSpeaker("Gerben");
    return TypedResults.Ok(speaker);
});

app.MapGet("/enrichers", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.EndpointCalled("Enrichers", HttpMethod.Get);

    var speaker = episodeService.GetSpeaker("Steven");
    return TypedResults.Ok(speaker);
});

app.MapGet("/custom-enricher", (HttpContext httpContext, ILogger<Program> logger, IBetatalksService episodeService) =>
{
    logger.EndpointCalled("Custom enricher", HttpMethod.Get);

    var speaker = episodeService.GetSpeaker("Gerben");
    return TypedResults.Ok(speaker);
});

app.Run();