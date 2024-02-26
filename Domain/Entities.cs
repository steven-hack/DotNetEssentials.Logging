namespace DotNetEssentials.Logging.Domain;

public class Account(string name, string email)
{
    public string Name { get; } = name;

    public string Email { get; } = email;
}

public record Address(string AddressLine, string Zipcode, string City);

public record Customer(string SocialSecurityNumber, string Name, string Email, Address Address)
{
    public Guid Id { get; } = Guid.NewGuid();
}

public record Invoice(Guid CustomerId, string CreditCardNumber, string Amount)
{
    public Guid TransactionId { get; } = Guid.NewGuid();
}