-- =============================================
-- CREACIÓN BASE DE DATOS
-- =============================================
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Restaurante')
BEGIN
    ALTER DATABASE Restaurante SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Restaurante;
END;
GO

CREATE DATABASE Restaurante;
GO

USE Restaurante;
GO

-- =============================================
-- TABLAS
-- =============================================

-- TABLA CATEGORÍAS DE INSUMOS
CREATE TABLE categorias_insumos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

-- TABLA INSUMOS
CREATE TABLE insumos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    stock INT NOT NULL,
    id_categoria INT,
    fecha_modificacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_categoria) REFERENCES categorias_insumos(id)
);

-- TABLA PROVEEDORES
CREATE TABLE proveedores (
    id INT IDENTITY(1,1) PRIMARY KEY,
    documento VARCHAR(11) NOT NULL UNIQUE,
    nombres VARCHAR(100) NOT NULL,
    telefono VARCHAR(15) NOT NULL,
    direccion VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NOT NULL,
    fecha_modificacion DATETIME DEFAULT GETDATE()
);

-- TABLA ORDEN DE COMPRA 
CREATE TABLE orden_compra (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_proveedor INT NOT NULL,
    observaciones VARCHAR(255),
    monto_total DECIMAL(10,2) DEFAULT 0,
    fecha_modificacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_proveedor) REFERENCES proveedores(id)
);

-- TABLA DETALLE DE COMPRA PROVEEDOR 
CREATE TABLE detalle_compra_proveedor (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_orden_compra INT NOT NULL,
    id_insumo INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unit DECIMAL(10,2) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    fecha_modificacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_orden_compra) REFERENCES orden_compra(id),
    FOREIGN KEY (id_insumo) REFERENCES insumos(id)
);

-- =============================================
-- DATOS DE PRUEBA
-- =============================================

-- Insertar categorías
INSERT INTO categorias_insumos (nombre) VALUES
('Lácteos'), ('Carnes'), ('Verduras'), ('Frutas'), ('Cereales'),
('Condimentos'), ('Bebidas'), ('Panadería');

-- Insertar insumos
INSERT INTO insumos (nombre, stock, id_categoria) VALUES
('Leche Entera', 100, 1),
('Queso Fresco', 50, 1),
('Carne de Res', 80, 2),
('Pollo Entero', 60, 2),
('Zanahoria', 200, 3),
('Tomate', 150, 3),
('Manzana', 120, 4),
('Plátano', 100, 4),
('Arroz', 300, 5),
('Lentejas', 250, 5),
('Sal', 500, 6),
('Pimienta', 200, 6),
('Agua Mineral', 400, 7),
('Refresco Cola', 350, 7),
('Pan de Molde', 180, 8),
('Croissant', 100, 8);

-- Insertar proveedores
INSERT INTO proveedores (documento, nombres, telefono, direccion, correo) VALUES
('12345678901', 'Proveedor Lácteos S.A.', '987654321', 'Av. Siempre Viva 123', 'contacto@lacteos.com'),
('23456789012', 'Carnes del Sur EIRL', '987123456', 'Calle Falsa 456', 'ventas@carnesdelsur.com'),
('34567890123', 'Verduras Frescas SAC', '987321654', 'Jr. Huertos 789', 'info@verdurasfrescas.com'),
('45678901234', 'Frutas del Valle', '987987987', 'Av. Las Flores 321', 'ventas@frutasvalle.com'),
('56789012345', 'Cereales Andinos', '986543210', 'Jr. Los Andes 654', 'cereales@andinos.com'),
('67890123456', 'Condimentos Gourmet', '985678432', 'Av. Sazonadores 987', 'info@condigourmet.com'),
('78901234567', 'Bebidas Globales', '984567890', 'Calle Gasificada 159', 'contacto@bebidasglobales.com'),
('89012345678', 'Panadería Moderna', '983456789', 'Av. Harina 753', 'ventas@panmoderna.com'),
('90123456789', 'Proveedor Mixto A', '982345678', 'Jr. Comercio 852', 'ventas@mixtoa.com'),
('01234567890', 'Proveedor Mixto B', '981234567', 'Calle Central 951', 'contacto@mixtob.com');

-- Insertar órdenes de compra (para que los detalles no fallen con FK)
INSERT INTO orden_compra (id_proveedor, observaciones, monto_total) VALUES
(1, 'Primera orden con lácteos', 0),
(2, 'Orden de carnes y embutidos', 0),
(3, 'Orden de verduras frescas', 0),
(4, 'Orden de frutas varias', 0),
(5, 'Cereales y granos', 0),
(6, 'Condimentos varios', 0),
(7, 'Bebidas sin alcohol', 0),
(8, 'Bebidas y panadería', 0),
(9, 'Panadería y repostería', 0),
(10, 'Carnes y verduras mixtas', 0);

-- Insertar detalle de compras
INSERT INTO detalle_compra_proveedor (id_orden_compra, id_insumo, cantidad, precio_unit, total) VALUES
(1, 1, 20, 2.50, 50.00),
(1, 2, 10, 5.00, 50.00),
(2, 3, 15, 10.00, 150.00),
(2, 4, 10, 8.00, 80.00),
(3, 5, 30, 1.00, 30.00),
(3, 6, 25, 1.20, 30.00),
(4, 7, 40, 0.80, 32.00),
(4, 8, 50, 0.70, 35.00),
(5, 9, 100, 0.90, 90.00),
(5, 10, 80, 1.10, 88.00),
(6, 11, 60, 0.50, 30.00),
(6, 12, 40, 1.50, 60.00),
(7, 13, 70, 0.60, 42.00),
(7, 14, 60, 1.20, 72.00),
(8, 15, 50, 2.00, 100.00),
(8, 16, 30, 1.80, 54.00),
(9, 15, 40, 2.00, 80.00),
(9, 16, 25, 1.80, 45.00),
(10, 3, 20, 10.00, 200.00),
(10, 5, 50, 1.00, 50.00);


select * from proveedores