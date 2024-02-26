using Microsoft.Extensions.Diagnostics.Enrichment;

namespace DotNetEssentials.Logging.Logging;

public class EnvironmentEnricher : IStaticLogEnricher
{
    public void Enrich(IEnrichmentTagCollector collector)
    {
        collector.Add("MachineName", Environment.MachineName);
        collector.Add("Is64BitOperatingSystem", Environment.Is64BitOperatingSystem);
    }
}
