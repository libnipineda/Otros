--create database IPC
--use IPC
--go
create table Tipo_Usuario(
idTipoU int primary key not null,
tipo varchar(50) not null,
);

create table Usuario(
idUsuario int primary key identity(1,1) not null,
carnet int not null,
nombre varchar(50) not null,
apellido varchar(50) not null,
fnac date not null,
email varchar(150),
nickname varchar(50) not null,
contraseña varchar(50) not null,
palabraC varchar(10),
codTipoU int not null,
foreign key (codTipoU) references Tipo_Usuario(idTipoU)
);

create table Insumo(
idInsumo int primary key identity(1,1) not null,
nombre varchar(100) not null,
tipo varchar(150) not null,
prestamo varchar(50),
estado varchar(50),
descripcion varchar(150)
);

create table Reporte_Insumo(
idReporteI int primary key identity(1,1) not null,
codInsumo int not null,
daño varchar(150) not null,
repuesto varchar(150),
resultado varchar(150),
foreign key (codInsumo) references Insumo (idInsumo)
);

create table detalle(
codUsuario int not null,
codInsumo int not null,
codTipoU int not null,
foreign key (codUsuario) references Usuario (idUsuario),
foreign key (codInsumo) references Insumo (idInsumo),
foreign key (codTipoU) references Tipo_Usuario (idTipoU)
);

create table reserva(
idReserva int primary key identity(1,1) not null,
fecha date not null,
hora time not null,
Disponibilidad varchar(145) not null,
carta varchar(150) not null,
qr varchar(45) not null,
);

create table Instructor(
idInstructor int primary key identity(1,1) not null,
cuestionario varchar(50),
documento varchar(50)
);

create table salon(
idSalon int primary key identity(1,1) not null,
estado varchar(50) not null,
edificio varchar(50) not null,
);

create table Almacen_carta(
codSalon int not null,
codUsuario int not null,
CodReserva int not null,
estado varchar(150),
foreign key (codSalon) references salon (idSalon),
foreign key (codUsuario) references Usuario (idUsuario),
foreign key (codReserva) references Reserva (idReserva),
);

create table Agenda(
codSalon int not null,
codUsuario int not null,
codTipoU int not null,
codReserva int not null,
fecha date,
hora time,
foreign key (codSalon) references salon (idSalon),
foreign key (codUsuario) references usuario (idUsuario),
foreign key (codTipoU) references Tipo_Usuario (idTipoU),
foreign key (codReserva) references Reserva (idReserva)
);

create table Matricular(
idMatricular int primary key identity(1,1) not null,
codSalon int not null,
fecha date,
hora time,
codReserva int not null,
codUsuario int not null,
codTipoU int not null,
codInstructor int not null,
foreign key (codSalon) references salon (idSalon),
foreign key (codReserva) references reserva (idReserva),
foreign key (codTipoU) references Tipo_Usuario (idTipoU),
foreign key (codInstructor) references Instructor (idInstructor)
);