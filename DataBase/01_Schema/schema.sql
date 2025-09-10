drop database if exists aula_digital;
create database aula_digital;
use aula_digital;


create table Rol(
idRol tinyint not null auto_increment,
rol varchar(40) not null,
constraint PK_Rol primary key (idRol)
);


create table Usuarios (
    idUsuario tinyint not null auto_increment,
    usuario varchar(40) not null,
    pass varchar(70) not null,
    nombre varchar(40) not null,
    apellido varchar(40) not null,
    idRol tinyint not null,
    email varchar(70),
    fotoPerfil varchar(255),
    habilitado boolean not null,
    fechaBaja datetime,
    constraint PK_Usuarios primary key (idUsuario),
    constraint UQ_Usuarios unique (usuario),
    constraint FK_Usuarios_Rol foreign key (idRol)
    	references Rol (idRol)
);


create table Docentes (
    idDocente smallint not null auto_increment,
    dni int not null,
    nombre varchar(40) not null,
    apellido varchar(40) not null,
    email varchar(70) not null,
    habilitado boolean not null,
    fechaBaja datetime,
    constraint PK_Docentes primary key (idDocente),
    constraint UQ_Docentes_Dni unique (dni),
    constraint UQ_Docentes_Email unique (email)
);


create table Ubicacion(
	idUbicacion tinyint not null auto_increment,
	ubicacion varchar(40) not null,
	constraint PK_Ubicacion primary key (idUbicacion)
);


create table TipoElemento (
    idTipoElemento tinyint not null auto_increment,
    elemento varchar(40) not null,
    constraint PK_TipoElemento primary key (idTipoElemento)
);


create table Modelo (
idModelo tinyint not null auto_increment,
idTipoElemento tinyint not null,
modelo varchar(40) not null,
constraint PK_Modelo primary key (idModelo),
constraint UQ_Modelo unique (idTipoElemento, modelo),
constraint FK_Modelo_TipoElemento foreign key (idTipoElemento)
	references TipoElemento (idTipoElemento)
);


create table EstadosMantenimiento (
    idEstadoMantenimiento tinyint not null auto_increment,
    estadoMantenimiento varchar(40) not null,
    constraint PK_EstadosElemento primary key (idEstadoMantenimiento)
);


create table Carritos (
    idCarrito tinyint not null auto_increment,
    numeroSerieCarrito varchar(40)not null,
    idEstadoMantenimiento tinyint not null,
    idUbicacion tinyint not null,
    idModelo tinyint not null,
    Habilitado boolean not null,
    fechaBaja datetime,
    constraint PK_Carritos primary key (idCarrito),
    constraint FK_Carritos_EstadoMantenimiento foreign key (idEstadoMantenimiento)
    	references EstadosMantenimiento (idEstadoMantenimiento),
    constraint FK_Carritos_Ubicacion foreign key (idUbicacion)
    	references Ubicacion (idUbicacion),
    constraint FK_Carrito_Modelo foreign key (idModelo)
    	references Modelo(idModelo)
); 
    
    
create table Elementos (
    idElemento smallint not null auto_increment,
    idTipoElemento tinyint not null,
    idModelo tinyint not null,
    idUbicacion tinyint not null,
    idEstadoMantenimiento tinyint not null,
    numeroSerie varchar(40) not null,
    codigoBarra varchar(40) not null,
    patrimonio varchar(60) not null,
    habilitado boolean not null,
    fechaBaja datetime,
    constraint PK_Elementos primary key (idElemento),
    constraint UQ_Elementos_numeroSerie unique (numeroSerie),
    constraint UQ_Elementos_codigoBarra unique (codigoBarra),
    constraint UQ_Elementos_patrimonio unique (patrimonio),
    constraint FK_Elementos_TipoElemento foreign key (idTipoElemento)
        references tipoElemento(idTipoElemento),
    constraint FK_Elementos_Modelo foreign key (idModelo)
    	references Modelo(idModelo),
    constraint FK_Elementos_Ubicacion foreign key (idUbicacion)
        references Ubicacion(idUbicacion),
    constraint FK_Elementos_EstadoMantenimiento foreign key (idEstadoMantenimiento)
        references EstadosMantenimiento (idEstadoMantenimiento)
);


create table Notebooks (
    idElemento smallint not null,
    idCarrito tinyint,
    posicionCarrito tinyint,
    constraint PK_Notebooks primary key (idElemento),
    constraint FK_Notebooks_Elementos foreign key (idElemento)
    	references Elementos (idElemento),
    constraint FK_Notebooks_Carrito foreign key (idCarrito) 
        references Carritos(idCarrito)
);   


create table Cursos (
    idCurso tinyint auto_increment,
    curso varchar(40) not null,
    constraint PK_Cursos primary key (idCurso)
);


create table EstadosPrestamo (
    idEstadoPrestamo tinyint not null auto_increment,
    estadoPrestamo varchar(40) not null,
    constraint PK_EstadoPrestamo primary key (idEstadoPrestamo),
    constraint UQ_EstadoPrestamo unique (estadoPrestamo)
);


create table Prestamos (
    idPrestamo int auto_increment,
    idUsuarioRecibio tinyint not null,
    idCurso tinyint,
    idDocente smallint not null,
    idCarrito tinyint,
    idEstadoPrestamo tinyint not null,
    fechaPrestamo datetime not null,
    constraint PK_Prestamos primary key (idPrestamo),
    constraint FK_Prestamos_UsuarioRecibio foreign key (idUsuarioRecibio)
    	references Usuarios(idUsuario),
    constraint FK_Prestamos_Docentes foreign key (idDocente)
        references Docentes(idDocente),
    constraint FK_Prestamos_Cursos foreign key (idCurso)
        references Cursos(idCurso),
    constraint FK_Prestamos_Carritos foreign key (idCarrito) 
        references Carritos(idCarrito),
    constraint FK_Prestamos_Estado foreign key (idEstadoPrestamo)
    	references EstadosPrestamo (idEstadoPrestamo)
);


create table PrestamoDetalle (
    idPrestamo int not null,
    idElemento smallint not null,
    constraint PK_PrestamoDetalle primary key (idPrestamo, idElemento),
    constraint FK_PrestamoDetalle_Prestamos foreign key (idPrestamo)
        references Prestamos(idPrestamo),
    constraint FK_PrestamoDetalle_Elementos foreign key (idElemento)
        references Elementos(idElemento)
);


create table Devoluciones (
    idDevolucion int auto_increment,
    idPrestamo int not null,
    idUsuarioDevolvio tinyint not null,
    fechaDevolucion datetime not null,
    observaciones varchar(200),
    constraint PK_Devoluciones primary key (idDevolucion),
    constraint FK_Devoluciones_Prestamo foreign key (idPrestamo)
        references Prestamos(idPrestamo),
    constraint FK_Devoluciones_Usuarios foreign key (idUsuarioDevolvio)
        references Usuarios(idUsuario),
    constraint UQ_Devoluciones unique (idPrestamo)
);


create table DevolucionDetalle (
    idDevolucion int not null,
    idElemento smallint not null,
    idEstadoMantenimiento tinyint not null,
    observaciones varchar(200),
    constraint PK_DevolucionDetalle primary key (idDevolucion, idElemento),
    constraint FK_DevolucionDetalle_Devoluciones foreign key (idDevolucion)
        references Devoluciones(idDevolucion),
    constraint FK_DevolucionDetalle_Elementos foreign key (idElemento)
        references Elementos(idElemento),
    constraint FK_DevolucionDetalle_EstadosMantenimiento foreign key (idEstadoMantenimiento)
    	references EstadosMantenimiento (idEstadoMantenimiento)
);


create table TipoSeccion(
idTipoSeccion tinyint not null auto_increment,
seccion varchar(40) not null,
constraint PK_TipoSeccion primary key (idTipoSeccion)
);


create table TipoAccion(
idTipoAccion tinyint not null auto_increment,
accion varchar(40) not null,
constraint PK_TipoAccion primary key (idTipoAccion)
);


create table HistorialCambio(
idHistorialCambio bigint not null auto_increment,
idTipoSeccion tinyint not null, 
idTipoAccion tinyint not null,
idUsuario tinyint not null,
fechaCambio datetime not null,
observacion varchar(200) not null,
constraint PK_HistorialCambio primary key (idHistorialCambio),
constraint FK_HistorialCambio_Seccion foreign key (idTipoSeccion) 
	references TipoSeccion (idTipoSeccion),	
constraint FK_HistorialCambio_Accion foreign key (idTipoAccion) 
	references TipoAccion (idTipoAccion),
constraint FK_HistorialCambio_idUsuarios foreign key (idUsuario)
	references Usuarios (idUsuario)
);
