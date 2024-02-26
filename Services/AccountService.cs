using DotNetEssentials.Logging.Domain;

namespace DotNetEssentials.Logging.Services;

public interface IAccountService
{
    Account GetAccount();
}

public class AccountService() : IAccountService
{
    public Account GetAccount()
    {
        return new Account("Steven Hack", "s.hack@betabit.nl");
    }
}
