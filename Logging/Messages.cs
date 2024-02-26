using DotNetEssentials.Logging.Domain;

namespace DotNetEssentials.Logging.Logging;

/*
 * Example using source generation for logging. C# 9.0 (introduced with .NET 5) or higher required.
 * 
 * 1) In this example a static partial class is used for defining the different log messages.
 *    Multiple files could be used to split up your messages, for example based on logic parts in your application.
 *    It is also possible to define these messages inside a non-static class, for example when a message is only used by a specific class.
 * 
 * 2) The LoggerMessage attribute is used to decorate a method dedicated for logging a specific message.
 *    These methods MUST be partial void. If using static, the ILogger must be provided.
 *    
 * 3) LogProperties attributes can be used to add additional properties to the log messages.
 *    OmitReferenceName can be used to omit the reference name of the property.
 *    SkipNullProperties can be used to skip null properties.
 * 
 * See also: https://learn.microsoft.com/en-us/dotnet/core/extensions/logger-message-generator
 */
public static partial class Messages
{
    [LoggerMessage(Level = LogLevel.Debug, Message = "API endpoint {endpoint} called using HTTP method {method}.")]
    public static partial void EndpointCalled(this ILogger logger, string endpoint, HttpMethod method);

    #region Log properties

    [LoggerMessage(Level = LogLevel.Information, Message = "Episode retrieved.")]
    public static partial void EpisodeRetrieved(this ILogger logger, [LogProperties] Episode episode);

    [LoggerMessage(Level = LogLevel.Information, Message = "Speaker retrieved.")]
    public static partial void SpeakerRetrieved(this ILogger logger, [LogProperties] Speaker speaker);

    #endregion Log properties

    #region Tag Provider

    [LoggerMessage(Level = LogLevel.Information, Message = "Special episode retrieved.")]
    public static partial void SpecialEpisodeRetrieved(this ILogger logger, [TagProvider(typeof(EpisodeTagProvider), nameof(EpisodeTagProvider.RecordTags))] Episode episode);

    #endregion Tag Provider
}
