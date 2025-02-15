namespace invoice.Models;

public class Invoice
{
    public int Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string ClientIdentificationNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string InvoiceDescription { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}