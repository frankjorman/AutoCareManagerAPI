CREATE DATABASE AutoCareManager;

USE  AutoCareManager;

CREATE TABLE Empleado(
idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
nombre VARCHAR(250) NOT NULL,
apellido VARCHAR(250) NOT NULL,
cargo VARCHAR(250) NOT NULL,
estado BIT NOT NULL
)
INSERT INTO Empleado (nombre,apellido,cargo,estado) VALUES('Admin','','admin',1);

CREATE TABLE Usuario(
idUsuario INT IDENTITY(1,1) PRIMARY KEY,
username VARCHAR(250) NOT NULL,
password VARCHAR(250) NOT NULL,
rol VARCHAR(250) NOT NULL,
idEmpleado int
)

INSERT INTO Usuario (username,password,rol,idEmpleado) VALUES('admin','admin','admin',1);

CREATE TABLE Configuracion (
	codigo VARCHAR(50) PRIMARY KEY,
	descripcion VARCHAR(250),
	grupo char(1)
)

INSERT INTO Configuracion VALUES ('1','DATOS DEL TALLER','0')
INSERT INTO Configuracion VALUES ('2','IMAGENES DEL TALLER','0')
INSERT INTO Configuracion VALUES ('nombre','AutoCareManager','1')
INSERT INTO Configuracion VALUES ('direccion','Av. Javier prado 220','1')
INSERT INTO Configuracion VALUES ('telefono','222-3456','1')
INSERT INTO Configuracion VALUES ('correo','AutoCareManager@gmail.com','1')
INSERT INTO Configuracion VALUES ('Logo','https://i.pinimg.com/550x/b7/76/53/b77653e9597f386143bc003ab04604a3.jpg','2')
INSERT INTO Configuracion VALUES ('R','Reparacion','3')
INSERT INTO Configuracion VALUES ('M','Mantenimiento','3')


CREATE TABLE Servicios(
	idSercicios INT IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(250),
	codigo varchar(10),
	tipo varchar(10),

)

INSERT INTO Servicios VALUES ('Mantenimiento Preventivo','MP','M')
INSERT INTO Servicios VALUES ('Mantenimiento Correctivo','MC','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Frenos','MF','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Suspensión y Dirección','MSD','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Transmisión','MT','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Aire Acondicionado y Calefacción','MAAC','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Motor','MM','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Neumóticos','MN','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Electrónica','MEL','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Escape','MES','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Emisiones','MEM','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Carroceróa y Pintura','MCP','M')
INSERT INTO Servicios VALUES ('Mantenimiento de Sistemas de Seguridad','MSS','M')

CREATE TABLE Cliente(
	idCliente INT IDENTITY(1,1) PRIMARY KEY,
	numDocumento VARCHAR(50),
	nombre VARCHAR(250),
	telefono VARCHAR(50),
	correo VARCHAR(50)
)

CREATE TABLE Vehiculo(
	idVehiculo INT IDENTITY(1,1) PRIMARY KEY,
	marca VARCHAR(50),
	modelo VARCHAR(250),
	anio VARCHAR(50),
	placa VARCHAR(50),
)

CREATE TABLE ServicioRealizados(
	idServicioRealizados INT IDENTITY(1,1) PRIMARY KEY,
	fecha DATETIME,
	idVehiculo INT,
	idCliente INT,
	Servicio INT,
	codigo VARCHAR(50)
)