-- SP Usuarios DTO

DELIMITER $$
drop procedure if exists GetUsuariosDTO $$
CREATE PROCEDURE GetUsuariosDTO()
BEGIN
    SELECT 
        u.idUsuario,
        u.usuario,
        u.pass,
        u.nombre,
        u.apellido,
        r.rol,
        u.email
    FROM Usuarios u
    INNER JOIN Rol r ON u.idRol = r.idRol;
END$$


-- SP Prestamos DTO
delimiter $$
drop procedure if exists GetPrestamosDTO $$
CREATE PROCEDURE GetPrestamosDTO()
BEGIN
    SELECT 
        p.idPrestamo,
        c.curso AS Curso,
        d.apellido AS ApellidoDocente,
        u.apellido AS ApellidoEncargado,
        ca.numeroSerieCarrito AS NumeroSerieCarrito,
        p.fechaPrestamo
    FROM prestamos p 
    LEFT JOIN Cursos c using (idCurso)
    INNER JOIN docentes d using (idDocente)
    INNER JOIN usuarios u using (idUsuario)
    LEFT JOIN carritos ca using (idCarritos);
   
END$$


-- SP PrestamosDetalle DTO 
delimiter $$
drop procedure if exists GetPrestamoDetalleDTO $$
CREATE PROCEDURE GetPrestamoDetalleDTO()
BEGIN
    SELECT 
        pd.idPrestamo,
        e.numeroSerie AS NumeroSerieElemento,
        te.elemento AS TipoElemento,
        c.numeroSerieCarrito AS NumeroSerieCarrito
    FROM PrestamoDetalle pd
    INNER JOIN Elementos e ON pd.idElemento = e.idElemento
    INNER JOIN tipoElemento te ON e.idTipoElemento = te.idTipoElemento
    LEFT JOIN Carritos c ON e.idCarrito = c.idCarrito;
END$$


-- SP Devolucion DTO

DELIMITER $$
drop procedure if exists GetDevolucionesDTO $$
CREATE PROCEDURE GetDevolucionesDTO()
BEGIN
    SELECT 
        d.idDevolucion,
        p.fechaPrestamo,
        doc.apellido AS ApellidoDocente,
        u.apellido AS ApellidoEncargado,
        d.fechaDevolucion,
        d.observaciones
    FROM Devoluciones d
    INNER JOIN Prestamos p ON d.idPrestamo = p.idPrestamo
    INNER JOIN Docentes doc ON d.idDocente = doc.idDocente
    INNER JOIN Usuarios u ON d.idUsuario = u.idUsuario;
END$$


-- SP DevolucionDetalle DTO

DELIMITER $$
drop procedure if exists GetDevolucionDetalleDTO $$
CREATE PROCEDURE GetDevolucionDetalleDTO()
BEGIN
    SELECT 
        dd.idDevolucion,
        tp.tipoElemento,
        e.numeroSerie,
        c.numeroSerieCarrito,
        d.fechaDevolucion
    FROM DevolucionDetalle dd
    join devoluciones d using (idDevolucion)
    join Elementos e using (idElemento)
    join TipoElemento tp using (idTipoElemento)
    left join carrito c using (idCarrito);
  
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
    LEFT JOIN Carritos c ON e.idCarrito = c.idCarrito;
END$$



