using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using invoice.Interfaces;
using invoice.Models;
using Microsoft.Extensions.Configuration;

namespace invoice.DAO;

public class InvoiceDao : IInvoiceDao
{
    private readonly string _connectionString;
    private readonly ILogger<InvoiceDao> _logger;

    public InvoiceDao(IConfiguration configuration, ILogger<InvoiceDao> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new ArgumentNullException(nameof(configuration), "Connection string 'DefaultConnection' not found.");
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> InsertInvoiceAsync(Invoice invoice)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            using var command = new SqlCommand("sp_InsertInvoice", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Definir parámetros explícitamente con sus tipos
            command.Parameters.Add(new SqlParameter("@ClientName", SqlDbType.NVarChar, 100) 
                { Value = invoice.ClientName });
            command.Parameters.Add(new SqlParameter("@ClientIdentificationNumber", SqlDbType.NVarChar, 20) 
                { Value = invoice.ClientIdentificationNumber });
            command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal) 
                { Value = invoice.Amount, Precision = 18, Scale = 2 });
            command.Parameters.Add(new SqlParameter("@InvoiceDescription", SqlDbType.NVarChar, 500) 
                { Value = invoice.InvoiceDescription });
            command.Parameters.Add(new SqlParameter("@CreatedAt", SqlDbType.DateTime) 
                { Direction = ParameterDirection.Output });

            var id = Convert.ToInt32(await command.ExecuteScalarAsync());
            _logger.LogInformation("Invoice created successfully with ID: {InvoiceId}", id);
            return id;
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "Error inserting invoice for client {ClientName}", invoice.ClientName);
            throw;
        }
    }

    public async Task<Invoice?> GetInvoiceByIdAsync(int id)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            _logger.LogInformation("Entrooo");

            await connection.OpenAsync();
            _logger.LogInformation("Entrooo 2");

            using var command = new SqlCommand("sp_GetInvoiceById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapReaderToInvoice(reader);
            }

            _logger.LogInformation("No invoice found with ID: {InvoiceId}", id);
            return null;
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "Error retrieving invoice with ID: {InvoiceId}", id);
            throw;
        }
    }
    
    public async Task<List<Invoice>> GetAllInvoicesAsync()
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                "SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt FROM Invoices", 
                connection);

            _logger.LogInformation("Getting all invoices");
            return await ReadMultipleInvoices(command); // ⚡ Asegura que devuelva una List
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "Error retrieving all invoices");
            throw;
        }
    }


    public async Task<IEnumerable<Invoice>> SearchInvoicesByClientAsync(string clientName)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand("sp_SearchInvoicesByClient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@ClientName", SqlDbType.NVarChar, 100) 
                { Value = clientName });

            return await ReadMultipleInvoices(command);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "Error searching invoices for client: {ClientName}", clientName);
            throw;
        }
    }

    public async Task<IEnumerable<Invoice>> SearchInvoicesByClientIdentificationNumberAsync(
        string clientIdentificationNumber)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand("sp_SearchInvoicesByClientIdentificationNumber", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@ClientIdentificationNumber", SqlDbType.NVarChar, 20) 
                { Value = clientIdentificationNumber });

            return await ReadMultipleInvoices(command);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, 
                "Error searching invoices for client identification number: {ClientIdentificationNumber}", 
                clientIdentificationNumber);
            throw;
        }
    }

    private static Invoice MapReaderToInvoice(SqlDataReader reader)
    {
        return new Invoice
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            ClientName = reader.GetString(reader.GetOrdinal("ClientName")),
            ClientIdentificationNumber = reader.GetString(reader.GetOrdinal("ClientIdentificationNumber")),
            Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
            InvoiceDescription = reader.GetString(reader.GetOrdinal("InvoiceDescription")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
        };
    }

    private async Task<List<Invoice>> ReadMultipleInvoices(SqlCommand command)
    {
        var invoices = new List<Invoice>();
        using var reader = await command.ExecuteReaderAsync();
    
        while (await reader.ReadAsync())
        {
            invoices.Add(MapReaderToInvoice(reader));
        }

        return invoices; // ⚡ Retorna List en lugar de IEnumerable
    }

}