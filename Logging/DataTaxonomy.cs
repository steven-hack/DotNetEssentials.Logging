using Microsoft.Extensions.Compliance.Classification;

namespace DotNetEssentials.Logging.Logging;

/*
 * Example of defining the taxonomy for data classification.
 * This approach is used by Microsoft for classifying data inside their compliance testing package.
 * 
 * See also: https://github.com/dotnet/extensions/blob/686e13c0418bbae381ce76f4cf06cb815faa4af2/src/Libraries/Microsoft.Extensions.Compliance.Testing/FakeTaxonomy.cs
 */
public static class DataTaxonomy
{
    public static string TaxonomyName => typeof(DataTaxonomy).FullName!;

    public static DataClassification PrivateData => new(TaxonomyName, nameof(PrivateData));

    public static DataClassification SecretData => new(TaxonomyName, nameof(SecretData));
}
