using DotNetEssentials.Logging.Domain;
using DotNetEssentials.Logging.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetEssentials.Logging.Services;

public interface IBetatalksService
{
    List<Episode> GetEpisodes();

    Episode GetEpisode(int number);

    List<Speaker> GetSpeakers();

    Speaker GetSpeaker(string firstName);
}

public class BetatalksService(ILogger<BetatalksService> logger) : IBetatalksService
{
    private readonly List<Episode> episodes =
    [
        new Episode(1, "Basics of logging", "Learn the basic way of logging in .NET"),
        new Episode(2, "Centralize your messages using LoggerMessage", "Find out how to use the LoggerMessage attribute."),
        new Episode(3, "Extend your messages with LogProperties", "Learn how to extend your log messages with LogProperties."),
        new Episode(4, "Customize using Tag Providers", "Learn how to customize your message using Tag Providers.")
    ];

    private readonly List<Speaker> speakers =
    [
        new Speaker("Steven", "Hack", "Eindhoven"),
        new Speaker("Gerben", "van de Wiel", "Rotterdam")
    ];

    public List<Episode> GetEpisodes() => episodes;

    public Episode GetEpisode(int number)
    {
        var episode = 
            episodes.SingleOrDefault(x => x.Number == number)
            ?? throw new ArgumentOutOfRangeException(nameof(number), "Episode not found.");

        logger.EpisodeRetrieved(episode);

        return episode;
    }

    public List<Speaker> GetSpeakers() => speakers;

    public Speaker GetSpeaker(string firstName)
    {
        var speaker =
        speakers.SingleOrDefault(x => x.FirstName == firstName)
            ?? throw new ArgumentOutOfRangeException(nameof(firstName), "Speaker not found.");

        logger.SpeakerRetrieved(speaker);

        return speaker;
    }
}
