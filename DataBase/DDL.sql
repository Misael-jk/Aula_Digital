drop database if exists aula_digital;
create database aula_digital;
use aula_digital;

create table Docentes (
    idDocente smallint not null auto_increment,
    dni int not null,
    nombre varchar(40) not null,
    apellido varchar(40) not null,
    email varchar(70) not null,
    constraint PK_Docentes primary key (idDocente),
    constraint UQ_Docentes_Dni unique (dni),
    constraint UQ_Docentes_Email unique (email)
);


create table EstadosNotebook (
    idEstadoNotebook tinyint not null auto_increment,
    estadoNotebook varchar(40) not null,
    constraint PK_EstadosNotebook primary key (idEstadoNotebook),
    constraint UQ_EstadosNotebook unique (estadoNotebook)
);


create table Notebooks (
    idNotebook tinyint not null auto_increment,
    idEstadoNotebook tinyint not null,
    disponibleNotebook boolean not null,
    constraint PK_Notebooks primary key (idNotebook),
    constraint FK_Notebooks_EstadosNotebook foreign key (idEstadoNotebook)
    	references EstadosNotebook(idEstadoNotebook)
);


create table Carritos (
    idCarrito tinyint not null auto_increment,
    idDocente smallint not null,
    disponibleCarrito boolean not null,
    constraint PK_Carritos primary key (idCarrito),
    constraint FK_Carritos_Docentes foreign key (idDocente) 
        references Docentes(idDocente)
);


create table CarritoNotebooks (
    idCarrito tinyint not null,
    idNotebook tinyint not null,
    constraint PK_CarritoNotebooks primary key (idCarrito, idNotebook),
    constraint FK_CarritoNotebooks_Carritos foreign key (idCarrito) 
        references Carritos(idCarrito),
    constraint FK_CarritoNotebooks_Notebooks foreign key (idNotebook) 
        references Notebooks(idNotebook)
);


create table Prestamos (
    idPrestamo int auto_increment,
    idDocente smallint not null,
    idCarrito tinyint,
    fechaPrestamo datetime not null,
    fechaPactada datetime not null,
    constraint PK_Prestamos primary key (idPrestamo),
    constraint FK_Prestamos_Docentes foreign key (idDocente)
        references Docentes(idDocente),
    constraint FK_Prestamos_Carritos foreign key (idCarrito) 
        references Carritos(idCarrito)
);


CREATE TABLE EstadosPrestamo (
    idEstadoPrestamo tinyint not null auto_increment,
    estadoPrestamo varchar(40) not null,
    constraint PK_EstadoPrestamo primary key (idEstadoPrestamo),
    constraint UQ_EstadoPrestamo unique (estadoPrestamo)
);


create table PrestamoDetalle (
    idPrestamo int not null,
    idNotebook tinyint not null,
    idEstadoPrestamo tinyint not null,
    fechaDevolucion datetime,  
    constraint PK_PrestamoDetalle primary key (idPrestamo, idNotebook),
    constraint FK_PrestamoDetalle_Prestamos foreign key (idPrestamo) 
    	references Prestamos(idPrestamo),
    constraint FK_PrestamoDetalle_Notebooks foreign key (idNotebook) 
    	references Notebooks(idNotebook),
    constraint FK_PrestamoDetalle_EstadosPrestamo foreign key (idEstadoPrestamo)
    	references EstadosPrestamo(idEstadoPrestamo)
);


-- create table PrestamoDetalleCarrito (
--     idPrestamo int not null,
--     idCarrito tinyint not null,
--     idEstadoPrestamo tinyint not null,
--     fechaDevolucion datetime,
--     constraint PK_PrestamoDetalleCarrito primary key (idPrestamo, idCarrito),
--     constraint FK_PrestamoDetalleCarrito_Prestamos foreign key (idPrestamo) 
--         references Prestamos(idPrestamo),
--     constraint FK_PrestamoDetalleCarrito_Carritos foreign key (idCarrito) 
--         references Carritos(idCarrito),
--     constraint FK_PrestamoDetalleCarrito_Estado foreign key (idEstadoPrestamo)
--         references EstadosPrestamo(idEstadoPrestamo)
-- );

