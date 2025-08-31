-- Mostrar los Elementos disponibles en la UI
-- View Elementos DTO

delimiter $$

drop view if exists view_ElementosDTO $$
create view GetElementosDTO as 
    select 
        e.idElemento,
        e.numeroSerie,
        e.codigoBarra,
        te.elemento as ElementoTipo,
        ee.estadoElemento as EstadoElementoNombre,
        c.numeroSerieCarrito
    from Elementos e
    join tipoElemento te using(idTipoElemento)
    join EstadosElemento ee using(idEstadoElemento)
    left join Carritos c using(idCarrito)
    where e.disponible = 1;

delimiter ;