--Base de datos para Ecommerce
Create database DbEcommerce
Use DbEcommerce

--Creamos la tablas
Create table Categoria(
IdCategoria int primary key identity,
Nombre Varchar(50),
FechaCreacion datetime default getdate()
)

Create table Producto(
IdProducto int primary key identity,
Nombre Varchar(50),
Descripcion Varchar(1000),
IdCategoria int references Categoria(IdCategoria),
Precio Decimal(10,2),
PrecioOferta Decimal(10,2),
Cantidad Int,
Imagen Varchar(max),
FechaCreacion datetime default getdate()
)

Create table Usuario(
IdUsuario int primary key identity,
NombreCompleto Varchar(50),
Correo Varchar(50),
Clave Varchar(50),
Rol Varchar(50),--Administrador , Cliente
FechaCreacion DateTime default getdate()
)

Create Table Venta(
IdVenta int primary key identity,
IdUsuario int references Usuario(IdUsuario),
Total Decimal(10,2),
FechaCreacion datetime default getdate()
)

Create table DetalleVenta
(
IdDetalleVenta int primary key identity,
IdVenta int references Venta(IdVenta),
IdProducto int references Producto(IdProducto),
Cantidad int,
Total Decimal(10,2)
)
Select * from Usuario
Insert into Usuario(NombreCompleto,Correo,Clave,Rol)Values('administrador','admin@example.com','123','Administrador')

Insert into Categoria (Nombre) Values('test')
Select * from Categoria