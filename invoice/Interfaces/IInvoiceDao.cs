using invoice.Models;

namespace invoice.Interfaces;

public interface IInvoiceDao
{
    Task<int> InsertInvoiceAsync(Invoice invoice);
    Task<Invoice?> GetInvoiceByIdAsync(int id);
    Task<IEnumerable<Invoice>> SearchInvoicesByClientAsync(string clientName);
    Task<IEnumerable<Invoice>> SearchInvoicesByClientIdentificationNumberAsync(string clientIdentificationNumber);

    Task<List<Invoice>> GetAllInvoicesAsync();
}