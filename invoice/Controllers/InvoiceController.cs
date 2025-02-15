using invoice.DTOs;
using invoice.Interfaces;
using invoice.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice.Controllers;

[ApiController]
[Route("api/invoices")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }
    
    

    /// <summary>
    /// Registra una nueva factura.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] InvoiceDto invoiceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newInvoiceId = await _invoiceService.CreateInvoiceAsync(invoiceDto);
        return CreatedAtAction(nameof(GetInvoiceById), new { id = newInvoiceId }, new { Id = newInvoiceId });
    }

    /// <summary>
    /// Obtiene una factura por su ID.
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null)
            return NotFound(new { Message = $"Invoice with ID {id} not found" });

        return Ok(invoice);
    }

    /// <summary>
    /// Busca facturas por nombre de cliente.
    /// </summary>
    [HttpGet("search/client/{clientName}")]
    public async Task<IActionResult> SearchInvoicesByClient(string clientName)
    {
        var invoices = await _invoiceService.SearchInvoicesByClientAsync(clientName);
        return Ok(invoices);
    }

    /// <summary>
    /// Busca facturas por número de identificación del cliente.
    /// </summary>
    [HttpGet("search/id/{clientIdentificationNumber}")]
    public async Task<IActionResult> SearchInvoicesByClientIdentificationNumber(string clientIdentificationNumber)
    {
        var invoices = await _invoiceService.SearchInvoicesByClientIdentificationNumberAsync(clientIdentificationNumber);
        return Ok(invoices);
    }
    
    /// <summary>
    /// Busca facturas por nombre de cliente usando query params.
    /// </summary>
    [HttpGet("search")]
    public async Task<IActionResult> SearchInvoicesByClientQueryParam([FromQuery] string client)
    {
        if (string.IsNullOrWhiteSpace(client))
        {
            return BadRequest(new { Message = "Client name is required for search." });
        }

        var invoices = await _invoiceService.SearchInvoicesByClientAsync(client);
        return Ok(invoices);
    }
}
