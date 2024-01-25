USE [CAPACITACION]
GO

CREATE TABLE Bancos (
    Nombre NVARCHAR(255) PRIMARY KEY,
    NumeroProveedor INT,
    NumeroContrato INT
);
GO

CREATE TABLE Log (
    IdLog INT PRIMARY KEY IDENTITY(1,1),
    Clase NVARCHAR(255),
    Metodo NVARCHAR(255),
    DescripcionError NVARCHAR(MAX),
    Fecha DATETIME
);
GO

CREATE TABLE Clientes (
    CodigoCliente INT PRIMARY KEY,
    Nombres NVARCHAR(255),
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(50),
    MontoDeuda DECIMAL(10, 2),
    NIT NVARCHAR(50)
);
GO
