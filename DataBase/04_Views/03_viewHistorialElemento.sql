-- Mostrar el Historial de un Elemento junto al usuario logueado

delimiter $$ 
drop view if exists GetHistorialElementosDTO $$
create view GetHistorialElementosDTO as
	select he.idHistorialElemento,
       he.fechaHora,
       he.observacion,
       te.elemento as ElementoTipo,
       e.numeroSerie,
       c.numeroSerieCarrito,
       ee.estadoElemento as EstadoElementoNombre
from HistorialElementos he
join Elementos e using(idElemento)
left join carritos c on e.idCarrito = c.idCarrito
join TipoElemento te on e.idTipoElemento = te.idTipoElemento 
join EstadosElemento ee ON e.idEstadoElemento = ee.idEstadoElemento;

delimiter ;