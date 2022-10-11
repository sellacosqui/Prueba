Create database MiguelVP_Prueba;
go
Use MiguelVP_Prueba;
go
Create table Usuarios
(
	Id int identity(1, 1) primary key,
	Contraseña varchar(10),
	Email varchar(150)
);
go
Create table Clima
(
	Id int identity(1, 1) primary key,
	Ciudad varchar(100) not null,
	precipitaciones varchar(50),
	Fecha date,
	Hora Time,
	Temperatura varchar(10) not null,
	Humendad float not null,
	Viento varchar(10) not null,
);

go
Insert Into Usuarios Values( 'admin', 'Miguel@prueba.com');