-- Mostrar los Elementos disponibles en la UI
-- View Elementos DTO

drop view if exists View_GetElementosDTO;

create view View_GetElementosDTO as 
    select 
        e.idElemento,
        e.numeroSerie,
        e.codigoBarra,
        te.elemento as ElementoTipo,
        ee.estadoMantenimiento as EstadoMantenimientoNombre,
        c.numeroSerieCarrito
    from Elementos e
    join tipoElemento te using(idTipoElemento)
    join EstadosMantenimiento ee using(idEstadoMantenimiento)
    left join Carritos c using(idCarrito)
    where e.disponible = 1;
