using invoice.DAO;
using invoice.Interfaces;
using invoice.Services;
using Microsoft.OpenApi.Models;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de la aplicación
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.TypeInfoResolverChain.Insert(0, new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver());
    });builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Invoice API", Version = "v1" });
});

// Inyección de dependencias (DAO y Servicio)
builder.Services.AddScoped<IInvoiceDao, InvoiceDao>();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();

// Configurar CORS (si es necesario)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Habilitar Swagger en modo desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice API v1"));
}

// Habilitar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers(); // Habilita los controladores

app.Run();