-- =====================================================================
-- UPDATE PARA LA TABLA DE CARRITOS
-- =====================================================================

delimiter $$ 

drop procedure if exists UpdateCarrito $$
create procedure UpdateCarrito(in unidCarrito tinyint, in unnumeroSerieCarrito varchar(40), in undisponibleCarrito boolean)
begin
	update carritos 
	set numeroSerieCarrito = unnumeroSerieCarrito, disponibleCarrito = undisponibleCarrito
	where idCarrito = unidCarrito;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE DOCENTES
-- =====================================================================

delimiter $$ 

drop procedure if exists UpdateDocente $$
create procedure UpdateDocente (in unidDocente smallint, in undni int, in unnombre varchar(40), in unapellido varchar(40), in unemail varchar(70))
begin
	update docentes 
	set dni = undni,
		nombre = unnombre,
		apellido = unapellido,
		email = unemail
	where idDocente = unidDocente;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE ELEMENTOS
-- =====================================================================

delimiter $$ 

drop procedure if exists UpdateElemento $$
create procedure UpdateElemento(in unidElemento tinyint, in unidTipoElemento tinyint, in unidEstadoElemento tinyint, in unidCarrito tinyint, in unaposicionCarrito tinyint, in unnumeroSerie varchar(40), in uncodigoBarra varchar(40), in undisponible boolean, in unafechaBaja datetime)
begin
	
	update elementos 
	set idTipoElemento = unidTipoElemento,
		idEstadoElemento = unidEstadoElemento,
		idCarrito = unidCarrito,
		posicionCarrito = unaposicionCarrito,
		numeroSerie = unnumeroSerie,
		codigoBarra = uncodigoBarra,
		disponible = undisponible,
		fechaBaja = unafechaBaja
	where idElemento = unidElemento;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE USUARIOS
-- =====================================================================

delimiter $$

drop procedure if exists UpdateUsuario $$
create procedure UpdateUsuario (in unidUsuario tinyint, in unusuario varchar(40), in unpassword varchar(70), in unnombre varchar(40), in unapellido varchar(40), in unrol tinyint, in unemail varchar(70), in unafotoperfil VARCHAR(255))
begin
    update usuarios u
    set idUsuario = unidEncargado,
        usuario = unusuario,
        pass = unpassword,
        nombre = unnombre,
        apellido = unapellido,
        idRol = unrol,
        email = unemail,
        FotoPerfil = unafotoperfil
    where idUsuario = unidUsuario;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE PRESTAMOS
-- =====================================================================

delimiter $$

drop procedure if exists UpdatePrestamo $$
create procedure UpdatePrestamo (in unidPrestamo int, in unidCurso tinyint, in unidDocente smallint, in unidCarrito tinyint, in unidEstadoPrestamo tinyint, in unafechaPrestamo datetime)
begin
    update Prestamos
    set idCurso = unidCurso,
        idDocente = unidDocente,
        idCarrito = unidCarrito,
        idEstadoPrestamo = unidEstadoPrestamo,
        fechaPrestamo = unafechaPrestamo
    where idPrestamo = unidPrestamo;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE DEVOLUCION
-- =====================================================================

delimiter $$

drop procedure if exists UpdateDevolucion $$
create procedure UpdateDevolucion (in unidDevolucion int, in unidPrestamo int, in unidDocente smallint, in unidUsuario tinyint, in unidEstadoPrestamo tinyint, in unafechaDevolucion datetime, in unaobservacion varchar(200))
begin
    update Devoluciones
    set idPrestamo = unidPrestamo,
        idDocente = unidDocente,
        idUsuario = unidUsuario,
        idEstadoPrestamo = unidEstadoPrestamo,
        fechaDevolucion = unafechaDevolucion,
        observaciones = unaobservacion
    where idDevolucion = unidDevolucion;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE CURSOS
-- =====================================================================

delimiter $$

drop procedure if exists UpdateCurso $$
create procedure UpdateCurso (in unidCurso tinyint, in uncurso varchar(40))
begin
    update Cursos
    set curso = uncurso
    where idCurso = unidCurso;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE TIPO ELEMENTO
-- =====================================================================

delimiter $$

drop procedure if exists UpdateTipoElemento $$
create procedure UpdateTipoElemento (in unidTipoElemento tinyint, in untipoElemento varchar(40))
begin
    update TipoElemento
    set elemento = untipoElemento
    where idTipoElemento = unidTipoElemento;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE ESTADO ELEMENTO
-- =====================================================================

delimiter $$

drop procedure if exists UpdateEstadoElemento $$
create procedure UpdateEstadoElemento (in unidEstadoElemento tinyint, in unestadoElemento varchar(40))
begin
    update EstadosElemento
    set estadoElemento = unestadoElemento
    where idEstadoElemento = unidEstadoElemento;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE ESTADO PRESTAMO
-- =====================================================================

delimiter $$

drop procedure if exists UpdateEstadoPrestamo $$
create procedure UpdateEstadoPrestamo (in unidEstadoPrestamo tinyint, in unestadoPrestamo varchar(40))
begin
    update EstadosPrestamo
    set estadoPrestamo = unestadoPrestamo
    where idEstadoPrestamo = unidEstadoPrestamo;
end $$

delimiter ;



-- =====================================================================
-- UPDATE PARA LA TABLA DE ROLES
-- =====================================================================

delimiter $$

drop procedure if exists UpdateRol $$
create procedure UpdateRol (in unidRol tinyint, in unrol varchar(40))
begin
    update Rol 
    set rol = unrol
    where idRol = unidRol;
end $$

delimiter ;


