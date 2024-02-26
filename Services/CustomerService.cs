using DotNetEssentials.Logging.Domain;
using DotNetEssentials.Logging.Logging;

namespace DotNetEssentials.Logging.Services;

public interface ICustomerService
{
    Customer GetCustomer();
}

public class CustomerService(ILogger<CustomerService> logger, IAccountService accountService) : ICustomerService
{
    public Customer GetCustomer()
    {
        var account = accountService.GetAccount();

        var address = new Address("Lichtenauerlaan 152", "3062 ME", "Rotterdam");
        var customer = new Customer("SN123456789", "Steven Hack", "s.hack@betabit.nl", address);

        logger.CustomerRetrieved(account, customer);
        return customer;
    }
}
