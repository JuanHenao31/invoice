using invoice.DTOs;
using invoice.Models;

namespace invoice.Interfaces;

public interface IInvoiceService
{
    Task<int> CreateInvoiceAsync(InvoiceDto invoiceDto);
    Task<Invoice?> GetInvoiceByIdAsync(int id);
    Task<IEnumerable<Invoice>> SearchInvoicesByClientAsync(string clientName);
    Task<IEnumerable<Invoice>> SearchInvoicesByClientIdentificationNumberAsync(string clientIdentificationNumber);

    Task<IEnumerable<Invoice>> GetAllInvoicesAsync();

}