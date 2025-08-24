-- SP Usuarios DTO

DELIMITER $$
drop procedure if exists GetUsuariosDTO $$
CREATE PROCEDURE GetUsuariosDTO()
BEGIN
    SELECT 
        u.idUsuario,
        u.usuario,
        u.pass as Password,
        u.nombre,
        u.apellido,
        u.email as Email,
        r.rol
    FROM Usuarios u
    JOIN Rol r ON u.idRol = r.idRol;
END$$


-- SP Prestamos DTO
delimiter $$
drop procedure if exists GetPrestamosDTO $$
CREATE PROCEDURE GetPrestamosDTO()
begin

SELECT 
    p.idPrestamo,
    p.fechaPrestamo,
    c.curso AS NombreCurso,
    concat(d.nombre, ' ', d.apellido) AS Apellido,
    concat(u.nombre, ' ', u.apellido) AS Apellido,
    ca.numeroSerieCarrito AS NumeroSerieCarrito
FROM prestamos p
JOIN docentes d on p.idDocente = d.idDocente
JOIN usuarios u on p.idUsuario = u.idUsuario
LEFT JOIN Cursos c using (idCurso)
LEFT JOIN carritos ca using (idCarrito);
   
END$$

select * from usuarios u 


-- SP PrestamosDetalle DTO 
delimiter $$
drop procedure if exists GetPrestamoDetalleDTO $$
CREATE PROCEDURE GetPrestamoDetalleDTO()
BEGIN
    SELECT 
    	e.numeroSerie as numeroSerie,
        te.elemento AS ElementoTipo,
        c.numeroSerieCarrito AS NumeroSerieCarrito
    FROM PrestamoDetalle pd
    JOIN Elementos e ON pd.idElemento = e.idElemento
    JOIN tipoElemento te ON e.idTipoElemento = te.idTipoElemento
    LEFT JOIN Carritos c ON e.idCarrito = c.idCarrito;
END$$

call GetPrestamoDetalleDTO;

select * from tipoelemento t 

-- SP Devolucion DTO

DELIMITER $$
drop procedure if exists GetDevolucionesDTO $$
CREATE PROCEDURE GetDevolucionesDTO()
BEGIN
    SELECT 
        d.IdDevolucion,
    d.FechaDevolucion,
    d.Observaciones,
    p.FechaPrestamo,
    doc.Apellido AS Apellido,
    u.Apellido AS Apellido
    FROM Devoluciones d
    JOIN Prestamos p ON d.idPrestamo = p.idPrestamo
    JOIN Docentes doc ON d.idDocente = doc.idDocente
    JOIN Usuarios u ON d.idUsuario = u.idUsuario;
END$$


-- SP DevolucionDetalle DTO

DELIMITER $$
drop procedure if exists GetDevolucionDetalleDTO $$
CREATE PROCEDURE GetDevolucionDetalleDTO()
BEGIN
    SELECT 
    	d.fechaDevolucion,
    	e.numeroSerie,
    	tp.elemento as ElementoTipo,
        c.numeroSerieCarrito as NumeroSerieCarrito
    FROM DevolucionDetalle dd
    join devoluciones d using (idDevolucion)
    join Elementos e using (idElemento)
    join tipoelemento tp using (idTipoElemento)
    left join carritos c using (idCarrito);
END$$


-- SP Elementos DTO

DELIMITER $$
drop procedure if exists GetElementosDTO $$
CREATE PROCEDURE GetElementosDTO()
BEGIN
    SELECT 
        e.idElemento,
        e.numeroSerie,
        e.codigoBarra,
        te.elemento AS ElementoTipo,
        ee.estadoElemento AS EstadoElementoNombre,
        c.numeroSerieCarrito
    FROM Elementos e
    INNER JOIN tipoElemento te ON e.idTipoElemento = te.idTipoElemento
    INNER JOIN EstadosElemento ee ON e.idEstadoElemento = ee.idEstadoElemento
    LEFT JOIN Carritos c ON e.idCarrito = c.idCarrito
    where e.disponible = 1;
END$$

select * from Carritos

select * from elementos e 


-- SP Historial Elemento DTO

delimiter $$ 
drop procedure if exists GetHistorialElementosDTO $$
create procedure GetHistorialElementosDTO()
begin
	SELECT he.idHistorialElemento,
       he.fechaHora,
       he.observacion,
       te.elemento AS ElementoTipo,
       e.numeroSerie,
       c.numeroSerieCarrito,
       ee.estadoElemento as EstadoElementoNombre
FROM HistorialElementos he
JOIN Elementos e ON he.idElemento = e.idElemento
join carritos c on he.idCarrito = c.idCarrito
JOIN TipoElemento te ON e.idTipoElemento = te.idTipoElemento
JOIN EstadosElemento ee ON he.idEstadoElemento = ee.idEstadoElemento;
end $$


-- SP Mantenimiento Elementos DTO

DELIMITER $$

DROP PROCEDURE IF EXISTS GetElementosMantenimientoDTO $$
CREATE PROCEDURE GetElementosMantenimientoDTO()
BEGIN
    SELECT e.idElemento,
           e.numeroSerie,
           e.disponible,
           e.fechaBaja,
           t.elemento as ElementoTipo,
           est.estadoElemento as EstadoElementoNombre
    FROM Elementos e
    INNER JOIN TipoElemento t ON e.idTipoElemento = t.idTipoElemento
    INNER JOIN EstadosElemento est ON e.idEstadoElemento = est.idEstadoElemento
    WHERE e.disponible = 0;
END $$
