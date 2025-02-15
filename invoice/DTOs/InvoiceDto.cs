namespace invoice.DTOs;

public class InvoiceDto
{
    public string ClientName { get; set; } = string.Empty;
    public string ClientIdentificationNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string InvoiceDescription { get; set; } = string.Empty;
}