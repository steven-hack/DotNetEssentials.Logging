using DotNetEssentials.Logging.Domain;

namespace DotNetEssentials.Logging.Services;

public interface IInvoiceService
{
    Invoice GetInvoice();
}

public class InvoiceService : IInvoiceService
{
    public Invoice GetInvoice()
    {
        // TODO
        return null;
    }
}