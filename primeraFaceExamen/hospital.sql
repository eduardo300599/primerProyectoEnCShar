CREATE DATABASE Hospital
go

USE Hospital
go

create table fechaDeContratacion
(
	idFecha int identity(1,1) not null,
	dia nvarchar(10) not null,
	mes nvarchar(10) not null,
	año nvarchar(10) not null,

	constraint pk_fechaDeContratacion_idFecha primary key clustered(idFecha),
)
go

create table cargo
(
	idCargo int identity(1,1),
	jefeDeArea nvarchar(20),
	secretario nvarchar(20),
	administrador nvarchar(20),

	constraint pk_cargo_idCargo primary key clustered(idCargo)
)
go

create table empleados
(
	idEmpleado int identity(1,1) not null,
	cargo nvarchar(20) not null,
	salario nvarchar(10) not null,
	areaDeTrabajo nvarchar(10) not null,
	idUsuario int,
	idFecha int,
	idCargo int,

	constraint pk_empleados_idEmpleados primary key clustered(idEmpleado),
	constraint fk_FechaDeContratacion foreign key(idFecha) references FechaDeContratacion(idFecha),
	constraint fk_cargo foreign key(idCargo) references cargo(idCargo)
)
go

create table usuario
(
	idUsuario int identity(1,1) not null,
	nombre nvarchar(50) null,
	nombreDeUsuario nvarchar(50) not null,
	contrasenia nvarchar(50) not null,
	idEmpleado int,

	constraint pk_usuario_idUsuario primary key clustered(idUsuario),
	constraint fk_empleados foreign key(idEmpleado) references empleados(idEmpleado)
)
go

create table roles
(
	idRoles int identity(1,1),
	administrador nvarchar(30),
	usuarioComun nvarchar(30),
	idUsuario int,

	constraint pk_roles_idRoles primary key clustered(idRoles),
	constraint fk_usuario foreign key(idUsuario) references usuario(idUsuario)
)
go


create table fechaDeAdmision
(
	idFecha int identity(1,1),
	dia nvarchar(10),
	mes nvarchar(10),
	año nvarchar(10),

	constraint pk_fechaDeAdmision_idFecha primary key clustered(idFecha)
)
go

create table especialidad
(
	idEspecialidad int identity(1,1) not null,
	pediatra nvarchar(20) not null,
	otorrinonaringologo nvarchar(20) not null,
	cardiologo nvarchar(20) not null,
	cirujano nvarchar(20) not null,

	constraint pk_especialidad_idEspecialidad primary key clustered(idEspecialidad)
)
go

create table admision
(
	idAdmision int identity(1,1) not null,
	numeroDeAdmision int not null,
	horaDeAdmision time not null,
	idFecha int not null,
	idEspecialidad int not null,

	constraint pk_admision_idAdmision primary key clustered(idAdmision),
	constraint fk_fechaDeAdmision foreign key(idFecha) references fechaDeAdmision(idFecha),
	constraint fk_especialidad foreign key(idEspecialidad) references especialidad(idEspecialidad)
)
go

/*create table fechaDeNacimiento
(
	idFecha int identity(1,1) not null,
	dia nvarchar(10) not null,
	mes nvarchar(10) not null,
	año nvarchar(10) not null,

	constraint pk_fechaDeNacimiento_idFecha primary key clustered(idFecha)
)
go*/

create table registroDeExpediente
(
	idExpediente int identity(1,1) not null,
	numeroDeExpedinte int not null,
	nombreDeCreador nvarchar not null,

	constraint pk_RegistroDeExpediente_idExpediente primary key clustered(idExpediente)
)
go


create table pacientes
(
	idPacientes int identity(1,1) not null,
	nombre nvarchar(50) not null,
	apellido nvarchar(50) not null,
	edad int not null,
	enfermedadQuePadece nvarchar(70) not null,
	numeroDeExpediente int not null,
	fechaDeNacimiento datetime,
	idExpediente int,

	constraint pk_pacientes_idPacientes primary key clustered(idPacientes),
	constraint fk_registroDeExpediente foreign key(idExpediente) references registroDeExpediente(idExpediente)
)
go

--create proc pg_login

--insert into pacientes(nombre, apellido, edad, enfermedadQuePadece, numeroDeExpediente) values('williams','manuel','23','dolor','1');
--SELECT * FROM pacientes WHERE apellido LIKE '%{manuel}%';