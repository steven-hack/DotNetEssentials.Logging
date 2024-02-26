using DotNetEssentials.Logging.Logging;

namespace DotNetEssentials.Logging.Domain;

public class Episode(int number, string title, string description)
{
    public int Number { get; } = number;

    public string Title { get; } = title;

    public string Description { get; } = description;
}

public class Speaker(string firstName, string lastName, string location)
{
    public string FirstName { get; } = firstName;

    [PrivateData]
    public string LastName { get; } = lastName;

    [SecretData]
    public string Location { get; } = location;
}