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

-- create table Curso(
--	idCurso tinyint not null auto_increment,
--	anio tinyint not null,
--	division tinyint not null,
-- 	turno varchar(30) not null,
-- 	constraint PK_Curso primary key(idCurso)
-- );

-- create table Alumnos (
--     idAlumno smallint not null auto_increment,
--     dni int not null,
--     nombre varchar(40) not null,
--     apellido varchar(40) not null,
--     email varchar(70) not null,
--     curso varchar(30) not null,
--     constraint PK_Alumnos primary key (idAlumno),
--     constraint UQ_Alumnos unique (dni),
--     constraint UQ_Docentes_Email unique (email)
-- );


-- create table PermisosPrestamo (
--     idPermiso smallint not null auto_increment,
--     idAlumno smallint not null,
--     idDocente smallint not null,
--     fechaPermiso datetime not null,
--     constraint PK_PermisosPrestamo primary key (idPermiso),
--     constraint FK_PermisosPrestamos_Alumnos foreign key (idAlumno) 
--     	references Alumnos(idAlumno),
--     constraint FK_PermisosPrestamos_Docentes foreign key (idDocente) 
--     	references Docentes(idDocente)
-- );


-- create table Tecnologia (
-- 	idTecnologia tinyint not null auto_increment,
--     programa varchar(50) not null,
--     constraint PK_Tecnologia primary key (idTecnologia)
-- );


create table EstadosNotebook (
    idEstadoNotebook tinyint not null auto_increment,
    estadoNotebook varchar(40) not null,
    constraint PK_EstadosNotebook primary key (idEstadoNotebook),
    constraint UQ_EstadosNotebook unique (estadoNotebook)
);


create table Notebooks (
    idNotebook tinyint not null auto_increment,
    idEstadoNotebook tinyint not null,
    constraint PK_Notebooks primary key (idNotebook),
    constraint FK_Notebooks_EstadosNotebook foreign key (idEstadoNotebook)
    	references EstadosNotebook(idEstadoNotebook)
);

-- create NotebookTecnologia (
-- idNotebook tinyint not null,
-- idTecnologia tinyint not null,
-- constraint PK_NotebookTecnologia primary key(idNotebook, idTecnologia),
-- constraint FK _NotebookTecnologia_Notebooks foreign key(idNotebook)
--		references Notebook(idNotebook),
-- constraint FK_NotebookTecnologia_Tecnologia foreign key(idTecnologia)
-- 		references Tecnologia(idTecnologia)
-- );

create table Carritos (
    idCarrito tinyint not null auto_increment,
    idDocente smallint not null,
    disponible boolean not null,
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

-- create table TipoPrestamo (
-- idTipoPrestamo tinyint not null auto_increment,
-- tipoPrestamo varchar(40) not null,
-- constraint PK_TipoPrestamo primary key(idTipoPrestamo)
-- );

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
