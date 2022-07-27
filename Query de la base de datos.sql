create database PruebaOTekDB
use PruebaOTekDB

create table Empresa(
ID int primary key identity(1,1),
Nombre_Empresa varchar(300),
RNC varchar(50))

create table Direcciones(
ID int primary key identity(1,1),
Direccion varchar(500))

create table Clientes(
ID int primary key identity(1,1),
Nombre varchar(100),
Apellido varchar(100),
Telefono varchar(50),
Email varchar(50),
ID_Empresa int,
foreign key (ID_Empresa) references Empresa(ID))

create table ClientesDireccionesRelacion(
ID int primary key identity (1,1),
ID_Clientes int,
ID_Direcciones int,
foreign key (ID_Clientes) references Clientes(ID),
foreign key (ID_Direcciones) references Direcciones(ID))
