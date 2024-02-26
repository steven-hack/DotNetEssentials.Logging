using DotNetEssentials.Logging.Domain;
using Microsoft.Extensions.Compliance.Classification;

namespace DotNetEssentials.Logging.Logging;

internal static class EpisodeTagProvider
{
    public static void RecordTags(ITagCollector collector, Episode episode)
    {
        collector.Add(nameof(Episode.Title), $"#{episode.Number} - {episode.Title}");
        collector.Add(nameof(Episode.Description), episode.Description, new DataClassificationSet(DataClassification.None));
    }
}