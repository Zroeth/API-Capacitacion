USE [CAPACITACION]
GO
INSERT INTO Bancos (Nombre, NumeroProveedor, NumeroContrato) VALUES
('BI', 0001, 0001),
('BAM', 0002, 0002),
('BANTRAB', 0003, 0003);
GO

INSERT INTO Clientes (CodigoCliente, Nombres, Direccion, Telefono, MontoDeuda, NIT) VALUES
(1, 'Juan P�rez', '4ta calle 5-55 zona 1, Ciudad Guatemala', '30001122', 1200.50, '1234567-K'),
(2, 'Ana L�pez', '6ta avenida 12-60 zona 2, Ciudad Guatemala', '30002233', 1500.75, '2345678-L'),
(3, 'Carlos Mart�nez', 'Diagonal 10 10-01 zona 10, Ciudad Guatemala', '30003344', 1800.25, '3456789-M'),
(4, 'Luisa Fern�ndez', '7ma calle 3-11 zona 3, Ciudad Guatemala', '30004455', 2000.00, '4567890-N'),
(5, 'Mario Gonz�lez', 'Avenida Las Am�ricas 14-80 zona 13, Ciudad Guatemala', '30005566', 2500.60, '5678901-O');

GO
--Aunque no son errores
INSERT INTO Log (Clase, Metodo, DescripcionError, Fecha) VALUES
('Cliente', 'Crear', 'Cliente Juan P�rez creado exitosamente', GETDATE()),
('Cliente', 'Crear', 'Cliente Ana L�pez creado exitosamente', GETDATE()),
('Cliente', 'Crear', 'Cliente Carlos Mart�nez creado exitosamente', GETDATE()),
('Cliente', 'Crear', 'Cliente Luisa Fern�ndez creado exitosamente', GETDATE()),
('Cliente', 'Crear', 'Cliente Mario Gonz�lez creado exitosamente', GETDATE());
GO
