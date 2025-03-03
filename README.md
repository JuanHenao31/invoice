🧾 **Invoice API**
------------------

API REST para la gestión de facturas utilizando **ASP.NET Core**, **SQL Server** y **procedimientos almacenados**.

📌 **Requisitos Previos**
-------------------------

### **1️⃣ Tecnologías y Versiones**

*   **.NET**: 8.0 (o superior)

*   **SQL Server**: 2022 (o superior)

*   **Docker (opcional)**: Si deseas correr SQL Server en un contenedor.


### **2️⃣ Instalación de Dependencias**

Si aún no tienes .NET y SQL Server, instala:

*   [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

*   [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) o usa Docker.


⚙ **Configuración del Proyecto**
--------------------------------

### **1️⃣ Clonar el Repositorio**

git clone https://github.com/tu-usuario/invoice-api.git
cd invoice-api


### **2️⃣ Configurar SQL Server**

Si usas **Docker**, ejecuta:

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest


Si usas una instalación local, crea la base de datos **business** y los procedimientos almacenados.

🛠 **Configuración de la Base de Datos**
----------------------------------------

### **1️⃣ Crear la Base de Datos**

Ejecuta en SQL Server:


CREATE DATABASE business;
GO
USE business;


### **2️⃣ Crear la Tabla Invoices**

CREATE TABLE Invoices (
Id INT IDENTITY(1,1) PRIMARY KEY,
ClientName NVARCHAR(100) NOT NULL,
ClientIdentificationNumber NVARCHAR(50) NOT NULL,
Amount DECIMAL(10,2) NOT NULL,
InvoiceDescription NVARCHAR(255) NULL,
CreatedAt DATETIME DEFAULT GETDATE()
);


### **3️⃣ Crear los Procedimientos Almacenados**

Ejecuta en SQL Server:

USE business;
GO

CREATE PROCEDURE sp_InsertInvoice
@ClientName NVARCHAR(100),
@ClientIdentificationNumber NVARCHAR(50),
@Amount DECIMAL(10,2),
@InvoiceDescription NVARCHAR(255),
@CreatedAt DATETIME OUTPUT
AS
BEGIN
SET @CreatedAt = GETDATE();

    INSERT INTO Invoices (ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt)
    VALUES (@ClientName, @ClientIdentificationNumber, @Amount, @InvoiceDescription, @CreatedAt);
    
    SELECT SCOPE_IDENTITY() AS Id;
END;
GO


#### 📌 **Insertar Factura (sp\_InsertInvoice)**

USE business;
GO

CREATE PROCEDURE sp_GetInvoiceById
@Id INT
AS
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE Id = @Id;
END;
GO

#### 📌 **Obtener Factura por ID (sp\_GetInvoiceById)**

USE business;
GO

CREATE PROCEDURE sp_SearchInvoicesByClient
@ClientName NVARCHAR(100)
AS
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE ClientName LIKE '%' + @ClientName + '%';   
END;
GO

#### 📌 **Buscar Facturas por Nombre de Cliente (sp\_SearchInvoicesByClient)**

USE business;
GO

CREATE PROCEDURE sp_SearchInvoicesByClientIdentificationNumber
@ClientIdentificationNumber NVARCHAR(50)
AS
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE ClientIdentificationNumber LIKE '%' + @ClientIdentificationNumber + '%';
END;
GO

#### 📌 **Buscar Facturas por Identificación del Cliente (sp\_SearchInvoicesByClientIdentificationNumber)**

USE business;
GO

CREATE PROCEDURE sp_SearchInvoicesByClientIdentificationNumber
@ClientIdentificationNumber NVARCHAR(50)
AS
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE ClientIdentificationNumber LIKE '%' + @ClientIdentificationNumber + '%';
END;
GO

🚀 **Configuración del Proyecto en .NET**
-----------------------------------------

### **1️⃣ Instalar Dependencias**

dotnet restore

### **2️⃣ Configurar la Cadena de Conexión**


{
"ConnectionStrings": {
"DefaultConnection": "Server=localhost,1433;Database=business;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
}
}

### **3️⃣ Ejecutar la API**

dotnet run

La API se ejecutará en:📌 http://localhost:5002

📡 **Endpoints de la API**
--------------------------

### 📌 **Crear una Factura**

{
"clientName": "Juan Pérez",
"clientIdentificationNumber": "123456789",
"amount": 150.75,
"invoiceDescription": "Compra de equipos de oficina"
}

### 📌 **Obtener una Factura por ID**

curl -X GET "http://localhost:5002/api/invoices/1"


### 📌 **Buscar Facturas por Cliente (?client=nombre)**

curl -X GET "http://localhost:5002/api/invoices/search?client=Juan%20Pérez"

### 📌 **Buscar Facturas por Identificación de Cliente**

curl -X GET "http://localhost:5002/api/invoices/search/id/123456789"

🛠 **Herramientas Recomendadas**
--------------------------------

*   **Postman** para probar endpoints.

*   **Swagger UI** disponible en:📌 http://localhost:5002/swagger/index.html


🏁 **Conclusión**
-----------------

Esta API permite gestionar facturas usando ASP.NET Core y SQL Server. **Sigue los pasos y ejecuta las pruebas**. 🚀

Si necesitas ajustes o mejoras, dime y los hacemos. 🎯

--------------------------------

🧾 **Invoice API**
------------------

REST API for invoice management using **ASP.NET Core**, **SQL Server** and **stored procedures**.

📌 **Prerequisites**
-------------------------

### **1️⃣ Technologies and Versions**

* **.NET**: 8.0 (or higher)

* **SQL Server**: 2022 (or higher)

* **Docker (optional)**: If you want to run SQL Server in a container.

### **2️⃣ Installing Dependencies**

If you don't have .NET and SQL Server yet, install:

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or use Docker.

⚙ **Project Setup**
--------------------------------

### **1️⃣ Clone the Repository**

git clone https://github.com/your-user/invoice-api.git
cd invoice-api

### **2️⃣ Configure SQL Server**

If you are using **Docker**, run:

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

If you are using a local installation, create the **business** database and stored procedures.

🛠 **Database Configuration**
----------------------------------------

### **1️⃣ Create the Database**

Run on SQL Server:

CREATE DATABASE business;
GO
USE business;

### **2️⃣ Create the Invoices Table**

CREATE TABLE Invoices (
Id INT IDENTITY(1,1) PRIMARY KEY,
ClientName NVARCHAR(100) NOT NULL,
ClientIdentificationNumber NVARCHAR(50) NOT NULL,
Amount DECIMAL(10,2) NOT NULL,
InvoiceDescription NVARCHAR(255) NULL,
CreatedAt DATETIME DEFAULT GETDATE()
);

### **3️⃣ Create the Stored Procedures**

Run on SQL Server:

USE business;
GO

CREATE PROCEDURE sp_InsertInvoice
@ClientName NVARCHAR(100),
@ClientIdentificationNumber NVARCHAR(50),
@Amount DECIMAL(10,2),
@InvoiceDescription NVARCHAR(255),
@CreatedAt DATETIME OUTPUT
ACE
BEGIN
SET @CreatedAt = GETDATE();

INSERT INTO Invoices (ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt)
VALUES (@ClientName, @ClientIdentificationNumber, @Amount, @InvoiceDescription, @CreatedAt);

SELECT SCOPE_IDENTITY() AS Id;
END;
GO


#### 📌 **Insert Invoice (sp\_InsertInvoice)**

USE business;
GO

CREATE PROCEDURE sp_GetInvoiceById
@Id INT
ACE
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE Id = @Id;
END;
GO

#### 📌 **Get Invoice by ID (sp\_GetInvoiceById)**

USE business;
GO

CREATE PROCEDURE sp_SearchInvoicesByClient
@ClientName NVARCHAR(100)
ACE
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE ClientName LIKE '%' + @ClientName + '%';
END;
GO

#### 📌 **Search Invoices by Client Name (sp\_SearchInvoicesByClient)**

USE business;
GO

CREATE PROCEDURE sp_SearchInvoicesByClientIdentificationNumber
@ClientIdentificationNumber NVARCHAR(50)
ACE
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE ClientIdentificationNumber LIKE '%' + @ClientIdentificationNumber + '%';
END;
GO

#### 📌 **Search Invoices by Customer ID (sp\_SearchInvoicesByClientIdentificationNumber)**

USE business;
GO

CREATE PROCEDURE sp_SearchInvoicesByClientIdentificationNumber
@ClientIdentificationNumber NVARCHAR(50)
ACE
BEGIN
SELECT Id, ClientName, ClientIdentificationNumber, Amount, InvoiceDescription, CreatedAt
FROM Invoices
WHERE ClientIdentificationNumber LIKE '%' + @ClientIdentificationNumber + '%';
END;
GO

🚀 **.NET Project Configuration**
----------------------------------------

### **1️⃣ Install Dependencies**

dotnet restore

### **2️⃣ Configure the Connection String**

{
"ConnectionStrings": {
"DefaultConnection": "Server=localhost,1433;Database=business;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
}
}

### **3️⃣ Run the API**

dotnet run

The API will run at:📌 http://localhost:5002

📡 **API Endpoints**
--------------------------

### 📌 **Create an Invoice**

{
"clientName": "John Doe",
"clientIdentificationNumber": "123456789",
"amount": 150.75,
"invoiceDescription": "Purchase of office equipment"
}

### 📌 **Get an Invoice by ID**

curl -X GET "http://localhost:5002/api/invoices/1"

### 📌 **Search Invoices by Client (?client=name)**

curl -X GET "http://localhost:5002/api/invoices/search?client=Juan%20Pérez"

### 📌 **Search Invoices by Client ID**

curl -X GET "http://localhost:5002/api/invoices/search/id/123456789"

🛠 **Recommended Tools**
--------------------------------

* **Postman** for testing endpoints.

* **Swagger UI** available at:📌 http://localhost:5002/swagger/index.html

🏁 **Conclusion**
-----------------

This API allows you to manage invoices using ASP.NET Core and SQL Server. **Follow the steps and run the tests**. 🚀

If you need any adjustments or improvements, let me know and we'll do them.