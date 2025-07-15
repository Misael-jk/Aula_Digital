drop database if exists aula_digital;
create database aula_digital;
use aula_digital;


create table Encargados (
    idEncargado tinyint not null auto_increment,
    usuario varchar(40) not null,
    password varchar(70) not null,
    nombre varchar(40) not null,
    apellido varchar(40) not null,
    email varchar(70),
    constraint PK_Encargados primary key (idEncargado),
    constraint UQ_Encargados unique (usuario)
);


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


create table tipoElemento (
    idTipoElemento tinyint not null auto_increment,
    elemento varchar(40) not null,
    constraint PK_TipoElemento primary key (idTipoElemento)
);


create table EstadosElemento (
    idEstadoElemento tinyint not null auto_increment,
    estadoElemento varchar(40) not null,
    constraint PK_EstadosNotebook primary key (idEstadoElemento)
);


create table Carritos (
    idCarrito tinyint not null auto_increment,
    cantidad tinyint not null,
    disponibleCarrito boolean not null,
    constraint PK_Carritos primary key (idCarrito)
);


create table Elementos (
    idElemento tinyint not null auto_increment,
    idTipoElemento tinyint not null,
    idCarrito tinyint,
    idEstadoElemento tinyint,
    disponible boolean not null,
    constraint PK_Elementos primary key (idElemento),
    constraint FK_Elementos_TipoElemento foreign key (idTipoElemento)
        references tipoElemento(idTipoElemento),
    constraint FK_Elementos_Carrito foreign key (idCarrito)
        references Carritos(idCarrito),
    constraint FK_Elementos_EstadoNotebook foreign key (idEstadoElemento)
        references EstadosElemento(idEstadoElemento)
--     constraint CHK_Carrito_Solo_Para_Notebooks check (
--         (idCarrito is null) or (idTipoElemento = 1)
--     )
);


create table Cursos (
    idCurso tinyint auto_increment,
    curso varchar(40) not null,
    constraint PK_Cursos primary key (idCurso)
);



create table Prestamos (
    idPrestamo int auto_increment,
    idCurso tinyint,
    idDocente smallint not null,
    idCarrito tinyint,
    idEncargado tinyint not null,
    fechaPrestamo datetime not null,
    constraint PK_Prestamos primary key (idPrestamo),
    constraint FK_Prestamos_Docentes foreign key (idDocente)
        references Docentes(idDocente),
    constraint FK_Prestamos_Cursos foreign key (idCurso)
        references Cursos(idCurso),
    constraint FK_Prestamos_Carritos foreign key (idCarrito) 
        references Carritos(idCarrito),
    constraint FK_Prestamos_Encargados foreign key (idEncargado)
    	references Encargados(idEncargado)
);


CREATE TABLE EstadosPrestamo (
    idEstadoPrestamo tinyint not null auto_increment,
    estadoPrestamo varchar(40) not null,
    constraint PK_EstadoPrestamo primary key (idEstadoPrestamo),
    constraint UQ_EstadoPrestamo unique (estadoPrestamo)
);


create table PrestamoDetalle (
    idPrestamo int not null,
    idElemento tinyint not null,
    idEstadoPrestamo tinyint not null,
    constraint PK_PrestamoDetalle primary key (idPrestamo, idElemento),
    constraint FK_PrestamoDetalle_Prestamos foreign key (idPrestamo)
        references Prestamos(idPrestamo),
    constraint FK_PrestamoDetalle_Elementos foreign key (idElemento)
        references Elementos(idElemento),
    constraint FK_PrestamoDetalle_EstadosPrestamo foreign key (idEstadoPrestamo)
        references EstadosPrestamo(idEstadoPrestamo)
);


create table Devoluciones (
    idDevolucion int auto_increment,
    idPrestamo int not null,
    idElemento tinyint not null,
    idDocente smallint not null,
    idEstadoPrestamo tinyint not null,
    idEncargado tinyint not null,
    fechaDevolucion datetime not null,
    observaciones varchar(200),
    constraint PK_Devoluciones primary key (idDevolucion),
    constraint FK_Devoluciones_Prestamo foreign key (idPrestamo)
        references Prestamos(idPrestamo),
    constraint FK_Devoluciones_Elemento foreign key (idElemento)
        references Elementos(idElemento),
    constraint FK_Devoluciones_Docentes foreign key (idDocente)
        references Docentes(idDocente),
    constraint FK_Devoluciones_EstadosPrestamo foreign key (idEstadoPrestamo)
        references EstadosPrestamo(idEstadoPrestamo),
    constraint FK_Devoluciones_Encargados foreign key (idEncargado)
        references Encargados(idEncargado)
);


