-- =====================================================================
-- INSERT PARA LA TABLA DE CARRITOS
-- =====================================================================

delimiter $$

drop procedure if exists InsertCarrito $$
create procedure InsertCarrito(out unidCarrito tinyint, in unnumeroSerieCarrito varchar(40), in undisponibleCarrito boolean)
begin
	insert into carritos (numeroSerieCarrito, disponibleCarrito)
	values (unnumeroSerieCarrito, undisponibleCarrito);

	set unidCarrito = last_insert_id(); 
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE DOCENTES
-- =====================================================================

delimiter $$

drop procedure if exists InsertDocente $$
create procedure InsertDocente (out unidDocente smallint, in undni int, in unnombre varchar(40), in unapellido varchar(40), in unemail varchar(70))
begin
    insert into Docentes(dni, nombre, apellido, email)
    values (undni, unnombre, unapellido, unemail);

    set unidDocente = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE ELEMENTOS
-- =====================================================================

delimiter $$

drop procedure if exists InsertElemento $$
create procedure InsertElemento (out unidElemento tinyint, in unidTipoElemento tinyint, in unidEstadoElemento tinyint, in unidCarrito tinyint, in unaposicionCarrito tinyint, in unnumeroSerie varchar(40), in uncodigoBarra varchar(40), in undisponible boolean, in unafechaBaja datetime)
begin
    insert into elementos (idTipoElemento, idEstadoElemento, idCarrito, posicionCarrito, numeroSerie, codigoBarra, disponible, fechaBaja)
    values (unidTipoElemento, unidEstadoElemento, unidCarrito, unaposicionCarrito, unnumeroSerie, uncodigoBarra, undisponible, unafechaBaja);

    set unidElemento = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE USUARIOS
-- =====================================================================

delimiter $$

drop procedure if exists InsertUsuario $$
create procedure InsertUsuario (out unidUsuario tinyint, in unusuario varchar(40), in unpassword varchar(70), in unnombre varchar(40), in unapellido varchar(40), in unidRol tinyint, in unemail varchar(70), in unafotoperfil VARCHAR(255))
begin
    insert into usuarios  (usuario, pass, nombre, apellido, idRol, email, fotoPerfil)
    values (unusuario, unpassword, unnombre, unapellido, unidRol, unemail, unafotoperfil);

    set unidUsuario = last_insert_id(); 
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE PRESTAMOS
-- =====================================================================

delimiter $$

drop procedure if exists InsertPrestamo $$
create procedure InsertPrestamo (out unidPrestamo int, in unidCurso tinyint, in unidDocente smallint ,in unidCarrito tinyint ,in unidEstadoPrestamo tinyint ,in unafechaPrestamo datetime)
begin
    insert into Prestamos (idCurso, idDocente, idCarrito, idEstadoPrestamo, fechaPrestamo)
    values (unidCurso, unidDocente, unidCarrito, unidEstadoPrestamo, unafechaPrestamo);

    set unidPrestamo = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE PRESTAMOS DETALLES
-- =====================================================================

delimiter $$

drop procedure if exists InsertPrestamoDetalle $$
create procedure InsertPrestamoDetalle (in unidPrestamo int, in unidElemento tinyint)
begin
    insert into PrestamoDetalle (idPrestamo, idElemento)
    values (unidPrestamo, unidElemento);
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE DEVOLUCION
-- =====================================================================

delimiter $$

drop procedure if exists InsertDevolucion $$
create procedure InsertDevolucion (out unidDevolucion int, in unidPrestamo int, in unidDocente smallint, in unidUsuario tinyint, in unidEstadoPrestamo tinyint, in unafechaDevolucion datetime, in unaobservacion varchar(200))
begin
    insert into Devoluciones (idPrestamo, idDocente, idUsuario, idEstadoPrestamo, fechaDevolucion, observaciones)
    values (unidPrestamo, unidDocente, unidUsuario, unidEstadoPrestamo, unafechaDevolucion, unaobservacion);

    set unidDevolucion = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE DEVOLUCION DETALLE
-- =====================================================================

delimiter $$

drop procedure if exists InsertDevolucionDetalle $$
create procedure InsertDevolucionDetalle (in unidDevolucion int ,in unidElemento tinyint ,in unidEstadoElemento tinyint ,in unaobservacion varchar(200))
begin
    insert into DevolucionDetalle (idDevolucion, idElemento, idEstadoElemento, observaciones)
    values (unidDevolucion, unidElemento, unidEstadoElemento, unaobservacion);
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE CURSOS
-- =====================================================================

delimiter $$

drop procedure if exists InsertCurso $$
create procedure InsertCurso (out unidCurso tinyint, in uncurso varchar(40))
begin
    insert into Cursos (curso)
    values (uncurso);

    set unidCurso = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE TIPO ELEMENTO
-- =====================================================================

delimiter $$

drop procedure if exists InsertTipoElemento $$
create procedure InsertTipoElemento (out unidTipoElemento tinyint, in untipoElemento varchar(40))
begin
    insert into TipoElemento (elemento)
    values (untipoElemento);

    set unidTipoElemento = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE ESTADO ELEMENTO
-- =====================================================================

delimiter $$

drop procedure if exists InsertEstadoElemento $$
create procedure InsertEstadoElemento (out unidEstadoElemento tinyint, in unestadoElemento varchar(40))
begin
    insert into EstadosElemento (estadoPrestamo)
    values (unestadoElemento);

    set unidEstadoElemento = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE ESTADO PRESTAMO
-- =====================================================================

delimiter $$

drop procedure if exists InsertEstadoPrestamo $$
create procedure InsertEstadoPrestamo (out unidEstadoPrestamo tinyint, in unestadoPrestamo varchar(40))
begin
    insert into EstadosPrestamo(estadoPrestamo)
    values (unestadoPrestamo);

    set unidEstadoPrestamo = last_insert_id();
end $$

delimiter ;



-- =====================================================================
-- INSERT PARA LA TABLA DE ROLES
-- =====================================================================

delimiter $$

drop procedure if exists InsertRol $$
create procedure InsertRol (out unidRol tinyint, in unrol varchar(40))
begin
    insert into Rol (rol)
    values (unrol);

    set unidRol = last_insert_id();
end $$



-- =====================================================================
-- INSERT PARA LA TABLA DE HISTORIAL ELEMENTO
-- =====================================================================

delimiter $$

drop procedure if exists InsertHistorialElemento $$
create procedure InsertHistorialElemento (in unidElemento tinyint, in unidCarrito tinyint, in unidUsuario tinyint, in unidEstadoElemento tinyint, in unafechaHora datetime, in unaobservacion varchar(200))
begin
    insert into HistorialElementos (idElemento, idCarrito, idUsuario, idEstadoElemento, fechaHora, observacion)
    values (unidElemento, unidCarrito, unidUsuario, unidEstadoElemento, unafechaHora, unaobservacion);
end $$

delimiter ;