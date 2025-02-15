using invoice.DAO;
using invoice.DTOs;
using invoice.Interfaces;
using invoice.Models;

namespace invoice.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceDao _invoiceDao;

    public InvoiceService(IInvoiceDao invoiceDao)
    {
        _invoiceDao = invoiceDao;
    }

    public async Task<int> CreateInvoiceAsync(InvoiceDto invoiceDto)
    {
        // Validaciones básicas antes de insertar en la BD
        if (string.IsNullOrWhiteSpace(invoiceDto.ClientName) || string.IsNullOrWhiteSpace(invoiceDto.ClientIdentificationNumber))
            throw new ArgumentException("El nombre del cliente y el número de identificación son obligatorios.");

        if (invoiceDto.Amount <= 0)
            throw new ArgumentException("El monto de la factura debe ser mayor que 0.");

        // Crear objeto de Invoice a partir del DTO
        var invoice = new Invoice
        {
            ClientName = invoiceDto.ClientName,
            ClientIdentificationNumber = invoiceDto.ClientIdentificationNumber,
            Amount = invoiceDto.Amount,
            InvoiceDescription = invoiceDto.InvoiceDescription
        };

        return await _invoiceDao.InsertInvoiceAsync(invoice);
    }

    public async Task<Invoice?> GetInvoiceByIdAsync(int id)
    {
        return await _invoiceDao.GetInvoiceByIdAsync(id); // Corregido, ahora usa _invoiceDao
    }

    public async Task<IEnumerable<Invoice>> SearchInvoicesByClientAsync(string clientName)
    {
        return await _invoiceDao.SearchInvoicesByClientAsync(clientName);
    }

    public async Task<IEnumerable<Invoice>> SearchInvoicesByClientIdentificationNumberAsync(string clientIdentificationNumber)
    {
        return await _invoiceDao.SearchInvoicesByClientIdentificationNumberAsync(clientIdentificationNumber);
    }

    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await _invoiceDao.GetAllInvoicesAsync();
    }
}