using Microsoft.Extensions.Compliance.Classification;

namespace DotNetEssentials.Logging.Logging;

public sealed class SecretDataAttribute : DataClassificationAttribute
{
    public SecretDataAttribute() : base(DataTaxonomy.SecretData)
    {
    }
}

public sealed class PrivateDataAttribute : DataClassificationAttribute
{
    public PrivateDataAttribute() : base(DataTaxonomy.PrivateData)
    {
    }
}